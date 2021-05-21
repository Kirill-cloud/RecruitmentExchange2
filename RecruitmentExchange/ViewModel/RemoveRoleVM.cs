using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.ViewModel
{
    class RemoveRoleVM : TabViewBase
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

            ApplicantCount = DBMethods.GetAllApplicants().Where(x => x.Role.Id == role.Id).Count();
            VacancyCount = DBMethods.GetAllVacancies().Where(x => x.Role.Id == role.Id).Count();
        }
        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    DBMethods.RemoveRole(role);
                    origin.State = origin;
                    origin.Selected = null;
                });
            }
        }
    }
}
