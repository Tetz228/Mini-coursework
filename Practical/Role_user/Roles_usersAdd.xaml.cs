using System.Windows;

namespace Practical.Role_user
{
    public partial class Roles_usersAdd : Window
    {
        dbEntities db = new dbEntities();

        public Roles_usersAdd()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Roles_users role_user = new Roles_users();

            role_user.name = TextBoxName.Text;

            db.Roles_users.Add(role_user);

            db.SaveChanges();

            this.Close();
        }
    }
}
