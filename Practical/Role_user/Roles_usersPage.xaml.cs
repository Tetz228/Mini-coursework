using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Role_user
{
    public partial class Roles_usersPage : Page
    {
        dbEntities db = new dbEntities();

        public Roles_usersPage()
        {
            InitializeComponent();

            RoleGrid.ItemsSource = db.Roles_users.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Roles_usersAdd roles_UsersAdd = new Roles_usersAdd();

            roles_UsersAdd.ShowDialog();

            RoleGrid.ItemsSource = db.Roles_users.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedCells.Count > 0)
            {
                Roles_usersEdit roles_UsersEdit = new Roles_usersEdit();

                var id = (RoleGrid.SelectedItem as Roles_users).id_role_user;

                ClassID.id_role_user = id;

                roles_UsersEdit.ShowDialog();

                RoleGrid.ItemsSource = db.Roles_users.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedCells.Count > 0)
            {
                var id = (RoleGrid.SelectedItem as Roles_users).id_role_user;

                Roles_users roles_Users = db.Roles_users.Find(id);

                db.Roles_users.Remove(roles_Users);

                db.SaveChanges();

                RoleGrid.ItemsSource = db.Roles_users.ToList();
            }
        }
    }
}
