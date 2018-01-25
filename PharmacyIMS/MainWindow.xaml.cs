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
    public partial class MainWindow : Window
    {
        bool productTabPressed = false;
        bool supplierTabPressed = false;
        bool deliveryTabPressed = false;
        bool transactionTabPressed = false;
        public MainWindow()
        {
            InitializeComponent();
            productTabPressed = true;

            this.DataContext = ViewModels.ViewModelLocator.MainWindowViewModel;
            DispatcherTimer timer = new DispatcherTimer();
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                //this.TxtBlkClock.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss");
                this.TxtBlkClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
                this.TxtBlkDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            }, this.Dispatcher);
            ProductTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            ProductTabButton.Foreground = Brushes.Black;
            this.SourceInitialized += Window1_SourceInitialized;
            UpdateProducts();
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

        #region Product Tab Grid
        private void UpdateProducts()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\rjrjaleco\documents\visual studio 2015\Projects\PharmacyIMS\PharmacyIMS\Database\DatabaseTest.mdf");
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [PRODUCT]", con);
            DataTable dt = new DataTable();
            sda2.Fill(dt);
            con.Close();

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
            UpdateProducts();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.ViewModelLocator.MainWindowViewModel.EditProduct();
            UpdateProducts();
        }

        private void ProductTabButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            InitializeTabs();
            ProductTabButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
            ProductTabButton.Foreground = Brushes.Black;
            productTabPressed = true;
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
        #endregion
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
            productTabPressed = false;
            supplierTabPressed = false;
            deliveryTabPressed = false;
            transactionTabPressed = false;
        }

        private void AddSupplierButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditSupplierButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}