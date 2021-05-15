using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
using RecruitmentExchange.View;
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
    public class CompanyVM : INotifyPropertyChanged
    {
        public CompanyVM()
        {
            state = new IdleCompanyView() { DataContext = this };
        }

        UserControl state;
        public UserControl State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        public List<Company> Companies { get { 
                return DBMethods.GetAllCompanies();
            } }
        public RelayCommand AddCompany
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    State = new AddCompany() {DataContext = this };
                });
            }
        }
        public RelayCommand Add
        {
            get
            {
                return new RelayCommand(obj => {

                    //add
                    State = new IdleCompanyView() { DataContext = this };
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
