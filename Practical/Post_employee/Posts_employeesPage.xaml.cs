using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Post_employee
{
    public partial class Posts_employeesPage : Page
    {
        dbEntities db = new dbEntities();

        public Posts_employeesPage()
        {
            InitializeComponent();

            Query();
        }

        private void Query()
        {
            var query =
                from Posts_employees in db.Posts_employees
                join Posts in db.Posts on Posts_employees.fk_post equals Posts.id_post
                join Employees in db.Employees on Posts_employees.fk_emp equals Employees.id_employee
                select new { Posts_employees.id_post_employee, fk_emp = Employees.lname + " " + Employees.fname + " " + Employees.mname, fk_post = Posts.name };

            Posts_empGrid.ItemsSource = query.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Posts_employeesAdd Posts_employeesAdd = new Posts_employeesAdd();

            Posts_employeesAdd.ShowDialog();

            Query();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Posts_empGrid.SelectedCells.Count > 0)
            {
                Posts_employeesEdit PostsEdit = new Posts_employeesEdit();
                
                PostsEdit.ShowDialog();

                Query();
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            TextBlock tbl = Posts_empGrid.Columns[0].GetCellContent(row) as TextBlock;

            int id = Convert.ToInt32(tbl.Text);

            ClassID.id_post_employee = id;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Posts_empGrid.SelectedCells.Count > 0)
            {
                Posts_employees posts_Employees = db.Posts_employees.Find(ClassID.id_post_employee);

                db.Posts_employees.Remove(posts_Employees);

                db.SaveChanges();

                Query();
            }
        }
    }
}
