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

            IContatos contatos = DependencyService.Get<IContatos>();
            _viewContato.Contatos = contatos.BuscaContatos();
            BindingContext = _viewContato;

        }

        private void listaContatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelecionado = e.Item as Contato;
            DisplayAlert("Contato selecionado",
                $"Nome: {itemSelecionado.Nome} - {itemSelecionado.Numero}", "OK");
        }
    }
}