using System;
using System.Collections.Generic;
using System.Text;


namespace HFORCE.Infraestructure
{
    using ViewsModel;

    class InstanceLocator
    {
        #region Propiedades
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion

    }
}
