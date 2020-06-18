using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practical
{
    public partial class EmployeesPage : Page
    {
        dbEntities db;

        public EmployeesPage()
        {
            InitializeComponent();

            db = new dbEntities();

            db.Employees.Load();

            EmployeesGrid.ItemsSource = db.Employees.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeesAdd employeesAdd = new EmployeesAdd();

            employeesAdd.ShowDialog();

            db.Employees.Load();

            EmployeesGrid.ItemsSource = db.Employees.Local.ToBindingList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedCells.Count > 0) 
            {
                EmployeesEdit employeesEdit = new EmployeesEdit();

                var id = (EmployeesGrid.SelectedItem as Employees).id_employee;

                ClassID.id_employee = id;

                employeesEdit.ShowDialog();

                db.Employees.Load();

                EmployeesGrid.ItemsSource = db.Employees.Local.ToBindingList();
            }
        }

        private void Delede_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
