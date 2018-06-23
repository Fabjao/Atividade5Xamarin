using Android.App;
using Android.Content;
using Android.Net;
using Android.Telephony;
using System.Linq;
using Xamarin.Forms;
using XF.Contatos.Droid;
using XF.Contatos.Interface;

[assembly: Dependency(typeof(Ligar_Android))]
namespace XF.Contatos.Droid
{
    public class Ligar_Android : ILigar
    {
        void ILigar.FazerLigacao(string NumeroTelefone)
        {
        var context = MainApplication.CurrentContext as Activity;

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + NumeroTelefone));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
            }
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any()) return true;

            var manager = TelephonyManager.FromContext(context);
            return manager.PhoneType != PhoneType.None;
        }

       
    }
}
