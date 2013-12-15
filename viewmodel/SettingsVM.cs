using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMvvm.viewmodel
{
    class SettingsVM : ObservableObject, IPage
    {

        public string Name
        {
            get { return "Settings"; }
        }
    }
}
