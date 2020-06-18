using System.Windows;

namespace Practical.Supplier
{
    public partial class SuppliersEdit : Window
    {
        dbEntities db = new dbEntities();

        public SuppliersEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = db.Suppliers.Find(ClassID.id_supplier);

            TextBoxLname.Text = suppliers.lname;
            TextBoxFname.Text = suppliers.fname;
            TextBoxMname.Text = suppliers.mname;
            TextBoxPhone.Text = suppliers.phone_number;
            TextBoxEmail.Text = suppliers.email;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = db.Suppliers.Find(ClassID.id_supplier);

            suppliers.lname = TextBoxLname.Text;
            suppliers.fname = TextBoxFname.Text;
            suppliers.mname = TextBoxMname.Text;
            suppliers.phone_number = TextBoxPhone.Text;
            suppliers.email = TextBoxEmail.Text;

            db.SaveChanges();

            this.Close();
        }
    }
}
