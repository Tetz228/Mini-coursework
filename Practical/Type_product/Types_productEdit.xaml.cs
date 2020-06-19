using System.Windows;

namespace Practical.Type_product
{
    public partial class Types_productEdit : Window
    {
        dbEntities db = new dbEntities();
        Types_product types_Product;

        public Types_productEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Types_product types_Product = db.Types_product.Find(ClassID.id_type_product);

            TextBoxName.Text = types_Product.name;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Types_product types_Product = db.Types_product.Find(ClassID.id_type_product);

            types_Product.name = TextBoxName.Text;

            db.SaveChanges();

            this.Close();
        }
    }
}
