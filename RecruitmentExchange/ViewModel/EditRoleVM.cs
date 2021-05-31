using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    public class EditRoleVM : TabContentBase
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
                return new RelayCommand(async (obj) =>
                {
                    if (IsValid())
                    {
                        BoundRole();

                        if (role.Id != 0)
                        {
                            await Edit();
                        }
                        else
                        {
                            await Add();
                        }

                        Origin.Cancel.Execute(null);

                    }
                });
            }
        }
        async Task Add()
        {
            DBMethods db = new();
            await db.AddRole(role);
        }
        async Task Edit()
        {
            DBMethods db = new();
            await db.EditRole(role);
        }
        private void BoundRole()
        {
            role.Name = Name;
        }
        private bool IsValid()
        {
            Validate();

            return (Errors.Count == 0);
        }
        public void Validate()
        {
            Errors.Clear();

            if (Name == null || Name == "")
            {
                Errors.Add("Name", new List<string>() { "empty" });
            }

            RaiseErrorsChanged(nameof(Name));
        }
    }
}