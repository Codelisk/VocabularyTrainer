using Prism.Ioc;
using Prism.Modularity;
using SharedModule.Services;
using SharedModule.Services.Interfaces;
using SharedModule.ViewModels;
using SharedModule.Views;

namespace SharedModule
{
    public partial class SharedModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICultureService, CultureService>();
        }
    }
}
