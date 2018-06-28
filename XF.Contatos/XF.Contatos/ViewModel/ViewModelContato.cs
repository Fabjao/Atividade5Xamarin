using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Contatos.Interface;
using XF.Contatos.Model;

namespace XF.Contatos.ViewModel
{
    public class ViewModelContato : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();
        public byte[] Thumbnail { get; set; }
        public ICommand TakePhotoCommand { get; set; }
        private Contato _contatoSelected;
        public Coordenada coordenada { get; set; } = new Coordenada();


        public ViewModelContato()
        {
            CarregarContatos();
            PegarLocalizacaoGPS();
            TakePhotoCommand = new Command(ActionTakePhotoCommand);
        }

        public Contato contatoSelected
        {
            get
            {
                return _contatoSelected;
            }
            set
            {
                if (_contatoSelected != value)
                {
                    _contatoSelected = value;
                    EventPropertyChanged(nameof(contatoSelected));
                }
            }
        }

        public void ExibirNoMapa()
        {
            ILocalizacao localizacao = DependencyService.Get<ILocalizacao>();

            if (localizacao != null)
            {
                localizacao.GoToCoordenada(coordenada);
            }
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

        private void ActionTakePhotoCommand()
        {
            ITakePhoto photo = DependencyService.Get<ITakePhoto>();

            if (photo != null)
            {
                photo.GetPhotoFromCamera();
                MessagingCenter.Subscribe<ITakePhoto, byte[]>(this, "photo",
                   (objeto, file) =>
                   {
                       contatoSelected.Thumbnail = file;
                       EventPropertyChanged(nameof(contatoSelected));
                   });
            }
        }


        private void PegarLocalizacaoGPS()
        {


            ILocalizacao localizacao = DependencyService.Get<ILocalizacao>();
            if (localizacao != null)
            {
                localizacao.GetCoordenada();

                MessagingCenter.Subscribe<ILocalizacao, Coordenada>(this, "coordenada",
                    (objeto, geo) =>
                    {
                        coordenada.Latitude = geo.Latitude;
                        coordenada.Longitude = geo.Longitude;

                        EventPropertyChanged(nameof(coordenada));
                    });
            }
        }
    }
}
