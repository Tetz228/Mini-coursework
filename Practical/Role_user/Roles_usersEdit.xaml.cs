using System.Windows;

namespace Practical.Role_user
{
    public partial class Roles_usersEdit : Window
    {
        dbEntities db = new dbEntities();

        public Roles_usersEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Roles_users role_user = db.Roles_users.Find(ClassID.id_role_user);

            TextBoxName.Text = role_user.name;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Roles_users role_user = db.Roles_users.Find(ClassID.id_role_user);

            role_user.name = TextBoxName.Text;

            db.SaveChanges();

            this.Close();
        }
    }
}
