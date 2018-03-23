using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PharmacyIMS.Windows
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordTbx.Password == "" && UsernameTbx.Text == "")
            {
                MessageBox.Show("Entries cannot be blank!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(UsernameTbx.Text =="")
            {
                MessageBox.Show("Username cannot be blank!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (PasswordTbx.Password == "")
            {
                MessageBox.Show("Password cannot be blank!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (PasswordTbx.Password == PasswordConfirmTbx.Password)
                {
                    var result = MessageBox.Show("Are you sure to save changes?" + Environment.NewLine + "WARNING: Changes cannot be undone.", "Error", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                    if (result == MessageBoxResult.Yes)
                    {
                        SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter();
                        SqlCommand command = new SqlCommand();
                        command = new SqlCommand("UPDATE [USER] SET Username = @Username, Password = @Password WHERE ID=" + 1, con);
                        command.Parameters.AddWithValue("@Username", UsernameTbx.Text);
                        command.Parameters.AddWithValue("@Password", PasswordTbx.Password);
                        command.ExecuteNonQuery();
                        con.Close();
                        DialogResult = true;
                    }
                }
                else
                    MessageBox.Show("Passwords does not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
