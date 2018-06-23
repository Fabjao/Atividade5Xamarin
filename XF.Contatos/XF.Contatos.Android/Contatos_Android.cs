using Android.App;
using Android.Content;
using Android.Net;
using Android.Telephony;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Contacts;
using Xamarin.Forms;
using XF.Contatos.Droid;
using XF.Contatos.Interface;
using XF.Contatos.Model;

[assembly: Dependency(typeof(Contatos_Android))]
namespace XF.Contatos.Droid
{
    public class Contatos_Android : IContatos
    {
        void IContatos.BuscaContatos()
        {
            var context = MainApplication.CurrentContext as Activity;
            var book = new AddressBook(context);
            
            Task.Run(async () =>
            {
                if (await book.RequestPermission())
                {
                    IList<Contato> contatos = new List<Contato>();
                    foreach (Contact contato in book.ToList().OrderBy(c => c.LastName))
                    {
                        contatos.Add(new Contato()
                        {
                            Nome = contato.FirstName,
                            Numero = contato.Phones.FirstOrDefault()?.Number
                        });
                    }
                    MessagingCenter.Send<IContatos, IList<Contato>>(this, "contatos", contatos);
                }
            });
        }
    }
}