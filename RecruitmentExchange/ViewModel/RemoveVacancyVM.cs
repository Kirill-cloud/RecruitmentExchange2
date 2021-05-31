using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;

namespace RecruitmentExchange.ViewModel
{
    public class RemoveVacancyVM : TabContentBase
    {
        public override string TabName { get; set; } = "Удалить..."; 
        
        private Vacancy selected;
        private VacancyVM origin;

        public RemoveVacancyVM(Vacancy selected, VacancyVM origin)
        {
            this.selected = selected;
            this.origin = origin;

            origin.State = new LoadingVM();
            //TODO async load if need
            origin.State = this;
        }

        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    DBMethods db = new();
                    await db.RemoveVacancy(selected);
                    origin.State = new IdleVacancyVM();
                });
            }
        }
    }
}