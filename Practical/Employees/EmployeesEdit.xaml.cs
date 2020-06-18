using System.Windows;

namespace Practical
{
    public partial class EmployeesEdit : Window
    {
        dbEntities db = new dbEntities();

        public EmployeesEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Employees employees = db.Employees.Find(ClassID.id_employee);

            TextBoxLname.Text = employees.lname;
            TextBoxFname.Text = employees.fname;
            TextBoxMname.Text = employees.mname;
        }

        private void EditEmp_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = db.Employees.Find(ClassID.id_employee);

            employees.lname = TextBoxLname.Text;
            employees.fname = TextBoxFname.Text;
            employees.mname = TextBoxMname.Text;
            
            db.SaveChanges();

            this.Close();
        }
    }
}
