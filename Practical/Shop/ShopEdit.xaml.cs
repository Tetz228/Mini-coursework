using System.Windows;

namespace Practical.Shop
{
    public partial class ShopEdit : Window
    {
        dbEntities db = new dbEntities();

        public ShopEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Shops shops = db.Shops.Find(ClassID.id_shop);

            TextBoxName.Text = shops.name;
            TextBoxAddress.Text = shops.address;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Shops shops = db.Shops.Find(ClassID.id_shop);

            shops.name = TextBoxName.Text;
            shops.address = TextBoxAddress.Text;

            db.SaveChanges();

            this.Close();
        }
    }
}
