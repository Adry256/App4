using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App4.ViewModels
{
    class CountViewModel : BaseViewModel
    {
        int _contador;
        string _countConverter;     
        ICommand _buttonClickCommand;
        ICommand _resetClickCommand;
       

        public CountViewModel()
        {
            _contador = 0;
        }

        public int Contador
        {
            get => _contador;
            set
            {
                if (value == _contador) return;
                _contador = value;
                CountConverter = $"Haz dado clic {_contador} veces";
                OnPropertyChanged();
               
            }
        }

        public string CountConverter
        {
            get => _countConverter;
            set
            {
                if (string.Equals(_countConverter, value)) return;
                _countConverter = value;
                OnPropertyChanged();
            }
           
        }

        public ICommand ButtonClickCommand
        {
            get => _buttonClickCommand ?? (_buttonClickCommand = new Command(ButtonClickAction));
           
        }

        private void ButtonClickAction()
        {
            Contador++;
        }

        public ICommand ResetClickCommand
        {
            get
            {
                if (_resetClickCommand == null)
                    _resetClickCommand = new Command(ResetAction);
                return _resetClickCommand;
            }
        }

        private void ResetAction()
        {
            Contador = 0;
            CountConverter = "Haz reseteado";
        }
    }
}
