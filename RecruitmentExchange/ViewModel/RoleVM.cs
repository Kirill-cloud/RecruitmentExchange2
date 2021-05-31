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
            Cancel.Execute(null);
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

        public RelayCommand GoRemove => new RelayCommand(async obj =>
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
                return new RelayCommand(async obj =>
                {
                    IsLoading = true;
                    State = new LoadingVM();

                    DBMethods db = new();
                    State = new IdleRoleVM(await db.GetAllRoles());

                    IsLoading = false;
                });
            }
        }

        public bool IsLoading { get; private set; }
    }
}
