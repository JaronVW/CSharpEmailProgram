using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using EmailClient;

namespace EmailApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmailServer server;

        public MainWindow()
        {
            var email = ConfigurationManager.ConnectionStrings["email"].ConnectionString;
            var password = ConfigurationManager.ConnectionStrings["password"].ConnectionString;
            server = new EmailServer("smtp.office365.com", "outlook.office365.com", email, password);
            InitializeComponent();
        }
    }
}