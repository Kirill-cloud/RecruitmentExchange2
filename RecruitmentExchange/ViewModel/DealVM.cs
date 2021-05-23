using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View;
using RecruitmentExchange.View.Deal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecruitmentExchange.ViewModel
{
    public class DealVM : TabViewBase
    {
        public override string TabName { get; set; } = "Сделки";

        public Deal Selected { get; set; }

        TabViewBase state;
        public TabViewBase State
        {
            get
            { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        public DealVM()
        {
            State = this;
        }
        public List<Deal> Deals
        {
            get 
            {
                DBMethods db = new();
                return db.GetAllDeals().Result;
            }
        }


        public RelayCommand GoAdd => new(obj =>
        {
            State = new EditDealVM(null, this);
        });
        public RelayCommand GoEdit => new(obj =>
        {
            State = new EditDealVM(Selected, this);
        });

        public RelayCommand GoRemove => new(obj =>
        {
            State = new RemoveDealVM(Selected, this);
        });

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
