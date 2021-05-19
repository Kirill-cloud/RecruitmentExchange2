using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View;
using RecruitmentExchange.View.Company;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecruitmentExchange.ViewModel
{
    public class CompanyVM : TabViewBase
    {
        public CompanyVM()
        {
            state = new IdleCompanyView() { DataContext = this };
        }
        public string Name { get; set; }
        public string Focus { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Company Selected { get; set; }
        //Create
        public override RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new AddCompany() { DataContext = this };

                });
            }
        }
        public override RelayCommand Add
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (IsValid())
                    {
                        DBMethods.AddCompany(new Company()
                        {
                            Name = Name,
                            Address = Address,
                            FocusedOn = Focus,
                            Phone = Phone,

                        });
                        State = new IdleCompanyView() { DataContext = this };
                    }

                });
            }
        }
        //Read
        public List<Company> Companies
        {
            get
            {

                return DBMethods.GetAllCompanies();
            }
        }
        //Update
        public RelayCommand GoEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (Selected != null)
                    {
                        Name = Selected.Name;
                        Focus = Selected.FocusedOn;
                        Address = Selected.Address;
                        Phone = Selected.Phone;

                        State = new EditCompany() { DataContext = this };
                    }
                });
            }
        }
        public RelayCommand Edit
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    if (IsValid())
                    {
                        var edited = new Company() { Id = Selected.Id, Name = Name, FocusedOn = Focus, Address = Address, Phone = Phone };
                        await DBMethods.EditCompany(edited);

                        State = new IdleCompanyView() { DataContext = this };
                        Selected = null;
                    }
                });
            }
        }
        //Delete
        public int VacancyCount { get; set; }
        public override RelayCommand GoRemove
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (Selected != null)
                    {
                        VacancyCount = Selected.Vacansies.Count;

                        State = new RemoveCompany() { DataContext = this };
                    }
                });
            }
        }
        public override RelayCommand Remove
        {
            get
            {
                return new RelayCommand(async obj =>
                {

                    await DBMethods.RemoveCompany(Selected);

                    State = new IdleCompanyView() { DataContext = this };

                    Selected = null;

                });
            }
        }
        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new IdleCompanyView() { DataContext = this };
                    Selected = null;
                });

            }
        }
        private bool IsValid()
        {
            Validate();

            return (errors.Count == 0);
        }
        void Validate()
        {
            errors.Clear();

            if (Name == null || Name == "")
            {
                errors.Add("Name", new List<string>() { "empty" });
                RaiseErrorsChanged("Name");
            }
            if (Focus == null || Focus == "")
            {
                errors.Add("Focus", new List<string>() { "empty" });
                RaiseErrorsChanged("Focus");
            }
            if (Address == null || Address == "")
            {
                errors.Add("Address", new List<string>() { "empty" });
                RaiseErrorsChanged("Address");
            }
            if (Phone == null || Phone == "")
            {
                errors.Add("Phone", new List<string>() { "empty" });
                RaiseErrorsChanged("Phone");
            }

            RaiseErrorsChanged("Name");
            RaiseErrorsChanged("Focus");
            RaiseErrorsChanged("Address");
            RaiseErrorsChanged("Phone");
        }
    }
}
