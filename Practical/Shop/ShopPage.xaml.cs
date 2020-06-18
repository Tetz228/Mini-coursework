using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Shop
{
    public partial class ShopPage : Page
    {
        dbEntities db = new dbEntities();

        public ShopPage()
        {
            InitializeComponent();

            ShopsGrid.ItemsSource = db.Shops.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ShopAdd shopAdd = new ShopAdd();

            shopAdd.ShowDialog();

            ShopsGrid.ItemsSource = db.Shops.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ShopsGrid.SelectedCells.Count > 0)
            {
                ShopEdit shopEdit = new ShopEdit();

                var id = (ShopsGrid.SelectedItem as Shops).id_shop;

                ClassID.id_shop = id;

                shopEdit.ShowDialog();

                ShopsGrid.ItemsSource = db.Shops.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ShopsGrid.SelectedCells.Count > 0)
            {
                var id = (ShopsGrid.SelectedItem as Shops).id_shop;

                Shops shops = db.Shops.Find(id);

                db.Shops.Remove(shops);

                db.SaveChanges();

                ShopsGrid.ItemsSource = db.Shops.ToList();
            }
        }
    }
}
