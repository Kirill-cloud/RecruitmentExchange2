using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class EditDealVM : TabViewBase
    {
        public override string TabName { get; set; } = "Добавление сделки";

        private Deal deal;
        private readonly DealVM origin;

        List<Company> companies;
        public List<Company> Companies
        {
            get
            {
                return companies;
            }
            set
            {
                companies = value;
                OnPropertyChanged(nameof(Companies));
            }
        }
        Company selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return selectedCompany;
            }
            set
            {
                selectedCompany = value;
                OnPropertyChanged("Vacancies");
            }
        }


        List<Vacancy> vacancies;
        public List<Vacancy> Vacancies
        {
            get
            {
                if (SelectedCompany != null)
                {
                    return vacancies.Where(vac => vac.CompanyId == SelectedCompany.Id).ToList();
                }
                else
                {
                    return new();
                }
            }
            set
            {
                vacancies = value;
                OnPropertyChanged(nameof(Vacancies));
            }
        }
        Vacancy selectedVacancy;
        public Vacancy SelectedVacancy
        {
            get
            {
                return selectedVacancy;
            }
            set
            {
                selectedVacancy = value;
                OnPropertyChanged("Applicants");
            }
        }


        List<Applicant> applicants;
        public List<Applicant> Applicants
        {
            get
            {
                if (SelectedVacancy != null)
                {
                    return applicants.Where(apl => apl.RoleId == SelectedVacancy.RoleId ).ToList();
                }
                else
                {
                    return new();
                }
            }
            set
            {
                applicants = value;
                OnPropertyChanged(nameof(Applicants));
            }
        }
        public Applicant SelectedApplicant { get; set; }


        public EditDealVM(Deal deal, DealVM origin)
        {
            this.deal = deal;
            this.origin = origin;

            origin.State = new LoadingVM();


            LoadRelatedDataAsync();
            
        }

        async Task LoadRelatedDataAsync()
        {

            DBMethods db = new();

            Companies = await db.GetAllCompanies();
            Vacancies = await db.GetAllVacancies();
            Applicants = await db.GetAllApplicants();

            if (deal == null)
            {
                deal = new Deal();
            }
            else
            {
                TabName = "Редактирование сделки между " + deal.Company.Name + " и " + deal.Applicant.Name;
                OnPropertyChanged("TabName");
            }

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
                        BoundDeal();

                        if (deal.Id != 0)
                        {
                            await Edit();
                        }
                        else
                        {
                            await Add();
                        }

                        origin.State = new IdleDealVM();

                    }
                });
            }
        }

        async Task Add()
        {
            DBMethods db = new();
            await db.AddDeal(deal);
        }

        async Task Edit()
        {
            DBMethods db = new();
            await db.EditDeal(deal);
        }

        private void BoundDeal()
        {
            deal.Applicant = SelectedApplicant;
            deal.Vacancy = SelectedVacancy;
            deal.Company = SelectedCompany;

            deal.Profit = deal.Applicant.Salary * (Decimal).5;
        }

        private bool IsValid()
        {
            Validate();
            return (errors.Count == 0);

        }

        private void Validate()
        {
            errors.Clear();

            if (SelectedCompany == null)
            {
                errors.Add("SelectedCompany", new List<string>() { "empty" });
            }

            if (SelectedVacancy == null)
            {
                errors.Add("SelectedVacancy", new List<string>() { "empty" });
            }

            if (SelectedApplicant == null)
            {
                errors.Add("SelectedApplicant", new List<string>() { "empty" });
            }

            RaiseErrorsChanged(nameof(SelectedCompany));
            RaiseErrorsChanged(nameof(SelectedVacancy));
            RaiseErrorsChanged(nameof(SelectedApplicant));

        }
    }
}
