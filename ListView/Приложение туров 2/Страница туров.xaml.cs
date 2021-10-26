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
    /// Логика взаимодействия для Страница_туров.xaml
    /// </summary>
    public partial class Страница_туров : Page
    {
        public Страница_туров()
        {
            InitializeComponent();
            var currentTours = SISEntities.GetContext().Tour.ToList();
            LViewTour.ItemsSource = currentTours;
        }
    }
}
