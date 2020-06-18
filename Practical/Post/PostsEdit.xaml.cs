using System.Windows;

namespace Practical.Post
{
    public partial class PostsEdit : Window
    {
        dbEntities db = new dbEntities();

        public PostsEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Posts posts = db.Posts.Find(ClassID.id_post);

            TextBoxName.Text = posts.name;
        }

        private void EditPost_Click(object sender, RoutedEventArgs e)
        {
            Posts posts = db.Posts.Find(ClassID.id_post);

            posts.name = TextBoxName.Text;
            
            db.SaveChanges();

            this.Close();
        }
    }
}
