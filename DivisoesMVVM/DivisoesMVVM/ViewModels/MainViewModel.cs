using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DivisoesMVVM.Services;
using GalaSoft.MvvmLight.Command;

namespace DivisoesMVVM.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {

        #region Construtor
        public MainViewModel()
        {
            dialogService = new DialogService();
        } 
        #endregion

        #region Atributos
        private DialogService dialogService;
        private decimal _real;
        private decimal _dollars;
        private decimal _libras;
        private decimal _euros;
        private ICommand _convertCommand;

      
        #endregion

        #region Propriedades
        public decimal Real
        {
            get
            {
                return _real;
            }

            set
            {
                if (_real != value)
                {
                    _real = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pesos"));
                }
           
            }
        }

        public decimal Dollars
        {
            get
            {
                return _dollars;
            }

            set
            {
                if (_dollars != value)
                {
                    _dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dollars"));
                }

            }
        }

        public decimal Libras
        {
            get
            {
                return _libras;
            }

            set
            {
                if (_libras != value)
                {
                    _libras = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pounds"));
                }

            }
        }

        public decimal Euros
        {
            get
            {
                return _euros;
            }

            set
            {
                if (_euros != value)
                {
                    _euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Euros"));
                }

            }
        }

        public ICommand ConvertCommand
        {
            get { return new RelayCommand(ConvertMoney); }
            set { _convertCommand = value; }
        }
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion

        #region Metodos
        private async void ConvertMoney()
        {
            if (Real <= 0)
            {
                await dialogService.ShowMessage("Error", "Deve inserir um valor maior que zero (0)");
                return;
            }

            Dollars = Real * (decimal)0.317662;
            Euros = Real * (decimal)0.296146926;
            Libras = Real * (decimal)0.247844269;

        }
        #endregion
    }
}
