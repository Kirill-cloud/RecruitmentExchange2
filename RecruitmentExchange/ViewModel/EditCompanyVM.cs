using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    public class EditCompanyVM : TabViewBase
    {
        public override string TabName { get; set; } = "Редактирование Компании ";

        public string Name { get; set; }
        public string Focus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Company Company { get; set; }
        public CompanyVM Origin { get; set; }
        public EditCompanyVM(Company company, CompanyVM viewBase)
        {
            Origin = viewBase;
            Company = company;
            if (Company == null)
            {
                Company = new Company();
                TabName = "Добавление компании";
            }
            else
            {
                Name = Company.Name;
                Focus = Company.FocusedOn;
                Address = Company.Address;
                Phone = Company.Phone;

                TabName += Company.Name;
            }
        }


        public RelayCommand AddOrEdit
        {
            get
            {
                return new RelayCommand(async (obj) =>
                {
                    if (IsValid())
                    {
                        BoundCompany();

                        if (Company.Id != 0)
                        {
                            await Edit();
                        }
                        else
                        {
                            await Add();
                        }

                        Origin.Cancel.Execute(null);

                    }
                });
            }
        }
        async Task Edit()
        {
            DBMethods db = new();
            await db.EditCompany(Company);
        }
        async Task Add()
        {
            DBMethods db = new();
            await db.AddCompany(Company);
        }


        void BoundCompany()
        {
            Company.Name = Name;
            Company.FocusedOn = Focus;
            Company.Phone = Phone;
            Company.Address = Address;
        }
        private bool IsValid()
        {
            Validate();
            return (errors.Count == 0);
        }
        public void Validate()
        {
            errors.Clear();

            if (Name == null || Name == "")
            {
                errors.Add("Name", new List<string>() { "empty" });
            }
            if (Focus == null || Focus == "")
            {
                errors.Add("Focus", new List<string>() { "empty" });
            }
            if (Address == null || Address == "")
            {
                errors.Add("Address", new List<string>() { "empty" });
            }
            if (Phone == null || Phone == "")
            {
                errors.Add("Phone", new List<string>() { "empty" });
            }

            RaiseErrorsChanged(nameof(Name));
            RaiseErrorsChanged(nameof(Focus));
            RaiseErrorsChanged(nameof(Address));
            RaiseErrorsChanged(nameof(Phone));
        }
    }
}
