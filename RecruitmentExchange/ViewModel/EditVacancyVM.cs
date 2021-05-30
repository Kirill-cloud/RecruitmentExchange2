using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    public class EditVacancyVM : TabViewBase
    {
        public override string TabName { get; set; } = "Редактор вакансии";

        public List<Role> Roles { get; set; }
        public List<Company> Companies{ get; set; }
        public Role SelectedRole { get; set; }
        public Company SelectedCompany { get; set; }
        public string Description { get; set; }

        Vacancy vacancy;
        readonly VacancyVM origin;

        public EditVacancyVM(Vacancy vacancy,VacancyVM origin)
        {
            this.vacancy = vacancy;
            this.origin = origin;


            LoadRelatedDataAsync();


        }

        async Task LoadRelatedDataAsync()
        {
            origin.State = new LoadingVM();

            DBMethods db = new();

            Roles = await db.GetAllRoles();
            Companies = await db.GetAllCompanies();

            if (vacancy == null)
            {
                vacancy = new Vacancy();
            }
            else
            {
                SelectedRole = Roles.Find(c => c.Id == vacancy.Role.Id);
                SelectedCompany = Companies.Find(c => c.Id == vacancy.Company.Id);
                Description = vacancy.Description;
            }
            OnPropertyChanged(nameof(Companies));
            OnPropertyChanged(nameof(Roles));

            origin.State = this;
        }

        public RelayCommand AddOrEdit
        {
            get
            {
                return new RelayCommand(async (obj) =>
                {
                    if (IsValid())
                    {
                        BoundVacancy();

                        if (vacancy.Id != 0)
                        {
                            await Edit();
                        }
                        else
                        {
                            await Add();
                        }

                        origin.State = new IdleVacancyVM();

                    }
                });
            }
        }
        private async Task Add()
        {
            DBMethods db = new();
            await db.AddVacany(vacancy);
        }
        private async Task Edit()
        {
            DBMethods db = new();
            await db.EditVacancy(vacancy);
        }

        private void BoundVacancy()
        {
            vacancy.Company = SelectedCompany;
            vacancy.Role = SelectedRole;
            vacancy.Description = Description;
        }
        private bool IsValid()
        {
            Validate();

            return (Errors.Count == 0);
        }
        public void Validate()
        {
            Errors.Clear();


            if (SelectedRole == null)
            {
                Errors.Add("SelectedRole", new List<string>() { "empty" });
            }
            if (SelectedCompany == null)
            {
                Errors.Add("SelectedCompany", new List<string>() { "empty" });
            }
            if (Description == null || Description == "")
            {
                Errors.Add("Description", new List<string>() { "empty" });
            }

            RaiseErrorsChanged(nameof(SelectedRole));
            RaiseErrorsChanged(nameof(SelectedCompany));
            RaiseErrorsChanged(nameof(Description));
        }
    }
}