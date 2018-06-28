using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Contatos.Interface
{
    public interface ITakePhoto
    {
        void GetPhotoFromCamera();
    }

    public static class PhotoConstant
    {
        public static readonly int REQUEST_CAMERA = 1000;
    }
}
