using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class IdleVacancyVM : TabViewBase
    {
        public override string TabName { get; set; } = "";

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
        public Vacancy Selected { get; set; }


        public IdleVacancyVM()
        {
            LoadGridAsync();
        }
        public async Task LoadGridAsync()
        {
            DBMethods db = new();
            Vacancies = await db.GetAllVacancies();
        }
    }
}
