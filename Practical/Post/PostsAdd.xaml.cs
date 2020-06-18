using System.Windows;

namespace Practical.Post
{
    public partial class PostsAdd : Window
    {
        dbEntities db = new dbEntities();

        public PostsAdd()
        {
            InitializeComponent();
        }

        private void AddPost_Click(object sender, RoutedEventArgs e)
        {
            Posts posts = new Posts();

            posts.name = TextBoxName.Text;

            db.Posts.Add(posts);

            db.SaveChanges();

            this.Close();
        }
    }
}
