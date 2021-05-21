using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class RemoveCompanyVM : TabViewBase
    {
        public override string TabName { get; set; }
        Company company;
        CompanyVM origin;
        public RemoveCompanyVM(Company company, CompanyVM origin)
        {
            TabName = "Удаление компании " + company.Name;
            this.company = company;
            this.origin = origin;
        }
        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(obj =>
                    {
                        DBMethods.RemoveCompany(company);
                        origin.State = new CompanyVM();
                        origin.Selected = null;
                    });
            }
        }
    }
}
