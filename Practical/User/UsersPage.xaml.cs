using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.User
{
    public partial class UsersPage : Page
    {
        dbEntities db = new dbEntities();

        public UsersPage()
        {
            InitializeComponent();

            Query();
        }

        private void Query()
        {
            var query =
               from Users in db.Users
               join Roles_users in db.Roles_users on Users.fk_role equals Roles_users.id_role_user
               join Employees in db.Employees on Users.fk_emp equals Employees.id_employee
               select new { Users.id_user, Users.login, fk_emp = Employees.lname + " " + Employees.fname + " " + Employees.mname, fk_role = Roles_users.name };

            UsersGrid.ItemsSource = query.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            UsersAdd usersAdd = new UsersAdd();

            usersAdd.ShowDialog();

            Query();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedCells.Count > 0)
            {
                UsersEdit usersEdit = new UsersEdit();

                usersEdit.ShowDialog();

                Query();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedCells.Count > 0)
            {
                Users users = db.Users.Find(ClassID.id_user);

                db.Users.Remove(users);

                db.SaveChanges();

                Query();
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
           DataGridRow row = sender as DataGridRow;
            
           TextBlock tbl = UsersGrid.Columns[0].GetCellContent(row) as TextBlock;
           if (!string.IsNullOrEmpty(tbl.Text))
           {
                ClassID.id_user = Convert.ToInt32(tbl.Text);
           }
        }
    }
}
