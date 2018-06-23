using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XF.Contatos.Interface;
using XF.Contatos.Model;

namespace XF.Contatos.ViewModel
{
    public class ViewModelContato : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();

        public ViewModelContato()
        {
            CarregarContatos();
        }

        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CarregarContatos()
        {
            IContatos _contatos = DependencyService.Get<IContatos>();
            if (_contatos != null)
            {
                _contatos.BuscaContatos();

                MessagingCenter.Subscribe<IContatos, IList<Contato>>(this, "contatos",
                    (objeto, contatos) =>
                    {
                        Contatos.Clear();
                        foreach (var item in contatos)
                        {
                            Contatos.Add(item);
                        }
                    });
            }
        }

        public void FazerLigacao(string NumeroTelefone)
        {
            ILigar _ligar = DependencyService.Get<ILigar>();
            if (_ligar != null)
            {
                _ligar.FazerLigacao(NumeroTelefone);
            }
        }
    }
}
