using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;

namespace RecruitmentExchange.ViewModel
{
    public class EditRoleVM : TabViewBase
    {
        public override string TabName { get; set; } = "Редактирование Роли ";

        public string Name { get; set; }

        private readonly Role role;
        private readonly RoleVM Origin;

        public EditRoleVM(Role role, RoleVM Origin)
        {
            this.role = role;
            this.Origin = Origin;

            if (role != null)
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

                        Origin.LoadGridAsync();
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
        private bool IsValid()
        {
            Validate();

            return (errors.Count == 0);
        }
        void Validate()
        {
            errors.Clear();

            if (Name == null || Name == "")
            {
                errors.Add("Name", new List<string>() { "empty" });
            }

            RaiseErrorsChanged(nameof(Name));
        }
    }
}