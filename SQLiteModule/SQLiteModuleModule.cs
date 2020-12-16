using Prism.Ioc;
using Prism.Modularity;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace SQLiteModule
{
    public partial class SQLiteModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFileSystem, FileSystemImplementation>();
        }
    }
}
