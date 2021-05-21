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
        public override string TabName { get; set; } = "Компании";

        TabViewBase state;
        public TabViewBase State
        {
            get
            { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }
        public CompanyVM()
        {
            State = this;
        }
        public Company Selected { get; set; }
        //Create
        public RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {

                    State = new EditCompanyVM(null, this);
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
                        State = new EditCompanyVM(Selected, this);
                    }
                });
            }
        }
        //Delete
        public RelayCommand GoRemove
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (Selected != null)
                    {
                        State = new RemoveCompanyVM(Selected, this);
                    }
                });
            }
        }

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = this;
                    Selected = null;
                });

            }
        }

    }
}
