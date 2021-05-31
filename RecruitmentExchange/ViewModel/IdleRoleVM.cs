﻿using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class IdleRoleVM : TabContentBase
    {
        public override string TabName { get; set; }
        public Role Selected { get; set; }
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

        public IdleRoleVM(List<Role> roles)
        {
            Roles = roles;
        }
    }
}