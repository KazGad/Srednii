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
    /// Логика взаимодействия для Страница_Отелей.xaml
    /// </summary>
    public partial class Страница_Отелей : Page
    {
        public Страница_Отелей()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Мэнеджер.MainFrame.Navigate(new Тестирование_и_навигация());
        }

        private void Btn_Click_Picture(object sender, RoutedEventArgs e)
        {
            Мэнеджер.MainFrame.Navigate(new Картинки());
        }

        private void Btn_Click_Tests(object sender, RoutedEventArgs e)
        {
            Мэнеджер.MainFrame.Navigate(new Тесты());
        }
    }
}
