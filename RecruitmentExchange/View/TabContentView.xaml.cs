using RecruitmentExchange.ViewModel;
using System.Windows.Controls;

namespace RecruitmentExchange.View
{
    /// <summary>
    /// Логика взаимодействия для CompanyView.xaml
    /// </summary>
    public partial class TabContentView : UserControl
    {
        public TabContentView(TabViewBase context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
