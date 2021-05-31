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


        public RoleVM()
        {
            State = new IdleRoleVM();

        }

        public RelayCommand GoAdd
        {
            get
            {
                return new RelayCommand(obj =>
                {

                    if (State is IdleRoleVM)
                    {
                        IdleRoleVM roleVM = (IdleRoleVM)State;
                        State = new EditRoleVM(null, this);
                    }

                });
            }
        }
        public RelayCommand GoEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (State is IdleRoleVM)
                    {
                        IdleRoleVM roleVM = (IdleRoleVM)State;
                        if (roleVM.Selected != null)
                        {
                            State = new EditRoleVM(roleVM.Selected, this);
                        }
                    }
                });
            }
        }
        public RelayCommand GoRemove => new RelayCommand(obj =>
        {
            if (State is IdleRoleVM)
            {
                IdleRoleVM roleVM = (IdleRoleVM)State;
                if (roleVM.Selected != null)
                {
                    State = new RemoveRoleVM(roleVM.Selected, this);
                }
            }

        });


        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new IdleRoleVM();
                });
            }
        }


    }
}
