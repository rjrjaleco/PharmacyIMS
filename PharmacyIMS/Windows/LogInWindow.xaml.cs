using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Windows.Threading;

namespace PharmacyIMS.Windows
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {

            InitializeComponent();
            this.SourceInitialized += Window1_SourceInitialized;
            UpdateUsers();
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


        private void TxtbxUsernameLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtblkUsernameLogin.Visibility = Visibility.Hidden;
            TxtbxUsernameLogin.Background = Brushes.White;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        private void TxtbxUsernameLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtbxUsernameLogin.Text == "")
            {
                TxtblkUsernameLogin.Visibility = Visibility.Visible;
                TxtbxUsernameLogin.Background = Brushes.Transparent;
            }
        }

        private void TxtbxPasswordLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtblkPasswordLogin.Visibility = Visibility.Hidden;
            TxtbxPasswordLogin.Background = Brushes.White;
        }

        private void TxtbxPasswordLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtbxPasswordLogin.Password == "")
            {
                TxtblkPasswordLogin.Visibility = Visibility.Visible;
                TxtbxPasswordLogin.Background = Brushes.Transparent;
            }
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ViewModels.ViewModelLocator.LogInWindowViewModel.UserList[0].Username, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            int val = ViewModels.ViewModelLocator.LogInWindowViewModel.LogIn(TxtbxUsernameLogin.Text, TxtbxPasswordLogin.Password);
            if (val == 1)
            {
                this.Hide();
                var mainWindow = new MainWindow();
                mainWindow.Owner = Application.Current.MainWindow;
                
                mainWindow.ShowDialog();
            }
            else
                MessageBox.Show("User does not exist!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            TxtbxUsernameLogin.Text = "";
            TxtbxPasswordLogin.Password = "";
            TxtblkUsernameLogin.Visibility = Visibility.Visible;
            TxtbxUsernameLogin.Background = Brushes.Transparent;
            TxtblkPasswordLogin.Visibility = Visibility.Visible;
            TxtbxPasswordLogin.Background = Brushes.Transparent;
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
    }
}
