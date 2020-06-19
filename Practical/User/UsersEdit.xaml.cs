using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Practical.User
{
    public partial class UsersEdit : Window
    {
        dbEntities db = new dbEntities();

        private Users users = new Users();

        public UsersEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Load()
        {
            users = db.Users.Find(ClassID.id_user);
             
            Emp_combo.ItemsSource = db.Employees.ToList();
            Role_combo.ItemsSource = db.Roles_users.ToList();

            TextBoxLogin.Text = users.login;
            ClassID.password = PassBoxPassword.Text = users.password;
            Emp_combo.SelectedValue = users.fk_emp;
            Role_combo.SelectedValue = users.fk_role;
        }

        private void EditUsers_Click(object sender, RoutedEventArgs e)
        {
            if (!(ClassID.password == PassBoxPassword.Text))
            {
                byte[] passtohash = Encoding.UTF8.GetBytes(PassBoxPassword.Text.ToString());
                users.password = HashPassword(passtohash);
            }
            else
                users.password = PassBoxPassword.Text;

            users.login = TextBoxLogin.Text;
            users.fk_emp = (int)Emp_combo.SelectedValue;
            users.fk_role = (int)Role_combo.SelectedValue;

            db.SaveChanges();

            this.Close();
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
