using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class IdleRoleVM : TabViewBase
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

        public IdleRoleVM()
        {
            LoadGridAsync();
        }

        public async Task LoadGridAsync()
        {
            DBMethods db = new();
            Roles = await db.GetAllRoles();
        }
    }
}
