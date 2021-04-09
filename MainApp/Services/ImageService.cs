using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp.Services
{
    class ImageService : IImageService
    {
        OpenFileDialog dialog;

        public ImageService()
        {
            dialog = new OpenFileDialog { Filter = "Image files|*jpg;*png;*gif" };
        }

        public string GetImagePathWithDialog()
        {
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }
    }
}
