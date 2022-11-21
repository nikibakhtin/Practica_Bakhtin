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

namespace Practica
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
       private Client _currentClient = new Client();

        public AddEditPage(Client SelectClient)
        {
            InitializeComponent();
            if (SelectClient != null) 
            {
                _currentClient = SelectClient;
            }
        
            DataContext = _currentClient;
            Combogender.ItemsSource = pro4Entities.GetContext().Gender.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentClient.FirstName))
               
                errors.AppendLine("Укажите ваше Имя");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClient.ID == 0)
                pro4Entities.GetContext().Client.Add(_currentClient);

            try
            {
                pro4Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена успешно");
                NavigationService.Navigate(new ClientView());
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
    }
    }
}
