using DryIoc;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Magician;
using Prism.Modularity;
using VocabularyTrainer.ViewModels;
using VocabularyTrainer.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

[assembly: NameFormatProvider(NameFormatProviderStyle.CamelCaseNoPageSuffix)]
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
            var result=await NavigationService.NavigateAsync("NavigationPage/" + nameof(Views.MainPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<CreateVocabularyPage>();
            containerRegistry.RegisterForNavigation<TrainingPage>();

            RegisterXamarinEssentials(containerRegistry);
        }
        private void RegisterXamarinEssentials(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IFileSystem, FileSystemImplementation>();
            containerRegistry.RegisterSingleton<IDeviceInfo, DeviceInfoImplementation>();
            containerRegistry.RegisterSingleton<IDeviceDisplay, DeviceDisplayImplementation>();
            containerRegistry.RegisterSingleton<ITextToSpeech, TextToSpeechImplementation>();

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<SharedModule.SharedModuleModule>();
            moduleCatalog.AddModule<FontAwesomeModule.FontAwesomeModuleModule>();
            moduleCatalog.AddModule<SQLiteModule.SQLiteModuleModule>();
        }
    }
}
