using System.Linq;
using System.Windows;

namespace Practical.Post_employee
{
    public partial class Posts_employeesEdit : Window
    {
        dbEntities db = new dbEntities();

        public Posts_employeesEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Posts_employees posts_Employees = db.Posts_employees.Find(ClassID.id_post_employee);

            Emp_combo.DataContext = db.Employees.ToList();
            Post_combo.DataContext = db.Posts.ToList();

            Emp_combo.SelectedValue = posts_Employees.fk_emp;
            Post_combo.SelectedValue = posts_Employees.fk_post;
        }

        private void EditPost_emp_Click(object sender, RoutedEventArgs e)
        {
            Posts_employees posts_Employees = db.Posts_employees.Find(ClassID.id_post_employee);

            posts_Employees.fk_emp = (int)Emp_combo.SelectedValue;
            posts_Employees.fk_post = (int)Post_combo.SelectedValue;

            db.SaveChanges();

            this.Close();
        }
    }
}
