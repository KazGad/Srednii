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

namespace Приложение_туров_2
{
    /// <summary>
    /// Логика взаимодействия для Отели.xaml
    /// </summary>
    public partial class Отели : Page
    {
        public Отели()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = SISEntities.GetContext().Hotel.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Мэнеджер.MainFrame.Navigate(new Тестирование_и_навигация());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
