using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;

namespace RecruitmentExchange.ViewModel
{
    internal class EditVacancyVM : TabViewBase
    {
        public override string TabName { get; set; } = "Редактор вакансии";

        public List<Role> Roles { get; set; }
        public List<Company> Companies{ get; set; }

        public Role SelectedRole { get; set; }
        public Company SelectedCompany { get; set; }
        public string Description { get; set; }


        Vacancy vacancy;
        VacancyVM origin;

        public EditVacancyVM(Vacancy vacancy,VacancyVM origin)
        {
            this.vacancy = vacancy;
            this.origin = origin;

            DBMethods db = new();

            Roles = db.GetAllRoles();
            Companies = db.GetAllCompanies();
            if (vacancy==null)
            {
                this.vacancy = new Vacancy();
            }
            else
            {
                SelectedRole = Roles.Find(c => c.Id == vacancy.Role.Id);
                SelectedCompany = Companies.Find(c => c.Id == vacancy.Company.Id);
                Description = vacancy.Description;
            }
        }

        public RelayCommand AddOrEdit
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (IsValid())
                    {
                        BoundVacancy();

                        if (vacancy.Id != 0)
                        {
                            Edit();
                        }
                        else
                        {
                            Add();
                        }

                        origin.State = origin;
                        origin.Selected = null;

                    }
                });
            }
        }

        private void Add()
        {
            DBMethods db = new();
            db.AddVacany(vacancy);
        }

        private void Edit()
        {
            DBMethods db = new();
            db.EditVacancy(vacancy);
        }

        private void BoundVacancy()
        {
            vacancy.Company = SelectedCompany;
            vacancy.Role = SelectedRole;
            vacancy.Description = Description;
        }

        private bool IsValid()
        {
            return true;
        }
    }
}