using Prism.Commands;
using Prism.Magician;
using SharedModule.ViewModels.Base;
using SQLiteModule.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyTrainer.Models.Daos;

namespace VocabularyTrainer.ViewModels
{
    public partial class CreateVocabularyPageViewModel : ReactiveVmBase
    {
        public CreateVocabularyPageViewModel(VocabularySqliteConnection vocabularySqliteConnection)
        {
            //this._myShinySqliteConnection = myShinySqliteConnection as VocabularySqliteConnection;
        }
        public OwnVocabulary OwnVocabulary { get; set; }

        [Reactive]
        public string Text1 { get; set; }
        [Reactive]
        public string Text2 { get; set; }
        [Reactive]
        public CultureInfo Language1 { get; set; }
        [Reactive]
        public CultureInfo Language2 { get; set; }

        private DelegateCommand _saveVocabularyCommand;
        public DelegateCommand SaveVocabularyCommand =>
            _saveVocabularyCommand ?? (_saveVocabularyCommand = new DelegateCommand(ExecuteCreateVocabularyCommand));

        async void ExecuteCreateVocabularyCommand()
        {
            var ownVocabel = new VocabularyPair<OwnVocabulary>
            {
                Vocabulary1 = new OwnVocabulary
                {
                    Language = Language1,
                    Text = Text1
                },
                Vocabulary2 = new OwnVocabulary
                {
                    Language = Language2,
                    Text = Text2
                }
            };
            //await _myShinySqliteConnection.InsertAsync(ownVocabel);
            Text1 = "";
            Text2 = "";
        }
    }
}
