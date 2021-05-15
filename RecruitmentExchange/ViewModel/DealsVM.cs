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
    public class DealsVM : INotifyPropertyChanged
    {
        UserControl dealsContent = new ApplicantControl();
        public UserControl DealsContent { get { return dealsContent; } private set { dealsContent = value; OnPropertyChanged("DealsContent"); } }

        public RelayCommand ShowDeals
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    DealsContent = new ApplicantControl();
                });
            }
        }
        public RelayCommand ShowAddDeals
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    DealsContent = new AddAplicantControl();
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
