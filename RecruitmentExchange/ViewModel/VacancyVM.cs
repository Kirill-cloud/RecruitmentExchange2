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
    class VacancyVM : TabViewBase, INotifyPropertyChanged
    {
        UserControl state = new IdleVacancyView();
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


        public RelayCommand AddVac
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
                    State = new IdleVacancyView();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
