using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View.Role;
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
    class RoleVM : TabViewBase
    {
        public RoleVM()
        {
            state = new IdleRole() { DataContext = this };
        }

        public List<Role> Roles { get { return DBMethods.GetAllRoles(); } }
        public int Id { get; set; }
        public string Name { get; set; }

        public override RelayCommand GoAdd => new RelayCommand(obj => { });
    }
}
