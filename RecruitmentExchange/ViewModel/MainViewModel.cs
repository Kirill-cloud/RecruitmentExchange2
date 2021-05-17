using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

using RecruitmentExchange.View;


namespace RecruitmentExchange.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        UserControl companyView = new TabContentView(new CompanyVM());
        UserControl roleView = new TabContentView(new RoleVM());
        UserControl vacancyView = new TabContentView(new VacancyVM());

        UserControl applicantView = new TabContentView(new RoleVM());
        UserControl dealView = new TabContentView(new RoleVM());
        public UserControl CompanyView { get { return companyView; } }
        public UserControl RoleView { get { return roleView; } }
        public UserControl VacancyView { get { return vacancyView; } }
        public UserControl ApplicantView { get { return applicantView; } }
        public UserControl DealView { get { return dealView; } }

        //скорее всего не нужно 
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
