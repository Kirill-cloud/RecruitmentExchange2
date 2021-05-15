using RecruitmentExchange.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecruitmentExchange.View
{
    /// <summary>
    /// Логика взаимодействия для AddAplicantControl.xaml
    /// </summary>
    public partial class AddAplicantControl : UserControl
    {
        public AddAplicantControl()
        {
            InitializeComponent();
            
           // DataContext = Application.Current.MainWindow.DataContext;
        }
    }
}
