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
            LoadRelatedDataAsync();
        }

        private async Task LoadRelatedDataAsync()
        {
            DBMethods db = new DBMethods();
            ApplicantCount = (await db.GetAllApplicants()).Where(x => x.Role.Id == role.Id).Count();
            VacancyCount = (await db.GetAllVacancies()).Where(x => x.Role.Id == role.Id).Count();
            OnPropertyChanged(nameof(ApplicantCount));
            OnPropertyChanged(nameof(VacancyCount));
        }

        public RelayCommand Remove
        {
            get
            {
                return new RelayCommand(async obj =>
                {
                    DBMethods db = new();
                    await db.RemoveRole(role);

                    origin.State = new IdleRoleVM();
                });
            }
        }
    }
}
