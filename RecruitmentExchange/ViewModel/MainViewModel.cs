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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public TabViewBase SelectedTab { get; set; }
        private List<TabViewBase> tabsList=new List<TabViewBase>();

        public List<TabViewBase> TabsList
        {
            get { return tabsList; }
            set { tabsList = value; }
        }

        public MainViewModel()
        {
            tabsList.Add(new CompanyVM());
            tabsList.Add(new RoleVM());
            tabsList.Add(new VacancyVM());
            tabsList.Add(new ApplicantVM());
            tabsList.Add(new DealVM());
        }

    }
}
