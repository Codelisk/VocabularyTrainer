using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Polly;
using SQLite;
using Xamarin.Essentials.Interfaces;

namespace SQLiteModule.Services
{
    public abstract class BaseDatabase
    {
        protected BaseDatabase(string directory, string name)
        {
            var databasePath = Path.Combine(directory, name);
            DatabaseConnection = new SQLiteAsyncConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        }

        public TimeSpan ExpiresAt { get; }

        SQLiteAsyncConnection DatabaseConnection { get; }

        public abstract Task<int> DeleteAllData<TEntity>();

        public static Task<T> AttemptAndRetry<T>(Func<Task<T>> action, int numRetries = 12)
        {
            return Policy.Handle<SQLiteException>(OnExceptionFired).WaitAndRetryAsync(numRetries, pollyRetryAttempt).ExecuteAsync(action);

        }

        private static bool OnExceptionFired(SQLiteException arg)
        {
            return true;
        }

        public static Task AttemptAndRetry<T>(Func<Task> action, int numRetries = 12)
        {
            return Policy.Handle<SQLiteException>(OnExceptionFired).WaitAndRetryAsync(numRetries, pollyRetryAttempt).ExecuteAsync(action);

        }
        public static TimeSpan pollyRetryAttempt(int attemptNumber) => TimeSpan.FromMilliseconds(Math.Pow(2, attemptNumber));

        protected bool IsExpired(in DateTimeOffset downloadedAt) => downloadedAt.CompareTo(DateTimeOffset.UtcNow.Subtract(ExpiresAt)) <= 0;

        protected async ValueTask<SQLiteAsyncConnection> GetDatabaseConnection<T>()
        {
            if (!DatabaseConnection.TableMappings.Any(x => x.MappedType == typeof(T)))
            {
                await DatabaseConnection.EnableWriteAheadLoggingAsync().ConfigureAwait(false);

                try
                {
                    await DatabaseConnection.CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
                }
                catch (SQLiteException e) when (e.Message.IndexOf("PRIMARY KEY", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    await DatabaseConnection.DropTableAsync(DatabaseConnection.TableMappings.First(x => x.MappedType == typeof(T)));
                    await DatabaseConnection.CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
                }
            }

            return DatabaseConnection;
        }
    }
}