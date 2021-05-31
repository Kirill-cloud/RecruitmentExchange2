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

        public CompanyVM()
        {
            Cancel.Execute(null);
        }


        //Create
        public RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new EditCompanyVM(null, this);
                }, CheckLoading);
            }
        }

        static bool IsLoading { get; set; } = false;

        bool CheckLoading(object o)
        {
            return !IsLoading;
        }

        //Update
        public RelayCommand GoEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if ((State is IdleCompanyVM) && (State as IdleCompanyVM).Selected != null)
                    {
                        State = new EditCompanyVM((State as IdleCompanyVM).Selected, this);
                    }
                }, CheckLoading);
            }
        }
        //Delete
        public RelayCommand GoRemove
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if ((State is IdleCompanyVM) && (State as IdleCompanyVM).Selected != null)
                    {
                        State = new RemoveCompanyVM((State as IdleCompanyVM).Selected, this);
                    }
                }, CheckLoading);
            }
        }

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    IsLoading = true;
                    State = new LoadingVM();

                    DBMethods db = new();
                    State = new IdleCompanyVM(await db.GetAllCompanies());

                    IsLoading = false;

                }, CheckLoading);

            }
        }

    }
}
