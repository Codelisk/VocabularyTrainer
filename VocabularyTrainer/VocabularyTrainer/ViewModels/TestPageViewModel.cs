using Prism.Magician;
using Prism.Navigation;
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
        public string Test { get; set; }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Test = "TEST";
        }
    }
}
