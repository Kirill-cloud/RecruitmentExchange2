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

        List<Vacancy> vacancies;
        public List<Vacancy> Vacancies
        {
            get
            {
                return vacancies;
            }
            set
            {
                vacancies = value;
                OnPropertyChanged("Vacancies");
            }
        }

        TabViewBase state;
        public TabViewBase State
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

        public VacancyVM()
        {
            LoadGridAsync();
        }
        public async Task LoadGridAsync()
        {
            State = new LoadingVM();


            DBMethods db = new();
            Vacancies = await db.GetAllVacancies();

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
