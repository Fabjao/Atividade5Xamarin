using Android.App;
using Android.Content;
using Android.Net;
using Android.Telephony;
using System.Linq;
using Xamarin.Forms;
using XF.Contatos.Interface;
using XF.Contatos.Model;

[assembly: Dependency(typeof(Contatos_Android))]
namespace XF.Contatos.Droid
{
    public class Contatos_Android : IContatos
    {
        public ObservableCollection<Contato> BuscaContatos()
        {
            ObservableCollection<Contato> _contatos = new ObservableCollection<Contato>();
            _contatos.add(new Contato()
            {
                Nome ="Fabio",
                Numero = "12937803"
            });
            return _contatos;
        }
    }
}