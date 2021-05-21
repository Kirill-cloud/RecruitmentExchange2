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

        public int VacancyCount { get; set; }
        Company company;
        CompanyVM origin;
        public RemoveCompanyVM(Company company, CompanyVM origin)
        {
            TabName = "Удаление компании " + company.Name;
            this.company = company;
            this.origin = origin;



            DBMethods db = new();
            VacancyCount = db.GetAllVacancies().Where(x => x.Company.Id == company.Id).Count();
        }
        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(obj =>
                    {
                        DBMethods db = new();
                        db.RemoveCompany(company);
                        origin.State = origin;
                        origin.Selected = null;
                    });
            }
        }
    }
}
