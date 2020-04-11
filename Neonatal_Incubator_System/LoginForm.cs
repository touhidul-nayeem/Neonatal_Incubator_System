using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Neonatal_Incubator_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "vteAfDlqnQsu6LWPzAW8lAPQIEJM3TyzY3u3b78v",
            BasePath = "https://neonatal-incubator-system.firebaseio.com/"
        };
        
        IFirebaseClient client;
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("connection failed");
            }
        }

        private void Registerbutton_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.ShowDialog();
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernametextBox.Text) &&
                string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            FirebaseResponse res = client.Get(@"Users/" + UsernametextBox.Text);
            User ResultUser = res.ResultAs<User>();
            User CurrentUser = new User()
            {
                Username = UsernametextBox.Text,
                Password = PasswordTextBox.Text
            };

            if (User.Isequal(ResultUser, CurrentUser))
            {
                WelcomeCenter welcome = new WelcomeCenter();
                welcome.ShowDialog();
            }
            else
            {
                User.showError();
            }
        }
    }
}
