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
    class IdleCompanyVM : TabContentBase
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

        CompanyVM origin;
        public IdleCompanyVM()
        {
            LoadGridAsync();
        }

        public IdleCompanyVM(List<Company> companies)
        {
            Companies = companies;
        }

        public async Task LoadGridAsync()
        {
            origin.State = new LoadingVM();
            DBMethods db = new();
            Companies = await db.GetAllCompanies();
        }

    }
}
