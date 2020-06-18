using System.Data.Entity;
using System.Windows;

namespace Practical
{
    public partial class EmployeesAdd : Window
    {
        dbEntities db;

        public EmployeesAdd()
        {
            InitializeComponent();

            db = new dbEntities();

            db.Employees.Load();
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
