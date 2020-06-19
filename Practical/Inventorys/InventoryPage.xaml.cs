using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Inventorys
{
    public partial class InventoryPage : Page
    {
        dbEntities db = new dbEntities();

        public InventoryPage()
        {
            InitializeComponent();

            Query();
        }

        private void Query()
        {
            var query =
                from Inventory_products in db.Inventory_products

                join Product in db.Products on Inventory_products.fk_product equals Product.id_product
                join User in db.Users on Inventory_products.fk_user equals User.id_user
                join Shop in db.Shops on Inventory_products.fk_shop equals Shop.id_shop

                select new { Inventory_products.id_inv_prod, fk_product = Product.name, Inventory_products.fact_amount, Inventory_products.residue, Inventory_products.shortage, Inventory_products.surplus, fk_user = User.login, fk_shop = Shop.name + " " + Shop.address, Inventory_products.date };

            InventoryGrid.ItemsSource = query.ToList();
        }

        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            TextBlock tbl = InventoryGrid.Columns[0].GetCellContent(row) as TextBlock;
            if (!string.IsNullOrEmpty(tbl.Text))
            {
                ClassID.id_inventory = Convert.ToInt32(tbl.Text);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Inventory_productsAdd inventory_ProductsAdd = new Inventory_productsAdd();

            inventory_ProductsAdd.ShowDialog();

            Query();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryGrid.SelectedCells.Count > 0)
            {
                Inventory_productsEdit inventory_ProductsEdit = new Inventory_productsEdit();

                inventory_ProductsEdit.ShowDialog();

                Query();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryGrid.SelectedCells.Count > 0)
            {
                Inventory_products inventory = db.Inventory_products.Find(ClassID.id_inventory);

                db.Inventory_products.Remove(inventory);

                db.SaveChanges();

                Query();
            }
        }
    }
}
