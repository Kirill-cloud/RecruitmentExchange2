using RecruitmentExchange.AppData;
using RecruitmentExchange.Model;
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

namespace Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Do();
        }
        Random r = new Random((int)DateTime.Now.Ticks);
        async void Do()
        {
            DBMethods db = new();
            foreach (var item in Roles)
            {
                await db.AddRole(new Role() { Name = item });
            }
            for (int i = 0; i < 100; i++)
            {
                await db.AddCompany(new Company
                {
                    Name = CompanyNames[r.Next(CompanyNames.Count)],
                    FocusedOn = Fields[r.Next(Fields.Count)],
                    Address = Addresses[r.Next(Addresses.Count)],
                    Phone = RandomPhone
                });
            }

            var x = await db.GetAllRoles();

            for (int i = 0; i < 100; i++)
            {
                await db.AddApplicant(new Applicant()
                {
                    Name = Names[r.Next(Names.Count)] + " " + Surnames[r.Next(Surnames.Count)],
                    Role = x[r.Next(x.Count)],
                    Salary = r.Next(50000),
                    Description = " ",
                    IsActive = true,
                }); ; ; ;
            }

            var y = await db.GetAllCompanies();
            foreach (var item in y)
            {
                Role temp = x[r.Next(x.Count)];
                await db.AddVacany(new Vacancy()
                {
                    Company = item,
                    Role = temp,
                    Description = temp.Name + " " + r.Next(81)+ "уровня",
                }); ;;
                
                temp = x[r.Next(x.Count)];
                await db.AddVacany(new Vacancy()
                {
                    Company = item,
                    Role = temp,
                    Description = temp.Name + " " + r.Next(81) + "уровня",
                }); ; ;
            }


            MessageBox.Show("Done");
        }

        List<String> Roles = new()
        {
            "Разнорабочий",
            "Аналитик",
            "Кузнец",
            "Музыкант",
            "Разработчик",
            "Тестировщик",
            "Кассир",
            "Администратор",
            "Хостес",
            "Бариста",
        };

        List<String> CompanyNames = new()
        {
            "Intel",
            "AMD",
            "NVidia",
            "Google",
            "Amazon",
            "MSI",
            "Asus",
            "Лукойл",
            "Сургутнефтьгаз",
            "X5 Retail Group",
            "Магнит",
            "Татнефть",
            "Норникель",
            "Новатэк",
            "Evraz",
            "Мегаполис",
            "NMLK",
            "UC Rusal",
        };

        List<String> Names = new()
        {
            "Лев",
            "Василий",
            "Эдуард",
            "Марина",
            "Юлия",
            "Анастасия",
            "Людмила",
            "Евгений",
            "Алексей",
            "Кристина",
            "Семён",
            "Владимир",
            "Михаил",
            "Зинаида",
            "Николай",
            "Ирина",
            "Елена",
            "Андрей",
            "Наталия",
            "John",
            "Michael",
            "Paul",
            "George",
            "Gregory",
            "Hugh",
            "Donald",
        };

        List<String> Surnames = new()
        {
            "House",
            "Trunm",
            "Jackson",
            "Kadi",
            "McCartney",
            "Harrisson",
            "Lebowski",
            "Морозов",
            "Петров",
            "Смирнов",
            "Бойнов",
            "Иванов",
            "Кузнецов",
            "Соколов",
            "Никитин",
            "Зайцев",
            "Белоусов",
            "Рыбокоп",
            "Савельев",
            "Фёдоров",
        };

        List<String> Fields = new()
        {
            "It",
            "Услуги",
            "Промышленость",
            "Машиностроение",
            "Радиоэлектроника",
        };

        List<String> Addresses = new()
        {
            "238043, г. Калиновка, ул. Камышенский 8-й пер, дом 147, квартира 909",
            "243083, г. Маркс, ул. Ашхабадская, дом 6, квартира 667",
            "663125, г. Черняховск, ул. Планировочная, дом 24, квартира 136",
            "633355, г. Коркино, ул. Лучевой 3-й просек, дом 71, квартира 224",
            "446018, г. Кушнаренково, ул. Институтская 3-я, дом 6, квартира 883",
            "9620 Towne Centre Drive, Suite 250",
            "Santa Clara, CA 95054-1549",
            "2788 San Tomas Expressway Santa Clara,CA 95051",
        };

        String RandomPhone
        {
            get
            {
                return "+" + r.Next(10000, 99999).ToString() + r.Next(10000, 99999).ToString();
            }
        }

    }
}
