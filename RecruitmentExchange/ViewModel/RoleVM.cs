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

        //public RoleVM()
        //{
        //    state = new IdleRole() { DataContext = this };
        //}
        //public List<Role> Roles { get { return DBMethods.GetAllRoles(); } }


        //public Role Selected { get; set; }
        //public string Name { get; set; }


        //public override RelayCommand GoAdd => new RelayCommand(obj =>
        //{
        //    State = new AddRole() { DataContext = this };
        //});

        //public override RelayCommand Add => new RelayCommand(obj =>
        //{
        //    var newrole = new Role() { Name = Name };
        //    DBMethods.AddRole(newrole);
        //    State = new IdleRole();
        //});

        //public int VacancyCount { get; set; }
        //public int ApplicantCount { get; set; }

        //public override RelayCommand GoRemove => new RelayCommand(obj =>
        //{
        //    if (Selected != null)
        //    {
        //        ApplicantCount = DBMethods.GetAllApplicants().Where(x => x.Role.Id == Selected.Id).Count();
        //        VacancyCount = DBMethods.GetAllVacancies().Where(x => x.Role.Id == Selected.Id).Count();

        //        State = new RemoveRole() { DataContext = this };
        //    }
        //});
        //public override RelayCommand Remove => new RelayCommand(async obj =>
        //{
        //    await DBMethods.RemoveRole(Selected);

        //    State = new IdleRole() { DataContext = this };

        //    Selected = null;
        //});
        //public RelayCommand GoEdit => new RelayCommand(obj =>
        //{
        //    if (Selected != null)
        //    {
        //        State = new EditRole() { DataContext = this };
        //    }
        //});
        //public RelayCommand Edit => new RelayCommand(async obj =>
        //{
        //    var editedRole = new Role() { Id = Selected.Id, Name = Name };
        //    await DBMethods.EditRole(editedRole);

        //    State = new IdleRole() { DataContext = this };

        //    Selected = null;
        //});


    }
}
