﻿using RecruitmentExchange.AppData;
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

        public TabViewBase State { get; set; }

        public DealVM()
        {
            State = this;
        }
        public List<Deal> Deals { get{ return DBMethods.GetAllDeals().Result; } }


        public RelayCommand GoAdd => new RelayCommand(obj => { });
    }
}
