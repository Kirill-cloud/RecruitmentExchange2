using System.Windows;

using RecruitmentExchange.ViewModel;

namespace RecruitmentExchange.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewCompanyWindow.xaml
    /// </summary>
    public partial class AddNewCompanyWindow : Window
    {
        public AddNewCompanyWindow()
        {
            InitializeComponent();
            DataContext = new EditCompanyVM(this);
        }

    }
}
