using Prism.Commands;
using Prism.Magician;
using Prism.Mvvm;
using Prism.Navigation;
using SharedModule.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocabularyTrainer.ViewModels
{
    [AutoInitialize]
    public partial class MainPageViewModel : ReactiveVmBase
    {
        [Bindable]
        public string Test { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base()
        {
            Title = "Main Page";
        }
    }
}
