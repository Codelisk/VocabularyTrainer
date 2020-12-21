using Prism.Magician;
using Prism.Navigation;
using ReactiveUI;
using SharedModule.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyTrainer.ViewModels
{
    public partial class TestPageViewModel : ReactiveVmBase
    {
        public TestPageViewModel()
        {

        }
        [Reactive]
        public string MagicianReactive { get; set; }
        private string _normalReactive;
        public string NormalReactive
        {
            get { return _normalReactive; }
            set { this.RaiseAndSetIfChanged(ref _normalReactive, value); }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            MagicianReactive = "Magician Binding";
            NormalReactive = "Normal Reactive Binding";
        }
    }
}
