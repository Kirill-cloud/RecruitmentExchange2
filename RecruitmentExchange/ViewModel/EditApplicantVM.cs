using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    public class EditApplicantVM : TabViewBase
    {
        public override string TabName { get; set; }

        public string Name { get; set; }
        List<Role> roles;
        public List<Role> Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }
        public Role SelectedRole { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }

        Decimal parsedSalary;
        Applicant applicant;
        readonly ApplicantVM origin;
        public EditApplicantVM(Applicant applicant, ApplicantVM origin)
        {
            this.origin = origin;
            this.applicant = applicant;

            LoadRelatedDataAsync();
        }

        async Task LoadRelatedDataAsync()
        {
            DBMethods db = new();

            Roles = await db.GetAllRoles();

            if (applicant == null)
            {
                applicant = new Applicant
                {
                    IsActive = true
                };
            }
            else
            {
                Name = applicant.Name;
                SelectedRole = Roles.Find(c => c.Id == applicant.RoleId);
                Description = applicant.Description;
                Salary = applicant.Salary.ToString();
            }

            OnPropertyChanged(nameof(Roles));
        }

        public RelayCommand AddOrEdit
        {
            get
            {
                return new RelayCommand(async (obj) =>
                {
                    if (IsValid())
                    {
                        BoundApplicant();

                        if (applicant.Id != 0)
                        {
                            await Edit();
                        }
                        else
                        {
                            await Add();
                        }

                        origin.State = new IdleApplicantVM();

                    }
                });
            }
        }
        private async Task Add()
        {
            DBMethods db = new();
            try
            {
                await db.AddApplicant(applicant);
            }
            catch (Exception)
            {
                TabName = "Неудалось добавить, попробуйте снова";
            }
        }
        private async Task Edit()
        {
            DBMethods db = new();
            try
            {
                await db.EditApplicant(applicant);
            }
            catch (Exception)
            {
                TabName = "Неудалось изменить, попробуйте снова или проверьте параметры";
            }
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
            return (Errors.Count == 0);

        }
        public void Validate()
        {
            Errors.Clear();

            if (Name == null || Name == "")
            {
                Errors.Add("Name", new List<string>() { "empty" });
            }

            if (SelectedRole == null)
            {
                Errors.Add("SelectedRole", new List<string>() { "empty" });
            }

            if (Description == null || Description == "")
            {
                Errors.Add("Description", new List<string>() { "empty" });
            }

            if (Salary == null || Salary == "" || !Decimal.TryParse(Salary, out parsedSalary))
            {
                Errors.Add("Salary", new List<string>() { "empty" });
            }

            RaiseErrorsChanged(nameof(Name));
            RaiseErrorsChanged(nameof(SelectedRole));
            RaiseErrorsChanged(nameof(Description));
            RaiseErrorsChanged(nameof(Salary));

        }
    }
}
