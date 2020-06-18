using System.Windows;

namespace Practical.Supplier
{
    public partial class SuppliersAdd : Window
    {
        dbEntities db = new dbEntities();

        public SuppliersAdd()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = new Suppliers();

            suppliers.lname = TextBoxLname.Text;
            suppliers.fname = TextBoxFname.Text;
            suppliers.mname = TextBoxMname.Text;
            suppliers.phone_number = TextBoxPhone.Text;
            suppliers.email = TextBoxEmail.Text;

            db.Suppliers.Add(suppliers);

            db.SaveChanges();

            this.Close();
        }
    }
}
