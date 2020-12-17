using Prism.Commands;
using Prism.Magician;
using Prism.Mvvm;
using Prism.Navigation;
using SharedModule.ViewModels.Base;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using VocabularyTrainer.Models.Daos;
using Xamarin.Essentials.Interfaces;

namespace VocabularyTrainer.ViewModels
{
    public partial class TrainingPageViewModel : TabInsideVmBase
    {
        private readonly VocabularySqliteConnection _vocabularySqliteConnection;
        public TrainingPageViewModel(ITextToSpeech textToSpeech, VocabularySqliteConnection vocabularySqliteConnection)
            : base()
        {
            _vocabularySqliteConnection = vocabularySqliteConnection;
            _textToSpeech = textToSpeech;
        }
        private readonly ITextToSpeech _textToSpeech;
        [Reactive]
        public string ShownText { get; set; }
        [Reactive]
        public string EnterText { get; set; }
        public ObservableCollection<VocabularyPair<OwnVocabulary>> VocabularyPairs { get; set; }

        private DelegateCommand<string> _shownToSpeech;
        public DelegateCommand<string> ShownToSpeech =>
            _shownToSpeech ?? (_shownToSpeech = new DelegateCommand<string>(ExecuteShownToSpeech));
        [Reactive]
        public CultureInfo Culture1 { get; set; }
        [Reactive]
        public CultureInfo Culture2 { get; set; }
        async void ExecuteShownToSpeech(string text)
        {
            await _textToSpeech.SpeakAsync(text);
        }
        private DelegateCommand _checkCommand;
        public DelegateCommand CheckCommand =>
            _checkCommand ?? (_checkCommand = new DelegateCommand(ExecuteCheckCommand));
        public VocabularyPair<OwnVocabulary> CurrentVocabularyPair { get; set; }
        void ExecuteCheckCommand()
        {
            VocabularyPairs.Remove(CurrentVocabularyPair);
            CurrentVocabularyPair = VocabularyPairs.FirstOrDefault();
            ShownText = CurrentVocabularyPair.Vocabulary1.Text;
            Culture1 = CurrentVocabularyPair.Vocabulary1.Language;
            Culture2 = CurrentVocabularyPair.Vocabulary2.Language;
        }
        public async override void OnAppearing()
        {
            base.OnAppearing();
            
            var list= await _vocabularySqliteConnection.GetAllWithChildrenAsync<VocabularyPair<OwnVocabulary>>();
            if (list is null || !list.Any())
            {
                return;
            }
            VocabularyPairs = new ObservableCollection<VocabularyPair<OwnVocabulary>>(list);
            ShownText = list.FirstOrDefault().Vocabulary1.Text;
            CurrentVocabularyPair = list.FirstOrDefault();
            Culture1 = list.FirstOrDefault().Vocabulary1.Language;
            Culture2 = list.FirstOrDefault().Vocabulary2.Language;
        }
    }
}
