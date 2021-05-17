using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View.Vacancy;
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
    class VacancyVM : TabViewBase
    {

        public Company SelectedCompany { get; set; }
        public Role SelectedRole { get; set; }
        public string Description { get; set; }
        public List<Company> Companies
        {
            get
            {
                return DBMethods.GetAllCompanies();
            }
        }
        public List<Role> Roles
        {
            get
            {
                return DBMethods.GetAllRoles();
            }
        }

        UserControl state = new IdleVacancyView();

        public UserControl State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
        public List<Vacancy> Vacancies
        {
            get
            {
                return DBMethods.GetAllVacancies();
            }
        }


        public override RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new AddVacancy();
                });
            }
        }

        public RelayCommand Add
        {
            get
            {
                return new RelayCommand(obj =>
                {

                    DBMethods.AddVacany(new Vacancy() { CompanyId = SelectedCompany.Id, RoleId = SelectedRole.Id, Description = Description});
                    State = new IdleVacancyView();
                });
            }
        }

    }
}
