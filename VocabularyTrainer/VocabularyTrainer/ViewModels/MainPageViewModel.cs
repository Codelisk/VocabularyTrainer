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
        public MainPageViewModel()
            : base()
        {
            Title = "Main Page";
        }
    }
}
