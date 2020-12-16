using Foundation;
using Prism;
using Prism.Ioc;
using Shiny;
using UIKit;


namespace VocabularyTrainer.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        //Maby comment this one out
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            this.ShinyFinishedLaunching(new MyStartup());
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
