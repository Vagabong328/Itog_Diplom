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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
        }
        UserLinqDataContext us = new UserLinqDataContext();

        private void User_loaded(object sender, RoutedEventArgs e)
        {
            Charge_load();
        }

        private void Charge_load()
        {
            var user = from p in us.Сотрудники
                       where p.ФИО.Contains(Searchh.Text) //Поиск по фамилии
                       select new
                       {
                           p.Код_сотрудника,
                           p.ФИО,
                           p.Логин,
                           p.Пароль,
                           p.Должность,
                           p.Телефон,
                           p.Почта,
                           p.Дата_трудоустройства,
                           p.Оклад,
                           p.Адрес,
                       };
            GridView1.ItemsSource = user;
        }

        private void Logout_Click2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow w = new MainWindow();
            w.Show();
        }

        private void Back_Click1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin a = new Admin();
            a.Show();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            if (IdUser.Text != "")

            {
                var per = us.Сотрудники.SingleOrDefault(x => x.Код_сотрудника == Convert.ToInt32(IdUser.Text));
                if (per != null)
                {
                    FIO.Text = per.ФИО;
                    Login.Text = per.Логин;
                    Password.Text = per.Пароль;
                    Role.Text = per.Должность;
                    Phone.Text = per.Телефон;
                    Email.Text = per.Почта;
                    Date.SelectedDate = per.Дата_трудоустройства;
                    Cash.Text = per.Оклад;
                    Adres.Text = per.Адрес;
                }
                else
                    MessageBox.Show("Такого кода сорудника не существет");
            }
            else
                MessageBox.Show("Введите код нужного вам сотрудника");

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Сотрудники n = new Сотрудники
            {
                Код_сотрудника = Convert.ToInt32(IdUser.Text),
                ФИО = FIO.Text,
                Логин = Login.Text,
                Пароль = Password.Text,
                Должность = Role.Text,
                Телефон = Phone.Text,
                Почта = Email.Text,
                Дата_трудоустройства = (DateTime)Date.SelectedDate,
                Оклад = Cash.Text,
             Адрес = Adres.Text
        };
            us.Сотрудники.InsertOnSubmit(n);
            us.SubmitChanges();
            Charge_load();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var n = us.Сотрудники.Single(x => x.Код_сотрудника == Convert.ToInt32(IdUser.Text));
            us.Сотрудники.DeleteOnSubmit(n);
            us.SubmitChanges();
            Charge_load();
        }

        private void Upp_Click(object sender, RoutedEventArgs e)
        {
            var n = us.Сотрудники.Single(x => x.Код_сотрудника == Convert.ToInt32(IdUser.Text));
            n.ФИО = FIO.Text;
            n.Логин = Login.Text;
            n.Пароль = Password.Text;
            n.Должность = Role.Text;
            n.Телефон = Phone.Text;
            n.Почта = Email.Text;
            n.Дата_трудоустройства = (DateTime)Date.SelectedDate;
            n.Оклад = Cash.Text;
            n.Адрес = Adres.Text;
            us.SubmitChanges();
            Charge_load();
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
