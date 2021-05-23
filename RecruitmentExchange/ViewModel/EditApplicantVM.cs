using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class EditApplicantVM : TabViewBase
    {
        public override string TabName { get; set; }

        public string Name { get; set; }
        public List<Role> Roles { get { DBMethods db = new(); return db.GetAllRoles(); } }
        public Role SelectedRole { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }

        Decimal parsedSalary;
        readonly Applicant applicant;
        readonly ApplicantVM origin;
        public EditApplicantVM(Applicant applicant,ApplicantVM origin)
        {
            this.origin = origin;
            this.applicant = applicant;

            if (applicant == null)
            {
                this.applicant = new Applicant
                {
                    IsActive = true
                };
            }
            else
            {
                Name = applicant.Name;
                SelectedRole = Roles.Find(c => c.Id == applicant.Role.Id);
                Description = applicant.Description;
                Salary = applicant.Salary.ToString();
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
                        BoundApplicant();

                        if (applicant.Id != 0)
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
            db.AddApplicant(applicant);

        }
        private void Edit()
        {
            DBMethods db = new();
            db.EditApplicant(applicant);
        }
        private void BoundApplicant()
        {
            applicant.Name = Name;
            applicant.Role = SelectedRole;
            applicant.Description = Description;
            applicant.Salary = parsedSalary;
        }
        private bool IsValid()
        {
            Validate();
            return (errors.Count == 0);

        }
        private void Validate()
        {
            errors.Clear();

            if (Name == null || Name == "")
            {
                errors.Add("Name", new List<string>() { "empty" });
            }

            if (SelectedRole == null)
            {
                errors.Add("SelectedRole", new List<string>() { "empty" });
            }

            if (Description == null || Description == "")
            {
                errors.Add("Description", new List<string>() { "empty" });
            }

            if (Salary == null || Salary =="" || !Decimal.TryParse(Salary, out parsedSalary))
            {
                errors.Add("Salary", new List<string>() { "empty" });
            }

            RaiseErrorsChanged(nameof(Name));
            RaiseErrorsChanged(nameof(SelectedRole));
            RaiseErrorsChanged(nameof(Description));
            RaiseErrorsChanged(nameof(Salary));

        }
    }
}
