using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.Interface;
using XF.Contatos.Model;
using XF.Contatos.ViewModel;

namespace XF.Contatos.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContatoView : ContentPage
	{
       private ViewModelContato _viewContato;

		public ContatoView ()
		{
			InitializeComponent();
            if (_viewContato == null)
            {
                _viewContato = new ViewModelContato();
            }
                        
            BindingContext = _viewContato;

        }

        private async void listaContatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelecionado = e.Item as Contato;

            var detalhe = new ContatoViewDetalhe();
            await Navigation.PushAsync(detalhe);

            var contato = new Contato()
            {
                Nome = itemSelecionado.Nome,
                Numero = itemSelecionado.Numero
            };
           MessagingCenter.Send<ContatoView, Contato>(this, "ContatoDetalhado", contato);

        }
    }
}