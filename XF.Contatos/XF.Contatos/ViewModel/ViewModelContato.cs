using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using XF.Contatos.Interface;
using XF.Contatos.Model;

namespace XF.Contatos.ViewModel
{
    public class ViewModelContato :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();

        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
