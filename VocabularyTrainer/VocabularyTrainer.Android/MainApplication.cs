using System;
using Android.App;
using Android.Runtime;
using Shiny;

namespace VocabularyTrainer.Droid
{
    [Application(
        Theme = "@style/MainTheme"
        )]
    public class MainApplication : Shiny.ShinyAndroidApplication<MyStartup>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Xamarin.Essentials.Platform.Init(this);
        }
    }
}
