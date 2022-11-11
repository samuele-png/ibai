using DataLayer;
using Domain_Layer.Classes;
using Domain_Layer.ClassManagers;
using Domain_Layer.Enums;
using Domain_Layer.Interfaces;
using System.Diagnostics;
using System.Windows.Forms;

namespace IBaiNewDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            PopulateUsrTypeCB();
            PopulateUsersLV();
            PopulateCategoriesLB();
            PopulateStoresLV();
            PopulateProductsLV();
        }
        UserManager userManager = new(new UserData());
        StoreManager storeManager = new(new StoreData());
        ProductManager productManager = new(new ProductData());
        StockManager stockManager = new(new StockData());
        OrderManager orderManager = new(new OrderData());
        private void PopulateUsrTypeCB()
        {
            string[] names = System.Enum.GetNames(typeof(UserLevels));
            for (int i = 0; i < 5; i++)
            {
                userTypeCB.Items.Add(names[i]);
            }
        }
        private void PopulateUsersLV()
        {
            List<User> userList = userManager.GetUsers();
            usersLV.View = View.Details;
            usersLV.Columns.Add("ID");
            usersLV.Columns.Add("Name");
            foreach (User x in userList)
                usersLV.Items.Add(new ListViewItem(new string[] { x.UserId.ToString(), x.UserName }));
        }
        private void PopulateStoresLV()
        {
            List<Store> storeList = storeManager.GetStores();
            storesLV.View = View.Details;
            storesLV.Columns.Add("ID");
            storesLV.Columns.Add("Name");
            foreach (Store x in storeList)
                storesLV.Items.Add(new ListViewItem(new string[] { x.StoreId.ToString(), x.StoreName }));
        }
        private void PopulateProductsLV()
        {
            List<Product> productList = productManager.GetProducts();
            productsLV.View = View.Details;
            productsLV.Columns.Add("ID");
            productsLV.Columns.Add("Name");
            if (storesLV.SelectedItems.Count > 0)
            {
                int z = Convert.ToInt32(storesLV.SelectedItems[0].Text);
                Product product = productList.Find(x=>x.Store.StoreId == z);
                productsLV.Items.Add(new ListViewItem(new string[] { product.ProductID.ToString(), product.Name }));
            }
            else
            {
                foreach(Product x in productList)
                {
                    productsLV.Items.Add(new ListViewItem(new string[] { x.ProductID.ToString(), x.Name }));

                }
            }
        }
        private void PopulateCategoriesLB()
        {
            string[] names = System.Enum.GetNames(typeof(Categories));
            for (int i = 0; i < names.Count(); i++)
            {
                catCB.Items.Add(names[i]);
                newProdCatCB.Items.Add(names[i]);
            }
        }
        private void createUsrBtn_Click(object sender, EventArgs e)
        {
            // interface from logic layer
            UserLevels usrLevels = (UserLevels)userTypeCB.SelectedIndex;
            User newUser = new User(0, lastNameTB.Text, firstNameTB.Text, emailTB.Text, (int)usrLevels, userNameTB.Text, passwordTB.Text, addressTB.Text, telephoneTB.Text);
            userManager.WriteUser(newUser);
        }
        private void createStoreBtn_Click(object sender, EventArgs e)
        {
            List<Categories> catList = new();
            try
            {
                User selUser = userManager.GetUserById(new User(Convert.ToInt32(usersLV.SelectedItems[0].Text)));
                foreach (string s in selCatLB.Items)
                {
                    catList.Add((Categories)System.Enum.Parse(typeof(Categories), s));
                }
                storeManager.WriteStore(new Store(0, selUser, storeNameTB.Text, descTB.Text, catList));

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select an user first");
            }
            
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            PopulateUsersLV();
            PopulateStoresLV();
            PopulateProductsLV();
            selCatLB.Items.Clear();
        }

        private void addSelCatBtn_Click(object sender, EventArgs e)
        {
            try
            {
                selCatLB.Items.Add(catCB.SelectedItem.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select categories first");
            }
        }

        private void createProductBtn_Click(object sender, EventArgs e)
        {
            List<Categories> catList = new();
            int selStore = Convert.ToInt32(storesLV.SelectedItems[0].Text);
            foreach (string s in newProdLB.Items)
            {
                catList.Add((Categories)System.Enum.Parse(typeof(Categories), s));
            }
            Product newProduct = new Product(0, prodNameTB.Text, prodDescTB.Text, Convert.ToDouble(priceTB.Text), Convert.ToDouble(shipFeeTB.Text), pictureTB.Text, catList,new Store(selStore));
            productManager.WriteProduct(newProduct);
            Stock newStock = new Stock(productManager.GetProducts().Last(), 0, Convert.ToInt32(reccStockAmountTB.Text));
            stockManager.WriteStock(newStock);
        }

        private void updateStockBtn_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(productsLV.SelectedItems[0].Text);
            Stock newStock = new Stock(productManager.GetProduct(new Product(productId)), Convert.ToInt32(currentAmountTB.Text), Convert.ToInt32(suggAmountTB.Text));
            stockManager.WriteStock(newStock);
        }

        private void newOrderBtn_Click(object sender, EventArgs e)
        {
           
            int userId = Convert.ToInt32(usersLV.SelectedItems[0].Text);
            User user = userManager.GetUserById(new User(userId));
            string[] fullId = newOrderLV.Items.OfType<ListViewItem>().Select(x => x.SubItems[0].Text).ToArray();
            List<Product> productList = productManager.GetProducts();
            List<Product> orderList = new();
            if(fullId.Length > 0)
            {
                for (int i = 0; i < fullId.Length; i++)
                {
                    orderList.Add(productList.Find(x => x.ProductID.ToString() == fullId[i]));
                }
                Order order = new(0, user, orderList);
                orderManager.WriteOrder(order);
            }
            else
            {
                MessageBox.Show("Select something to order first");
            }
       
        }
        
        private void addNewProdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                newProdLB.Items.Add(newProdCatCB.SelectedItem.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select categories first");
            }
        }

        private void delUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                userManager.DeleteUser(new User(Convert.ToInt32(usersLV.SelectedItems[0].Text)));
                MessageBox.Show("User Deleted!");

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a user to delete!");
            }
        }

        private void delProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                productManager.DeleteProduct(new Product(Convert.ToInt32(productsLV.SelectedItems[0].Text)));
                MessageBox.Show("Product Deleted!");

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a product to delete!");
            }
        }

        private void delStoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                storeManager.DeleteStore(new Store(Convert.ToInt32(storesLV.SelectedItems[0].Text)));
                MessageBox.Show("Store Deleted!");

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a store to delete!");
            }
        }

        private void updateUserBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void updateStoreBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void updateProductBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

