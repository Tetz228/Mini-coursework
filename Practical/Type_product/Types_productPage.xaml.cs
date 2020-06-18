using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Type_product
{
    public partial class Types_productPage : Page
    {
        dbEntities db = new dbEntities();

        public Types_productPage()
        {
            InitializeComponent();

            TypeGrid.ItemsSource = db.Types_product.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Types_productAdd types_ProductAdd = new Types_productAdd();

            types_ProductAdd.ShowDialog();

            TypeGrid.ItemsSource = db.Types_product.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (TypeGrid.SelectedCells.Count > 0)
            {
                Types_productEdit types_ProductEdit = new Types_productEdit();

                var id = (TypeGrid.SelectedItem as Types_product).id_type_product;

                ClassID.id_type_product = id;

                types_ProductEdit.ShowDialog();

                TypeGrid.ItemsSource = db.Types_product.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TypeGrid.SelectedCells.Count > 0)
            {
                var id = (TypeGrid.SelectedItem as Types_product).id_type_product;

                Types_product types_Product = db.Types_product.Find(id);

                db.Types_product.Remove(types_Product);

                db.SaveChanges();

                TypeGrid.ItemsSource = db.Types_product.ToList();
            }
        }
    }
}
