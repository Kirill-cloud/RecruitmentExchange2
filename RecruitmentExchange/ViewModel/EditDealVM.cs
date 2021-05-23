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

        private readonly Deal deal;
        private readonly DealVM origin;

        public List<Company> Companies { get { DBMethods dB = new(); return dB.GetAllCompanies(); } }
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
        public List<Vacancy> Vacancies
        {
            get
            {
                if (SelectedCompany != null)
                {
                    DBMethods dB = new();

                    return dB.GetAllVacancies().Where(x => x.CompanyId == SelectedCompany.Id).ToList();
                }
                else
                {
                    return new();
                }
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
        public List<Applicant> Applicants
        {
            get
            {
                if (SelectedVacancy != null)
                {
                    DBMethods dB = new();
                    return dB.GetAllApplicants().Where(x => x.RoleId == SelectedVacancy.RoleId).ToList();
                }
                else
                {
                    return new();
                }
            }
        }
        public Applicant SelectedApplicant { get; set; }


        public EditDealVM(Deal deal, DealVM origin)
        {
            this.deal = deal;
            this.origin = origin;
            if (deal == null)
            {
                this.deal = new Deal();
            }
            else
            {
    
                //DBMethods db = new();

                TabName = "Редактирование сделки между " + deal.Company.Name + " и " + deal.Applicant.Name;
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
                        BoundDeal();

                        if (deal.Id != 0)
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
            db.AddDeal(deal);
        }

        private void Edit()
        {
            DBMethods db = new();
            db.EditDeal(deal);
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
