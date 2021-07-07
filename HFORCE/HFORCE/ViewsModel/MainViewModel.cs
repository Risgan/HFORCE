using System;
using System.Collections.Generic;
using System.Text;

namespace HFORCE.ViewsModel
{
    class MainViewModel
    {
        #region ViewsModels
        public LoginViewModel Login 
        {
            get;
            set;
        }

        public object MenuPrincipal 
        {
            get;
            set;
        }
        #endregion

        #region Constructores
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
