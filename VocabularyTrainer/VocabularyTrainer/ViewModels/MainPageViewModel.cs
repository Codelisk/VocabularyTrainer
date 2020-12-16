using Prism.Commands;
using Prism.Magician;
using Prism.Mvvm;
using Prism.Navigation;
using SharedModule.ViewModels.Base;
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
    public partial class MainPageViewModel : ReactiveVmBase
    {
        private readonly ITextToSpeech _textToSpeech;
        public MainPageViewModel(INavigationService navigationService, ITextToSpeech textToSpeech)
            : base()
        {
            _textToSpeech = textToSpeech;
            Title = "Main Page";
            Culture = CultureInfo.CurrentCulture;
        }
        [Reactive]
        public string ShownText { get; set; }
        [Reactive]
        public string EnterText { get; set; }
        public ObservableCollection<BaseVocabulary> ListToShow { get; set; }
        public ObservableCollection<BaseVocabulary> ListToCompare { get; set; }

        private DelegateCommand _shownToSpeech;
        public DelegateCommand ShownToSpeech =>
            _shownToSpeech ?? (_shownToSpeech = new DelegateCommand(ExecuteShownToSpeech));
        [Reactive]
        public CultureInfo Culture { get; set; }
        async void ExecuteShownToSpeech()
        {
            await _textToSpeech.SpeakAsync(ShownText);
        }
    }
}
