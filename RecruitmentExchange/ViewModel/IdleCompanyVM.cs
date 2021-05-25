using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class IdleCompanyVM : TabViewBase
    {
        public override string TabName { get; set; } = "Компании";

        List<Company> companies = new();
        public List<Company> Companies
        {
            get
            {
                return companies;
            }
            set
            {
                companies = value;
                OnPropertyChanged();
            }
        }
        public Company Selected { get; set; }

        public IdleCompanyVM()
        {
            LoadGridAsync();
        }

        public async Task LoadGridAsync()
        {
            DBMethods db = new();
            Companies = await db.GetAllCompanies();
        }

    }
}
