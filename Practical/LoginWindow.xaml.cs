using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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

namespace Practical
{
    public partial class LoginWindow : Window
    {
        dbEntities db = new dbEntities();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLog.Text) || string.IsNullOrEmpty(PassBox.Password))
            {
                MessageBox.Show("Введите логин и пароль.");
            }
            else
            {
                byte[] passtohash = Encoding.UTF8.GetBytes(PassBox.Password.ToString());

                string pass = HashPassword(passtohash);

                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.login == TextBoxLog.Text && u.password == pass);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    this.Close();
                }
            }
        }

        // Хеширование пароля
        private string HashPassword(byte[] val)
        {
            using (SHA512Managed sha512 = new SHA512Managed())
            {
                var hash = sha512.ComputeHash(val);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
