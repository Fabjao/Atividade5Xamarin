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
    public partial class ContatoViewDetalhe : ContentPage
    {
        private Contato _contato;
        private ViewModelContato _viewContato;

        public ContatoViewDetalhe()
        {
            InitializeComponent();
            if (_viewContato == null)
            {
                _viewContato = new ViewModelContato();
            }

            MessagingCenter.Subscribe<ContatoView, Contato>(this, "ContatoDetalhado", (navegarParametro, param) =>
            {
                pegarParametro(param);
            });

        }


        private void pegarParametro(Contato contato)
        {
            _viewContato.contatoSelected = contato;
            BindingContext = _viewContato;
        }


        private void btnDiscar_Clicked(object sender, EventArgs e)
        {
            _viewContato.FazerLigacao(_viewContato.contatoSelected.Numero);
        }

        private void btnMostrarMapa_Clicked(object sender, EventArgs e)
        {
           _viewContato.ExibirNoMapa();
            
        }

    }
}