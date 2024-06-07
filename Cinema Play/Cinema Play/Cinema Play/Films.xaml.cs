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
    /// Логика взаимодействия для Films.xaml
    /// </summary>
    public partial class Films : Window
    {
        public Films()
        {
            InitializeComponent();
        }

        FilmsLinqDataContext flm = new FilmsLinqDataContext();

        private void Films_loaded(object sender, RoutedEventArgs e)
        {
            Charge_load();
        }
        private void Charge_load()
        {
            var film = from p in flm.Фильмы
                       where p.Название_фильма.Contains(Searchh.Text) //Поиск по названию фильма
                       select new
                       {
                           p.Название_фильма,
                           p.Производство_компанией,
                           p.Год_выпуска,
                           p.Жанр,
                           p.Длительность
                       };
            GridView1.ItemsSource = film;
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (NameFilm.Text != "")

            {
                var per = flm.Фильмы.SingleOrDefault(x => x.Название_фильма == NameFilm.Text);
                if (per != null)
                {
                    Company.Text = per.Производство_компанией;
                    Year.SelectedDate = per.Год_выпуска;
                    Category.Text = per.Жанр;
                    Time.Text = per.Длительность;
                }
                else
                    MessageBox.Show("Такого фильма не существет");
            }
            else
                MessageBox.Show("Введите нужный вам фильм");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Фильмы n = new Фильмы
            {
                Название_фильма = NameFilm.Text,
                Производство_компанией = Company.Text,
                Год_выпуска = (DateTime)Year.SelectedDate,
                Жанр = Category.Text,
                Длительность = Time.Text
            };
            flm.Фильмы.InsertOnSubmit(n);
            flm.SubmitChanges();
            Charge_load();
        }

        private void Upp_Click(object sender, RoutedEventArgs e)
        {
            var n = flm.Фильмы.Single(x => x.Название_фильма == NameFilm.Text);

            n.Производство_компанией = Company.Text;
            n.Год_выпуска = (DateTime)Year.SelectedDate;
            n.Жанр = Category.Text;
            n.Длительность = Time.Text;
            flm.SubmitChanges();
            Charge_load();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var n = flm.Фильмы.Single(x => x.Название_фильма == NameFilm.Text);
            flm.Фильмы.DeleteOnSubmit(n);
            flm.SubmitChanges();
            Charge_load();
        }

        private void Searchh_TextChanged(object sender, TextChangedEventArgs e)
        {
            Charge_load();
        }
    }
}
