using System.Linq;
using System.Windows;

namespace Practical.Product
{
    public partial class ProductsAdd : Window
    {
        dbEntities db = new dbEntities();

        public ProductsAdd()
        {
            InitializeComponent();

            Sup_combo.DataContext = db.Suppliers.ToList();
            Type_combo.DataContext = db.Types_product.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products();

            products.name = TextBoxName.Text;
            products.fk_suppliers = (int)Sup_combo.SelectedValue;
            products.fk_types = (int)Type_combo.SelectedValue;

            db.Products.Add(products);

            db.SaveChanges();

            this.Close();
        }
    }
}
