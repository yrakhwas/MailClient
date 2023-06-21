using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Net.Mail;
using System.Xml.Linq;

namespace MailClient
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        NewMassege newMassege;
        private Credentials _credentials;
        public Window2()
        {
            InitializeComponent();
            
        }
        public Window2(Credentials credentials)
        {
            InitializeComponent();
            _credentials = credentials;
        }

        private void SentBTN_Click(object sender, RoutedEventArgs e)
        {
            //newMassege.to = TotxtBx.Text;
            //newMassege.theme = ThemeTxtBx.Text;
            //newMassege.text = textTxtBx.Text;
            bool isImportant;
            string myEmail = _credentials.Login;
            string myPassword = _credentials.Password;  
            string toEmail = TotxtBx.Text;
            string theme = ThemeTxtBx.Text;
            string body = textTxtBx.Text;
            if (ImporChBx.IsChecked == true)
            {
               isImportant= true;
            }
            else
               isImportant = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(myEmail);
                mail.To.Add(new MailAddress(toEmail));
                mail.Subject = theme;
                mail.Body = body;

                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(myEmail, myPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);

                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }


        }
    }
}
