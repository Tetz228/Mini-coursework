using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical
{
    public partial class EmployeesPage : Page
    {
        dbEntities db = new dbEntities();

        public EmployeesPage()
        {
            InitializeComponent();

            EmployeesGrid.ItemsSource = db.Employees.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeesAdd employeesAdd = new EmployeesAdd();

            employeesAdd.ShowDialog();

            EmployeesGrid.ItemsSource = db.Employees.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedCells.Count > 0) 
            {
                EmployeesEdit employeesEdit = new EmployeesEdit();

                var id = (EmployeesGrid.SelectedItem as Employees).id_employee;

                ClassID.id_employee = id;

                employeesEdit.ShowDialog();

                EmployeesGrid.ItemsSource = db.Employees.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedCells.Count > 0)
            {
                var id = (EmployeesGrid.SelectedItem as Employees).id_employee;

                Employees employees = db.Employees.Find(id);

                db.Employees.Remove(employees);

                db.SaveChanges();

                EmployeesGrid.ItemsSource = db.Employees.ToList();
            }
        }
    }
}
