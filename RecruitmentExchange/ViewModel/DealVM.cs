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


        TabViewBase state;
        public TabViewBase State
        {
            get
            { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        public DealVM()
        {
            State = new IdleDealVM();
        }



        public RelayCommand GoAdd => new(obj =>
        {
            if (State is IdleDealVM)
            {
                State = new EditDealVM(null, this);
            }
        });
        public RelayCommand GoEdit => new(obj =>
        {
            if (State is IdleDealVM)
            {
                State = new EditDealVM((State as IdleDealVM).Selected, this);
            }
        });

        public RelayCommand GoRemove => new(obj =>
        {
            if (State is IdleDealVM)
            {
                State = new RemoveDealVM((State as IdleDealVM).Selected, this);
            }
        });

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new IdleDealVM();
                });

            }
        }
    }
}
