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

namespace Practice_14
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            passwordInput.Focus();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (passwordInput.Password == "123")
            {
                Close();
            }
            else MessageBox.Show("Неверный пароль! Повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Owner.Close();
        }
    }
}
