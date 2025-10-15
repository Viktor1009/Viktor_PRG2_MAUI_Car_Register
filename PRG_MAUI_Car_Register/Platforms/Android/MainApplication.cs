using Android.App;
using Android.Runtime;
using PRG_MAUI_Car_Register.modelview;

namespace PRG_MAUI_Car_Register
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
