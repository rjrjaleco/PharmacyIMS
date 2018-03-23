using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PharmacyIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : CustomWindow
    {
        
        bool productTabPressed = false;
        bool supplierTabPressed = false;
        bool deliveryTabPressed = false;
        bool transactionTabPressed = false;
        bool userTabPressed = false;

        public MainWindow()
        {
            InitializeComponent();
            productTabPressed = true;

            this.DataContext = ViewModels.ViewModelLocator.MainWindowViewModel;
            DispatcherTimer timer = new DispatcherTimer();
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.TxtBlkClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
                this.TxtBlkDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            }, this.Dispatcher);
            ProductTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            ProductTabButton.Foreground = Brushes.Black;
            this.SourceInitialized += Window1_SourceInitialized;
            Updater();
            
            TransactionTabButton.Visibility = Visibility.Hidden;
        }
        private void InitializeTabs()
        {
            ProductTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
            ProductTabButton.Foreground = Brushes.White;
            SupplierTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
            SupplierTabButton.Foreground = Brushes.White;
            DeliveryTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
            DeliveryTabButton.Foreground = Brushes.White;
            TransactionTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
            TransactionTabButton.Foreground = Brushes.White;
            UserTab.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
            UserTab.Foreground = Brushes.White;
            productTabPressed = false;
            supplierTabPressed = false;
            deliveryTabPressed = false;
            transactionTabPressed = false;
            userTabPressed = false;
            SupplierGrid.Visibility = Visibility.Hidden;
            ProductGrid.Visibility = Visibility.Hidden;
            UserGrid.Visibility = Visibility.Hidden;
            DeliveryGrid.Visibility = Visibility.Hidden;
        }

        #region WindowResizeDisable
        private void Window1_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            HwndSource source = HwndSource.FromHwnd(helper.Handle);
            source.AddHook(WndProc);
        }

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            switch (msg)
            {
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        handled = true;
                    }
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        }
        #endregion
        private void Updater()
        {
            UpdateProducts();
            UpdateSuppliers();
            UpdateSupplierProducts();
            UpdateDelivery();
            UpdateOrders();
            UpdateDeliveryOrders();
            UpdateUsers();
        }
        #region Product Tab Grid
        private void UpdateProducts()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * From [PRODUCT]", con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            con.Open();

            ViewModels.ViewModelLocator.MainWindowViewModel.ProductList.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                Classes.PRODUCT newProduct = new Classes.PRODUCT();

                newProduct.ID = Convert.ToInt16(dt.Rows[x]["ID"]);
                newProduct.ProductName = dt.Rows[x]["ProductName"].ToString();
                newProduct.GenericName = dt.Rows[x]["GenericName"].ToString();
                newProduct.Type = dt.Rows[x]["Type"].ToString();
                newProduct.Form = dt.Rows[x]["Form"].ToString();
                newProduct.BuyingPrice = Convert.ToDecimal(dt.Rows[x]["BuyingPrice"]);
                newProduct.SellingPrice = Convert.ToDecimal(dt.Rows[x]["SellingPrice"]);
                newProduct.Quantity = Convert.ToInt16(dt.Rows[x]["Quantity"]);
                ViewModels.ViewModelLocator.MainWindowViewModel.ProductList.Add(newProduct);
            }
            con.Close();
        }
        private void TbxSearchProduct_GotFocus(object sender, RoutedEventArgs e)
        {
            TblSearchProduct.Visibility = Visibility.Hidden;
            TbxSearchProduct.Background = Brushes.White;
        }

        private void TbxSearchProduct_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbxSearchProduct.Text == "")
            {
                TblSearchProduct.Visibility = Visibility.Visible;
                TbxSearchProduct.Background = Brushes.Transparent;
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.AddProduct();
            Updater();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.EditProduct();
            Updater();
        }
        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.RemoveProduct();
            Updater();
        }
        private void ProductTabButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            InitializeTabs();
            ProductTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            ProductTabButton.Foreground = Brushes.Black;
            productTabPressed = true;
            ProductGrid.Visibility = Visibility.Visible;
        }

        private void ProductTabButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (productTabPressed != true)
            {
                ProductTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
                ProductTabButton.Foreground = Brushes.White;
            }
            else
            {
                ProductTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
                ProductTabButton.Foreground = Brushes.Black;
            }
        }
        private void ClearProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.ClearProducts();
            Updater();
        }
        #endregion

        #region Supplier Tab Grid
        private void UpdateSuppliers()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [SUPPLIER]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Open();

            ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                Classes.SUPPLIER newSupplier = new Classes.SUPPLIER();

                newSupplier.ID = Convert.ToInt16(dt.Rows[x]["ID"]);
                newSupplier.SupplierName = dt.Rows[x]["SupplierName"].ToString();
                newSupplier.SupplierAddress = dt.Rows[x]["SupplierAddress"].ToString();
                newSupplier.SupplierDetails = dt.Rows[x]["SupplierDetails"].ToString();
                ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList.Add(newSupplier);
            }
            con.Close();
        }
        private void AddSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.AddSupplier();
            Updater();
        }

        private void EditSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.EditSupplier();
            Updater();
        }
        private void RemoveSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.RemoveSupplier();
            Updater();
        }
        private void SupplierTabButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            InitializeTabs();
            SupplierTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            SupplierTabButton.Foreground = Brushes.Black;
            supplierTabPressed = true;
            SupplierGrid.Visibility = Visibility.Visible;
        }

        private void SupplierTabButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (supplierTabPressed != true)
            {
                SupplierTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
                SupplierTabButton.Foreground = Brushes.White;
            }
            else
            {
                SupplierTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
                SupplierTabButton.Foreground = Brushes.Black;
            }
        }
        private void TbxSearchSupplier_GotFocus(object sender, RoutedEventArgs e)
        {
            TblSearchSupplier.Visibility = Visibility.Hidden;
            TbxSearchSupplier.Background = Brushes.White;
        }

        private void TbxSearchSupplier_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbxSearchSupplier.Text == "")
            {
                TblSearchSupplier.Visibility = Visibility.Visible;
                TbxSearchSupplier.Background = Brushes.Transparent;
            }
        }

        #endregion
        #region Supplier Products
        private void AddSupplierProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.AddProductToSupplier();
            Updater();
        }
        private void UpdateSupplierProducts()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * From [SUPPLIER_PRODUCT]", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [SUPPLIER]", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT * From [PRODUCT]", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            con.Open();
            
            for (int a = 0; a<ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList.Count; a++)
            {
                var holderSupplier = ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList[a] as Classes.SUPPLIER;
                holderSupplier.SupplierProductList.Clear();
            }
            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                for(int y =0; y <ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList.Count; y++)
                {
                    var holderSupplier = ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList[y] as Classes.SUPPLIER;
                    if (dt1.Rows[x]["SupplierID"].ToString() == holderSupplier.ID.ToString())
                    {
                        for (int z = 0; z < ViewModels.ViewModelLocator.MainWindowViewModel.ProductList.Count; z++)
                        {
                            var holderProduct = ViewModels.ViewModelLocator.MainWindowViewModel.ProductList[z] as Classes.PRODUCT;
                            if (dt1.Rows[x]["ProductID"].ToString() == holderProduct.ID.ToString())
                            {
                                holderSupplier.SupplierProductList.Add(holderProduct);
                            }
                        }
                    }
                }
            }
            con.Close();
        }

        private void RemoveSupplierProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.RemoveSupplierProduct();
            Updater();
        }

        private void ClearSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.ClearSuppliers();
            Updater();
        }

        private void ClearSupplierProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.ClearSupplierProduct();
            Updater();
        }


        private void TbxSearchSupplierProduct_GotFocus(object sender, RoutedEventArgs e)
        {
            TblSearchSupplierProduct.Visibility = Visibility.Hidden;
            TbxSearchSupplierProduct.Background = Brushes.White;
        }

        private void TbxSearchSupplierProduct_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbxSearchSupplierProduct.Text == "")
            {
                TblSearchSupplierProduct.Visibility = Visibility.Visible;
                TbxSearchSupplierProduct.Background = Brushes.Transparent;
            }
        }
        #endregion

        #region User Tab Grid
        private void UserTab_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UserTab.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            UserTab.Foreground = Brushes.Black;
            (sender as TextBlock).ContextMenu.IsEnabled = true;
            (sender as TextBlock).ContextMenu.PlacementTarget = (sender as TextBlock);
            (sender as TextBlock).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as TextBlock).ContextMenu.IsOpen = true;
            
        }
        private void EditUserBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.EditUser();
            Updater();
        }
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            TbxSearchDelivery.Text = "";
            TbxSearchDeliveryOrder.Text = "";
            TbxSearchProduct.Text = "";
            TbxSearchSupplier.Text = "";
            TbxSearchSupplierProduct.Text = "";
            this.Owner.Show();
            this.Close();
        }

        private void TbxSearchUser_GotFocus(object sender, RoutedEventArgs e)
        {
            TblSearchUser.Visibility = Visibility.Hidden;
            TbxSearchUser.Background = Brushes.White;
        }

        private void TbxSearchUser_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbxSearchUser.Text == "")
            {
                TblSearchUser.Visibility = Visibility.Visible;
                TbxSearchUser.Background = Brushes.Transparent;
            }
        }
        private void UpdateUsers()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * From [USER]", con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            ViewModels.ViewModelLocator.LogInWindowViewModel.UserList.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                Classes.USER newUser = new Classes.USER();

                newUser.ID = Convert.ToInt16(dt.Rows[x]["ID"]);
                newUser.Username = dt.Rows[x]["Username"].ToString();
                newUser.Password = dt.Rows[x]["Password"].ToString();
                newUser.Level = dt.Rows[x]["Level"].ToString();
                ViewModels.ViewModelLocator.LogInWindowViewModel.UserList.Add(newUser);
            }
            con.Close();
        }
        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.AddUser();
            Updater();
        }

        private void RemoveUserBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.RemoveUser();
            Updater();
        }

        private void ClearUserBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.ClearUsers();
            Updater();
        }

        private void OpenUserTabBtn_Click(object sender, RoutedEventArgs e)
        {
            InitializeTabs();
            UserTab.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            UserTab.Foreground = Brushes.Black;
            userTabPressed = true;
            UserGrid.Visibility = Visibility.Visible;
        }

        private void UserTab_MouseLeave(object sender, MouseEventArgs e)
        {
            if (userTabPressed != true)
            {
                UserTab.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
                UserTab.Foreground = Brushes.White;
            }
            else
            {
                UserTab.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
                UserTab.Foreground = Brushes.Black;
            }
        }
        #endregion

        #region DELIVERY
        private void UpdateDelivery()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [DELIVERY]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Open();

            ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                Classes.DELIVERY newDelivery = new Classes.DELIVERY();

                newDelivery.ID = Convert.ToInt16(dt.Rows[x]["ID"]);
                newDelivery.OrderDate = Convert.ToDateTime(dt.Rows[x]["OrderDate"]);
                newDelivery.ArrivalDate = Convert.ToDateTime(dt.Rows[x]["ArrivalDate"]);
                newDelivery.DriverName = dt.Rows[x]["DriverName"].ToString();
                for(int y = 0; y < ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList.Count; y++)
                {
                    var holderSupplier = ViewModels.ViewModelLocator.MainWindowViewModel.SupplierList[y] as Classes.SUPPLIER;
                    if (holderSupplier.ID == Convert.ToInt16(dt.Rows[x]["SupplierID"]))
                        newDelivery.SupplierDelivery = holderSupplier;
                }
                ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList.Add(newDelivery);
            }
            con.Close();
        }
        private void UpdateOrders()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [ORDER]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Open();

            ViewModels.ViewModelLocator.MainWindowViewModel.OrderList.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                Classes.ORDER newOrder = new Classes.ORDER();

                newOrder.ID = Convert.ToInt16(dt.Rows[x]["ID"]);
                newOrder.Quantity = Convert.ToInt16(dt.Rows[x]["Quantity"]);
                for (int y = 0; y < ViewModels.ViewModelLocator.MainWindowViewModel.ProductList.Count; y++)
                {
                    var holderProduct = ViewModels.ViewModelLocator.MainWindowViewModel.ProductList[y] as Classes.PRODUCT;
                    if (holderProduct.ID == Convert.ToInt16(dt.Rows[x]["ProductID"]))
                        newOrder.OrderProduct = holderProduct;
                }
                ViewModels.ViewModelLocator.MainWindowViewModel.OrderList.Add(newOrder);
            }
            con.Close();
        }
        private void UpdateDeliveryOrders()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * From [DELIVERY_ORDER]", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [DELIVERY]", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT * From [ORDER]", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            con.Open();

            for (int a = 0; a < ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList.Count; a++)
            {
                var holderDelivery = ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList[a] as Classes.DELIVERY;
                holderDelivery.DeliveryOrderList.Clear();
            }
            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                for (int y = 0; y < ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList.Count; y++)
                {
                    var holderDelivery = ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList[y] as Classes.DELIVERY;
                    if (dt1.Rows[x]["DeliveryID"].ToString() == holderDelivery.ID.ToString())
                    {
                        for (int z = 0; z < ViewModels.ViewModelLocator.MainWindowViewModel.OrderList.Count; z++)
                        {
                            var holderOrder = ViewModels.ViewModelLocator.MainWindowViewModel.OrderList[z] as Classes.ORDER;
                            if (dt1.Rows[x]["OrderID"].ToString() == holderOrder.ID.ToString())
                            {
                                holderDelivery.DeliveryOrderList.Add(holderOrder);
                            }
                        }
                    }
                }
            }
            con.Close();
        }
        private void DeliveryTabButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            InitializeTabs();
            DeliveryTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            DeliveryTabButton.Foreground = Brushes.Black;
            deliveryTabPressed = true;
            DeliveryGrid.Visibility = Visibility.Visible;
        }

        private void DeliveryTabButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (deliveryTabPressed != true)
            {
                DeliveryTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0066FF"));
                DeliveryTabButton.Foreground = Brushes.White;
            }
            else
            {
                DeliveryTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
                DeliveryTabButton.Foreground = Brushes.Black;
            }
        }
        private void TbxSearchDelivery_GotFocus(object sender, RoutedEventArgs e)
        {
            TblSearchDelivery.Visibility = Visibility.Hidden;
            TbxSearchDelivery.Background = Brushes.White;
        }

        private void TbxSearchDelivery_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbxSearchDelivery.Text == "")
            {
                TblSearchDelivery.Visibility = Visibility.Visible;
                TbxSearchDelivery.Background = Brushes.Transparent;
            }
        }

        private void TbxSearchDeliveryOrder_GotFocus(object sender, RoutedEventArgs e)
        {
            TblSearchDeliveryOrder.Visibility = Visibility.Hidden;
            TbxSearchDeliveryOrder.Background = Brushes.White;
        }

        private void TbxSearchDeliveryOrder_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbxSearchDelivery.Text == "")
            {
                TblSearchDeliveryOrder.Visibility = Visibility.Visible;
                TbxSearchDeliveryOrder.Background = Brushes.Transparent;
            }
        }

        private void AddDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.AddDelivery();
            Updater();
        }

        private void RemoveDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.RemoveDelivery();
            Updater();
        }

        private void ClearDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.ClearDeliveries();
            Updater();
        }

        private void AddDeliveryOrderButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.AddOrderToDelivery();
            Updater();
        }

        private void RemoveDeliveryOrderButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.RemoveDeliveryOrder();
            Updater();
        }

        private void ClearDeliveryDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.ClearDeliveryOrder();
            Updater();
        }

        private void ConfirmArrivalDeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.ConfirmDelivery();
            Updater();
        }




        #endregion


        //private void SupplierProductsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}