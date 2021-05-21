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
    public class VacancyVM : TabViewBase
    {
        public override string TabName { get; set; } = "Вакансии";
        public List<Vacancy> Vacancies { get { DBMethods db = new(); return db.GetAllVacancies(); } }

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
                    State = new EditVacancyVM(null, this);
                });
            }
        }
        public RelayCommand GoEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new EditVacancyVM(Selected, this);
                });
            }
        }
        public RelayCommand GoRemove
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (Selected != null)
                    {
                        State = new RemoveVacancyVM(Selected, this);
                    }
                });
            }
        }
        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = this;
                    Selected = null;
                });

            }
        }

    }
}
