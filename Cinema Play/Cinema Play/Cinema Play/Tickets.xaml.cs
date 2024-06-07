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
    /// Логика взаимодействия для Tickets.xaml
    /// </summary>
    public partial class Tickets : Window
    {
        public Tickets()
        {
            InitializeComponent();
        }
        TicketLinqDataContext tic = new TicketLinqDataContext();

        private void Tickets_loaded(object sender, RoutedEventArgs e)
        {
            Charge_load();
        }
        private void Charge_load()
        {
            var tick = from p in tic.Продажа_билета
                       where p.Название_фильма.Contains(SearchFilms.Text)
                       select new
                       {
                           p.Код_билета,
                           p.Код_сеанса,
                           p.Название_зала,
                           p.Название_фильма,
                           p.Дата,
                           p.Время,
                           p.Место,
                           p.Ряд,
                           p.Цена,
                       };
            GridView1.ItemsSource = tick;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow w = new MainWindow();
            w.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }
        private void SearchFilms_TextChanged(object sender, TextChangedEventArgs e)
        {
            Charge_load();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
