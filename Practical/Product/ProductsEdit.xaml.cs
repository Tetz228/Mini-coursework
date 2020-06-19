using System.Linq;
using System.Windows;

namespace Practical.Product
{
    public partial class ProductsEdit : Window
    {
        dbEntities db = new dbEntities();

        public ProductsEdit()
        {
            InitializeComponent();

            Sup_combo.ItemsSource = db.Suppliers.ToList();
            Type_combo.ItemsSource = db.Types_product.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Products products = db.Products.Find(ClassID.id_product);

            products.name = TextBoxName.Text;
            products.fk_suppliers = (int)Sup_combo.SelectedValue;
            products.fk_types = (int)Type_combo.SelectedValue;

            db.SaveChanges();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Products products = db.Products.Find(ClassID.id_product);

            TextBoxName.Text = products.name;
            Sup_combo.SelectedValue = products.fk_suppliers;
            Type_combo.SelectedValue = products.fk_types;
        }
    }
}
