using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Practical.User
{
    public partial class UsersAdd : Window
    {
        dbEntities db = new dbEntities();

        public UsersAdd()
        {
            InitializeComponent();

            Emp_combo.DataContext = db.Employees.ToList();
            Role_combo.DataContext = db.Roles_users.ToList();
        }

        private void AddUsers_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();

            byte[] passtohash = Encoding.UTF8.GetBytes(PassBoxPassword.Password.ToString());

            users.login = TextBoxLogin.Text;
            users.password = HashPassword(passtohash);
            users.fk_emp = (int)Emp_combo.SelectedValue;
            users.fk_role = (int)Role_combo.SelectedValue;

            db.Users.Add(users);

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
