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
using System.Windows.Shapes;

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
