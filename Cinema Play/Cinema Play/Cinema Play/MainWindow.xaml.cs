using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;
using System.Runtime.Remoting.Contexts;

namespace Cinema_Play
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Login.Text != "") && (Password.Password != ""))
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=10.179.100.5;Initial Catalog=CinemaPlayBD;User Id=gitea;Password=Pa$$word;");
                sqlcon.Open();
                string cmdStr = "Select Логин, Пароль, Должность FROM dbo.Сотрудники WHERE (Логин = '" + Login.Text + "') AND (Пароль = '" + Password.Password + "');";
                SqlCommand cmd = new SqlCommand(cmdStr, sqlcon);
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteScalar() != null)
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    this.Hide();
                    string Role = reader["Должность"].ToString().TrimEnd();

                    switch (Role)

                    {
                        case "Admin":
                            Admin Admin = new Admin();
                            Admin.Show();
                            this.Hide();
                            break;
                        case "Cashier":
                            Cashiers Cashier = new Cashiers();
                            Cashier.Show();
                            this.Hide();
                            break;
                        case "Dispetcher":
                            CheckSeans Dispet = new CheckSeans();
                            Dispet.Show();
                            this.Hide();
                            break;
                    }
                    Login.Clear();
                    Password.Clear();
                    sqlcon.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");

                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}