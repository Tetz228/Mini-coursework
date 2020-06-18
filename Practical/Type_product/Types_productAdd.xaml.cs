using System.Windows;

namespace Practical.Type_product
{
    public partial class Types_productAdd : Window
    {
        dbEntities db = new dbEntities();

        public Types_productAdd()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Types_product types_Product = new Types_product();

            types_Product.name = TextBoxName.Text;

            db.Types_product.Add(types_Product);

            db.SaveChanges();

            this.Close();
        }
    }
}
