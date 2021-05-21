using RecruitmentExchange.Model;
using System.Collections.Generic;

namespace RecruitmentExchange.ViewModel
{
    internal class EditVacancyVM : TabViewBase
    {
        public override string TabName { get; set; } = "Редактор вакансии";

        public List<Role> Roles { get; set; }
        public List<Company> Companies{ get; set; }

        public Role SelectedRole { get; set; }
        public Company SelectedCompany { get; set; }

    }
}