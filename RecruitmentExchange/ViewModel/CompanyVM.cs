using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View;
using RecruitmentExchange.View.Company;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged();
            }
        }
        public CompanyVM()
        {
            LoadGridAsync();
            LoadGridAsync();
        }

        public async Task LoadGridAsync()
        {
            State = new LoadingVM();

            DBMethods db = new();
            Companies = new ObservableCollection<Company>(await db.GetAllCompanies());

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
        ObservableCollection<Company> companies = new();
        public ObservableCollection<Company> Companies
        {
            get
            {
                return companies;
            }
            set
            {
                companies = value;
                OnPropertyChanged();
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
                    var x = State;
                    State = null;
                    State = this;
                    Selected = null;
                });

            }
        }

    }
}
