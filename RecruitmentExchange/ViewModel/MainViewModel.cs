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
        UserControl companyView = new CompanyView();
        UserControl roleView;
        UserControl vacancyView;
        UserControl applicantView;
        UserControl dealView;
        public UserControl CompanyView { get { return companyView; } }
        public UserControl RoleView;
        public UserControl VacancyView;
        public UserControl ApplicantView;
        public UserControl DealView;

        //скорее всего не нужно 
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
