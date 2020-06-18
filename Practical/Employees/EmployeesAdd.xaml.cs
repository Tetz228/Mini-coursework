using System.Windows;

namespace Practical
{
    public partial class EmployeesAdd : Window
    {
        dbEntities db = new dbEntities();

        public EmployeesAdd()
        {
            InitializeComponent();
        }

        private void AddEmp_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = new Employees();

            employees.lname = TextBoxLname.Text;
            employees.fname = TextBoxFname.Text;
            employees.mname = TextBoxMname.Text;

            db.Employees.Add(employees);

            db.SaveChanges();

            this.Close();
        }
    }
}
