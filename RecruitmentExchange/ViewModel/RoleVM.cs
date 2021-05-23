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
    public class RoleVM : TabViewBase
    {
        public override string TabName { get; set; } = "Роли";

        List<Role> roles;

        public RoleVM()
        {
            State = this;

            LoadGridAsync();
        }

        public async Task LoadGridAsync()
        {
            State = new LoadingVM();

            DBMethods db = new();
            Roles = await db.GetAllRoles();

            State = this;
        }

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
                OnPropertyChanged("State");
            }
        }
        public Role Selected { get; set; }
        public RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {

                    State = new EditRoleVM(null, this);

                });
            }
        }
        public RelayCommand GoEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (Selected != null)
                    {
                        State = new EditRoleVM(Selected, this);
                    }
                });
            }
        }
        public RelayCommand GoRemove => new RelayCommand(obj =>
        {
            if (Selected != null)
            {
                State = new RemoveRoleVM(Selected, this);
            }
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
