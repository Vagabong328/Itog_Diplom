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
using System.Windows.Shapes;

namespace Cinema_Play
{
    /// <summary>
    /// Логика взаимодействия для CheckSeans.xaml
    /// </summary>
    public partial class CheckSeans : Window
    {
        public CheckSeans()
        {
            InitializeComponent();
        }
        SeansiLinqDataContext sea = new SeansiLinqDataContext();

        private void Check_Loaded(object sender, RoutedEventArgs e)
        {
            Charge_load();
        }

        private void Charge_load()
        {
            var sean = from p in sea.Сеансы
                       where p.Фильм.Contains(Searchh.Text) //Поиск по фильму
                       select new
                       {
                           p.Код_сеанса,
                           p.Фильм,
                           p.Цена,
                           p.Дата,
                           p.Время,
                           p.Зал
                       };
            GridView1.ItemsSource = sean;
        }

        private void Searchh_TextChanged(object sender, TextChangedEventArgs e)
        {
            Charge_load();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow a = new MainWindow();
            a.Show();
        }
    }
}
