using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View;
using RecruitmentExchange.View.Deal;
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
        public DealVM()
        {
            state = new IdleDeal() { DataContext = this };
        }
        public List<Deal> Deals { get{ return DBMethods.GetAllDeals().Result; } }


        public override RelayCommand GoAdd => new RelayCommand(obj => { });
    }
}
