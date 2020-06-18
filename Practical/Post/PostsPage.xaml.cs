using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Post
{
    public partial class PostsPage : Page
    {
        dbEntities db = new dbEntities();

        public PostsPage()
        {
            InitializeComponent();

            PostsGrid.ItemsSource = db.Posts.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PostsAdd PostsAdd = new PostsAdd();

            PostsAdd.ShowDialog();

            PostsGrid.ItemsSource = db.Posts.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (PostsGrid.SelectedCells.Count > 0)
            {
                PostsEdit PostsEdit = new PostsEdit();

                var id = (PostsGrid.SelectedItem as Posts).id_post;

                ClassID.id_post = id;

                PostsEdit.ShowDialog();
 
                PostsGrid.ItemsSource = db.Posts.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (PostsGrid.SelectedCells.Count > 0)
            {
                var id = (PostsGrid.SelectedItem as Posts).id_post;

                Posts post = db.Posts.Find(id);

                db.Posts.Remove(post);

                db.SaveChanges();

                PostsGrid.ItemsSource = db.Posts.ToList();
            }
        }
    }
}
