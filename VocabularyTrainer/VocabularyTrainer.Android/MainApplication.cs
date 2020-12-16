using System;
using Android.App;
using Android.Runtime;
using Shiny;

namespace VocabularyTrainer.Droid
{
    [Application(
        Theme = "@style/MainTheme"
        )]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            this.ShinyOnCreate(new MyStartup());
            Xamarin.Essentials.Platform.Init(this);
        }
    }
}
