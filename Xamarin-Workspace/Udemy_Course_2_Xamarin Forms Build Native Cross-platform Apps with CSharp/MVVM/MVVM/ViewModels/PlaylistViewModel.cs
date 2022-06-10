using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVM.ViewModels
{
   public class PlaylistViewModel : BaseViewModel
    {


        public string Title { get; set; }

        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                SetValue<bool>(ref _isFavorite, value);

                OnPropertyChanged(nameof(Color));
            }


        }


        public Color Color
        {
            get { return IsFavorite ? Color.FromHex("#E63427") : Color.Black; }


        }

    }
}
