using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

using RecruitmentExchange.View;


namespace RecruitmentExchange.ViewModel
{
    class MainViewModel 
    {
        UserControl companyView = new TabContentView(new CompanyVM());
        UserControl roleView = new TabContentView(new RoleVM());
        UserControl vacancyView = new TabContentView(new VacancyVM());
        UserControl applicantView = new TabContentView(new AplicantVM());
        UserControl dealView = new TabContentView(new DealVM());
        public UserControl CompanyView { get { return companyView; } }
        public UserControl RoleView { get { return roleView; } }
        public UserControl VacancyView { get { return vacancyView; } }
        public UserControl ApplicantView { get { return applicantView; } }
        public UserControl DealView { get { return dealView; } }
    }
}
