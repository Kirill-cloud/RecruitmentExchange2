using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecruitmentExchange.ViewModel
{
    class RoleVM :TabViewBase, INotifyPropertyChanged
    {
        public UserControl State { get; set; }

    }
}
