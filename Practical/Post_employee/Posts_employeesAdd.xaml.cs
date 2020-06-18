using System.Linq;
using System.Windows;

namespace Practical.Post_employee
{
    public partial class Posts_employeesAdd : Window
    {
        dbEntities db = new dbEntities();

        public Posts_employeesAdd()
        {
            InitializeComponent();

            Emp_combo.DataContext = db.Employees.ToList(); 
            Post_combo.DataContext = db.Posts.ToList();  
        }

        private void AddPost_emp_Click(object sender, RoutedEventArgs e)
        {
            Posts_employees posts_Employees = new Posts_employees();

            posts_Employees.fk_emp = (int)Emp_combo.SelectedValue;
            posts_Employees.fk_post = (int)Post_combo.SelectedValue;

            db.Posts_employees.Add(posts_Employees);

            db.SaveChanges();

            this.Close();
        }
    }
}
