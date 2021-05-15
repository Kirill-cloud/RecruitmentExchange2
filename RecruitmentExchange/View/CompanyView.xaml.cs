using RecruitmentExchange.ViewModel;
using System.Windows.Controls;

namespace RecruitmentExchange.View
{
    /// <summary>
    /// Логика взаимодействия для CompanyView.xaml
    /// </summary>
    public partial class CompanyView : UserControl
    {
        public CompanyView()
        {
            InitializeComponent();
            DataContext = new CompanyVM();
        }
    }
}
