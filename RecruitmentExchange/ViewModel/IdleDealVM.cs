using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class IdleDealVM : TabContentBase
    {
        public override string TabName { get; set; } = "";
        public Deal Selected { get; set; }
        private string totalProfit;

        public string TotalProfit
        {
            get
            {
                return totalProfit;
            }
            set
            {
                totalProfit = value; OnPropertyChanged();
            }
        }

        List<Deal> deals;
        public List<Deal> Deals
        {
            get
            {
                return deals;
            }
            set
            {
                deals = value;
                OnPropertyChanged();
            }
        }

        public IdleDealVM()
        {
            LoadGridAsync();
        }

        async Task LoadGridAsync()
        {
            DBMethods db = new();
            Deals = await db.GetAllDeals();

            TotalProfit = "Всего заработано: " + Deals.Sum(x => x.Profit);
        }

    }
}
