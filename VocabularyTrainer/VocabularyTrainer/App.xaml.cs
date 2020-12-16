using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Magician;
using VocabularyTrainer.ViewModels;
using VocabularyTrainer.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace VocabularyTrainer
{
    [AutoRegisterViews]
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            var result=await NavigationService.NavigateAsync("NavigationPage/ViewA");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            //AutoRegistraton(containerRegistry);
        }
    }
}
