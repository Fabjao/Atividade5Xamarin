using System;
using System.Collections.Generic;
using System.Text;
using XF.Contatos.Model;

namespace XF.Contatos.Interface
{
    public interface ILocalizacao
    {
        void GetCoordenada();

        void GoToCoordenada(Coordenada coordenada);
    }
}
