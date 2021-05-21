using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;

namespace RecruitmentExchange.ViewModel
{
    public class EditRoleVM : TabViewBase
    {
        public override string TabName { get; set; } = "Редактирование Роли ";

        public string Name { get; set; }

        private Role role;
        private RoleVM Origin;

        public EditRoleVM(Role role, RoleVM Origin)
        {
            this.role = role;
            this.Origin = Origin;

            if (role!= null)
            {
                Name = role.Name;
                TabName += role.Name;
            }
            else
            {
                this.role = new Role();
                TabName = "Создание роли";
            }
        }
        public RelayCommand AddOrEdit
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    if (IsValid())
                    {
                        BoundRole();

                        if (role.Id != 0)
                        {
                            Edit();
                        }
                        else
                        {
                            Add();
                        }

                        Origin.State = Origin;
                        Origin.Selected = null;

                    }
                });
            }
        }

        private void Add()
        {
            DBMethods db = new();
            db.AddRole(role);
        }

        private void Edit()
        {
            DBMethods db = new();
            db.EditRole(role);
        }

        private void BoundRole()
        {
            role.Name = Name;
        }

        bool IsValid()
        {
            return true;
        }

    }
}