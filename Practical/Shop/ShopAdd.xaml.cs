using System.Windows;

namespace Practical.Shop
{
    public partial class ShopAdd : Window
    {
        dbEntities db = new dbEntities();

        public ShopAdd()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Shops shops = new Shops();

            shops.name = TextBoxName.Text;
            shops.address = TextBoxAddress.Text;

            db.Shops.Add(shops);

            db.SaveChanges();

            this.Close();
        }
    }
}
