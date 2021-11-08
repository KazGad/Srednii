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

            var allTypes = SISEntities.GetContext().Type.ToList();
            allTypes.Insert(0, new Type
            {
                Name = "Все типы"
            });
            CType.ItemsSource = allTypes;

            CheckActual.IsChecked = true;
            CType.SelectedIndex = 0;

            UpdateTours();
        }

        private void UpdateTours()
        {
            var currentTours = SISEntities.GetContext().Tour.ToList();

            if (CType.SelectedIndex > 0)
                currentTours = currentTours.Where(p => p.Type.Contains(CType.SelectedItem as Type)).ToList();

            currentTours = currentTours.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CheckActual.IsChecked.Value)
                currentTours = currentTours.Where(p => p.IsActual).ToList();

            LViewTour.ItemsSource = currentTours.OrderBy(p => p.TicketCount).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }

        private void CActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }
    }
}
