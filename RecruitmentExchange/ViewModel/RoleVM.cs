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
        public override string TabName { get; set; } = "Роли";


        public List<Role> Roles { get { return DBMethods.GetAllRoles(); } }

        TabViewBase state;
        public TabViewBase State { get { return state; } set { state = value; OnPropertyChanged("State"); } }

        public RoleVM()
        {
            State = this;
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
                    if (Selected!=null)
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
                State = new RemoveRoleVM(Selected,this);
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
