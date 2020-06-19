using System;
using System.Linq;
using System.Windows;


namespace Practical.Inventorys
{
    public partial class Inventory_productsAdd : Window
    {
        dbEntities db = new dbEntities();

        public Inventory_productsAdd()
        {
            InitializeComponent();

            Product_combo.DataContext = db.Products.ToList();
            User_combo.DataContext = db.Users.ToList();
            Shop_combo.DataContext = db.Shops.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Inventory_products inventory_Products = new Inventory_products();

            inventory_Products.fact_amount = Convert.ToInt32(TextBoxFact.Text);
            inventory_Products.residue = Convert.ToInt32(TextBoxResidue.Text);
            inventory_Products.shortage = Convert.ToInt32(TextBoxShortage.Text);
            inventory_Products.surplus = Convert.ToInt32(TextBoxSurplus.Text);
            inventory_Products.date = Convert.ToDateTime(TextBoxDate.Text);
            inventory_Products.fk_product = (int)Product_combo.SelectedValue;
            inventory_Products.fk_user = (int)User_combo.SelectedValue;
            inventory_Products.fk_shop = (int)Shop_combo.SelectedValue;

            db.Inventory_products.Add(inventory_Products);

            db.SaveChanges();

            this.Close();
        }
    }
}
