using System;
using System.Linq;
using System.Windows;

namespace Practical.Inventorys
{
    public partial class Inventory_productsEdit : Window
    {
        dbEntities db = new dbEntities();

        public Inventory_productsEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Inventory_products inventory_Products = db.Inventory_products.Find(ClassID.id_inventory);

            Product_combo.DataContext = db.Products.ToList();
            User_combo.DataContext = db.Users.ToList();
            Shop_combo.DataContext = db.Shops.ToList();
                   

            TextBoxFact.Text = inventory_Products.fact_amount.ToString();
            TextBoxResidue.Text = inventory_Products.residue.ToString();
            TextBoxShortage.Text = inventory_Products.shortage.ToString();
            TextBoxSurplus.Text = inventory_Products.surplus.ToString();
            TextBoxDate.Text = inventory_Products.date.ToString().Substring(0,10);
            Product_combo.SelectedValue = inventory_Products.fk_product;
            User_combo.SelectedValue = inventory_Products.fk_user;
            Shop_combo.SelectedValue = inventory_Products.fk_shop;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Inventory_products inventory_Products = db.Inventory_products.Find(ClassID.id_inventory);

            inventory_Products.fact_amount = Convert.ToInt32(TextBoxFact.Text);
            inventory_Products.residue = Convert.ToInt32(TextBoxResidue.Text);
            inventory_Products.shortage = Convert.ToInt32(TextBoxShortage.Text);
            inventory_Products.surplus = Convert.ToInt32(TextBoxSurplus.Text);
            inventory_Products.date = Convert.ToDateTime(TextBoxDate.Text);
            inventory_Products.fk_product = (int)Product_combo.SelectedValue;
            inventory_Products.fk_user = (int)User_combo.SelectedValue;
            inventory_Products.fk_shop = (int)Shop_combo.SelectedValue;

            db.SaveChanges();

            this.Close();
        }
    }
}
