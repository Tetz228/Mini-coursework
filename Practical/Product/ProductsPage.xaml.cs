using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Product
{
    public partial class ProductsPage : Page
    {
        dbEntities db = new dbEntities();

        public ProductsPage()
        {
            InitializeComponent();

            Query();
        }

        private void Query()
        {
            var query =
                from Products in db.Products

                join Suppliers in db.Suppliers on Products.fk_suppliers equals Suppliers.id_supplier
                join Type_product in db.Types_product on Products.fk_types equals Type_product.id_type_product

                select new { Products.id_product,  Products.name, fk_types = Type_product.name, fk_suppliers = Suppliers.lname + " " + Suppliers.fname + " " + Suppliers.mname};

            ProductsGrid.ItemsSource = query.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ProductsAdd productsAdd = new ProductsAdd();

            productsAdd.ShowDialog();

            Query();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedCells.Count > 0)
            {
                ProductsEdit productsEdit = new ProductsEdit();

                productsEdit.ShowDialog();

                Query();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedCells.Count > 0)
            {
                Products products = db.Products.Find(ClassID.id_product);

                db.Products.Remove(products);

                db.SaveChanges();

                Query();
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            TextBlock tbl = ProductsGrid.Columns[0].GetCellContent(row) as TextBlock;
            if (!string.IsNullOrEmpty(tbl.Text))
            {
                ClassID.id_product = Convert.ToInt32(tbl.Text);
            }
        }
    }
}
