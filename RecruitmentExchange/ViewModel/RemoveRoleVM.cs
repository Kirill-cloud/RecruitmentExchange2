using Microsoft.EntityFrameworkCore;
using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class RemoveRoleVM : TabContentBase
    {
        public override string TabName { get; set; } = "Удаление роли";

        Role role;
        RoleVM origin;

        public int ApplicantCount { get; set; }
        public int VacancyCount { get; set; }

        public RemoveRoleVM(Role role, RoleVM Origin)
        {
            origin = Origin;
            this.role = role;
            TabName += role.Name;

            ApplicantCount = role.Applicants.Count;
            VacancyCount = role.Vacancies.Count;
        }

        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    DBMethods db = new();
                    await db.RemoveRole(role);

                    origin.Cancel.Execute(null);
                });
            }
        }
    }
}
