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
        public override string TabName { get; set; } = "Вакансии";
        public List<Vacancy> Vacancies { get { return DBMethods.GetAllVacancies(); } }

        TabViewBase state;
        public TabViewBase State { get { return state; } set { state = value; OnPropertyChanged("State"); } }

        public VacancyVM()
        {
            State = this;
        }

        public Vacancy Selected { get; set; }


        public RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new EditVacancyVM();
                });
            }
        }

    }
}
