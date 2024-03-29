﻿using Microsoft.Win32;
using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Search;

namespace MailClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Credentials _credentials;
        
        public MainWindow()
        {
            InitializeComponent();
             
        }
        public MainWindow(Credentials credentials)
        {
            InitializeComponent();
            _credentials = credentials;

            //string login = _credentials.Login;
            //string password = _credentials.Password;
        }

        private void IncomingM_Click(object sender, RoutedEventArgs e)
        {
            string server = "imap.gmail.com";
            int port = 993;
            bool useSsl = true;
            string username = _credentials.Login;// "yrakhwas@gmail.com";
            string password = _credentials.Password;  //"avhejlprpqzoljry";

           
            using (var client = new ImapClient())
            {
                // Підключення до сервера IMAP
                client.Connect(server, port, useSsl);

                // Аутентифікація
                client.Authenticate(username, password);

                // Вибір скриньки (наприклад, "Inbox")
                client.Inbox.Open(FolderAccess.ReadOnly);

                // Отримання повідомлень
                var query = SearchQuery.All;
                var uids = client.Inbox.Search(query);

                StringBuilder stringBuilder = new StringBuilder();

                foreach (var uid in uids)
                {
                    var message = client.Inbox.GetMessage(uid);

                    // Обробка повідомлення
                    string subject = message.Subject;
                    string from = message.From.ToString();
                    string body = message.TextBody;

                    // Додавання інформації про повідомлення до StringBuilder
                    stringBuilder.AppendLine("Subject: " + subject);
                    stringBuilder.AppendLine("From: " + from);
                    stringBuilder.AppendLine("Body: " + body);
                    stringBuilder.AppendLine("-----------------------");
                }

                // Присвоєння зібраного тексту до TextBlock.Text
                textBlock.Text = stringBuilder.ToString();
                // Відключення від сервера
                client.Disconnect(true);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Window2 window2 = new Window2(_credentials);
            window2.Show();
        }
    }
}
