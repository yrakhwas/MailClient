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

namespace MailClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Credentials credentials;
        public Window1()
        {
            InitializeComponent();
            credentials = new Credentials();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            credentials.Password =  PassForm.Password;
            credentials.Login = EmailForm.Text;
            MainWindow mainWindow = new MainWindow(credentials);
            mainWindow.Show();
            this.Close();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
