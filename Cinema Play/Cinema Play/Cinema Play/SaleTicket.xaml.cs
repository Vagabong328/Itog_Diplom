using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
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
    /// Логика взаимодействия для SaleTicket.xaml
    /// </summary>
    public partial class SaleTicket : Window
    {
        public SaleTicket()
        {
            InitializeComponent();
        }
        SeansiLinqDataContext sea = new SeansiLinqDataContext();
        TicketLinqDataContext tic = new TicketLinqDataContext();

        private void SaleTicket_loaded(object sender, RoutedEventArgs e)
        {
            Charge_load();
        }

        private void Charge_load()
        {
            var sean = from p in sea.Сеансы
                       select new
                       {
                           p.Код_сеанса,
                           p.Фильм,
                           p.Цена,
                           p.Дата,
                           p.Время,
                           p.Зал
                       };
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
            Cashiers c = new Cashiers();
            c.Show();
        }
        //Кнопка поиска нужного сеанса и автозаполнения необходимых текстбоксов
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
                MessageBox.Show("Введите нужный вам сеанс");

        }
        //Вычесление сдачи
        private void Surrender_Click(object sender, RoutedEventArgs e)

        {

            if ((Get.Text != "") & (Price.Text != "")) //Проверяем заполнены ли поля цены билета и получения средств от посетителя
            {
                if (Convert.ToInt32(Get.Text) >= Convert.ToInt32(Price.Text)) //Проверяем, чтобы цена была меньше или равна полученным средствам
                {
                    //Производим обычное арифметическое действие вычитания для получения результата о сдаче
                    int i = Convert.ToInt32(Price.Text);
                    int g = Convert.ToInt32(Get.Text);
                    int d = g - i;
                    Sur.Text = d.ToString(); //Присваеваем значение сдачи текстбоксу 
                }
                else
                    MessageBox.Show("Сумма денежных средств меньше цены фильма");
            }
            else
                MessageBox.Show("Введите сумму получения денежных средств");
        }
        //кнопка создания нового билета
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if ((IdBox.Text != "") & (Film.Text != "") & (Price.Text != "") & (Time.Text != "") & (Hall.Text != "") & (Row.Text != "") & (Place.Text != ""))
            {
                Продажа_билета p = new Продажа_билета
                {
                    Код_сеанса = Convert.ToInt32(IdBox.Text),
                    Название_фильма = Film.Text,
                    Цена = Price.Text,
                    Дата = (DateTime)Date.SelectedDate,
                    Время = Time.Text,
                    Название_зала = Hall.Text,
                    Ряд = Row.Text,
                    Место = Place.Text,
                    


                };
                tic.Продажа_билета.InsertOnSubmit(p);
                tic.SubmitChanges();
                Charge_load();
            }
            else
                MessageBox.Show("Заполните все поля");

        PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                FlowDocument flowDocument = new FlowDocument();
                flowDocument.PagePadding = new Thickness(50);
                flowDocument.Blocks.Add(new Paragraph(new Run(Film.Text)));
                flowDocument.Blocks.Add(new Paragraph(new Run(Price.Text)));
                flowDocument.Blocks.Add(new Paragraph(new Run(Time.Text)));
                flowDocument.Blocks.Add(new Paragraph(new Run(Hall.Text)));
                flowDocument.Blocks.Add(new Paragraph(new Run(Row.Text)));
                flowDocument.Blocks.Add(new Paragraph(new Run(Place.Text)));

                printDialog.PrintDocument((((IDocumentPaginatorSource)flowDocument).DocumentPaginator), "Печать билета");
            }

        }
    }
}