using GalaSoft.MvvmLight.Command;
using HFORCE.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HFORCE.ViewsModel
{
    class LoginViewModel:BaseViewModel
    {
       
        #region Atributos
        private string usuario;
        private string contraseña;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Propiedades
        public string Usuario 
        {
            get { return this.usuario; }
            set { SetValue(ref this.usuario, value); }
        }
        public string Contraseña
        {
            get { return this.contraseña; }
            set { SetValue(ref this.contraseña, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public bool IsRemember
        {
            get;
            set;
        }

        #endregion

        #region Constructores
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.isEnabled = true;
        }
        #endregion

        #region Comandos
        public ICommand LoginCommand
        { 
            get 
            {
                return new RelayCommand(Login);
            }
        }

        

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert("Error","Ingrese Usuario","Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese Contraseña", "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled=false;

            if (this.Usuario != "1" || this.Contraseña != "1")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "usuario o contraseña incorrecto", "Aceptar");
                this.Contraseña = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Usuario = string.Empty;
            this.Contraseña = string.Empty;

            MainViewModel.GetInstance().MenuPrincipal=new MenuPrincipalViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new MenuPrincipalPage());
        }
        #endregion
    }
}
