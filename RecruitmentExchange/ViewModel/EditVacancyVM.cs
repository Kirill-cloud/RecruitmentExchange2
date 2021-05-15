using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecruitmentExchange.ViewModel
{
    class EditVacancyVM
    {
        public Company Company { get; set; }
        public Role Role { get; set; }
        public string Description { get; set; }

        public List<Role> Roles { get { return DBMethods.GetAllRoles(); } }
        public List<Company> Companies { get { return DBMethods.GetAllCompanies(); } }

        readonly Window window;

        public EditVacancyVM(Window window)
        {
            this.window = window;
        }

        public RelayCommand AddVacancy
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var x = new Vacancy() { Description = Description, CompanyId=Company.Id, RoleId=Role.Id};
                    DBMethods.AddVacany(x);
                    window.Close();
                });
            }
        }
    }
}
