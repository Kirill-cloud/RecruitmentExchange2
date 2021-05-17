using RecruitmentExchange.Model;
using RecruitmentExchange.View;
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
    public class DealVM : TabViewBase
    {
        public override RelayCommand GoAdd => new RelayCommand(obj => { });
    }
}
