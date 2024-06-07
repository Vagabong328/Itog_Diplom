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
using System.Data.SqlClient;

namespace Cinema_Play
{
    /// <summary>
    /// Логика взаимодействия для Seansi.xaml
    /// </summary>
    public partial class Seansi : Window
    {
        public Seansi()
        {
            InitializeComponent();
        }
        SeansiLinqDataContext sea = new SeansiLinqDataContext();

        private void Seansi_Loaded(object sender, RoutedEventArgs e)
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if ((IdBox.Text != "") & (Film.Text != "") & (Price.Text != "") & (Time.Text != "") & (Hall.Text != ""))
            {
                Сеансы n = new Сеансы
                {
                    Код_сеанса = Convert.ToInt32(IdBox.Text),
                    Фильм = Film.Text,
                    Цена = Price.Text,
                    Дата = (DateTime)Date.SelectedDate,
                    Время = Time.Text,
                    Зал = Convert.ToInt32(Hall.Text)
                };
                sea.Сеансы.InsertOnSubmit(n);
                sea.SubmitChanges();
                Charge_load();
            }
            else 
                MessageBox.Show("Заполните все поля");

            }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (IdBox.Text != "")
            {
                var n = sea.Сеансы.Single(x => x.Код_сеанса == Convert.ToInt32(IdBox.Text));
                sea.Сеансы.DeleteOnSubmit(n);
                sea.SubmitChanges();
                Charge_load();
            }
            else
                MessageBox.Show("Укажите номер сеанса, который необходимо удалить");
        }

        private void Upp_Click(object sender, RoutedEventArgs e)
        {
            if ((IdBox.Text != "") & (Film.Text != "") & (Price.Text != "") & (Time.Text != "") & (Hall.Text != ""))
            {
                var n = sea.Сеансы.Single(x => x.Код_сеанса == Convert.ToInt32(IdBox.Text));

                n.Фильм = Film.Text;
                n.Цена = Price.Text;
                n.Дата = (DateTime)Date.SelectedDate;
                n.Время = Time.Text;
                n.Зал = Convert.ToInt32(Hall.Text);
                sea.SubmitChanges();
                Charge_load();
            }
            else
                MessageBox.Show("Заполните все поля");

        }

        private void DataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            
            if (IdBox.Text != "")

            {
                var per = sea.Сеансы.SingleOrDefault(x => x.Код_сеанса == Convert.ToInt32(IdBox.Text));
                if (per != null)
                { 
                Film.Text = per.Фильм;
                Price.Text = per.Цена;
                Date.SelectedDate = per.Дата;
                Time.Text = per.Время;
                Hall.Text = per.Зал.ToString();
                }
            else
                MessageBox.Show("Такого сеанса не существет");
            }
            else
                MessageBox.Show ("Введите нужный вам сеанс");
            
        }

        private void Searchh_TextChanged(object sender, TextChangedEventArgs e)
        {
            Charge_load();
        }

        private void GridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

