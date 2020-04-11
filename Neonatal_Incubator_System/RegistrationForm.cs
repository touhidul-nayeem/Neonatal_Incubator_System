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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

         IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret= "vteAfDlqnQsu6LWPzAW8lAPQIEJM3TyzY3u3b78v",
            BasePath= "https://neonatal-incubator-system.firebaseio.com/"
        };

        IFirebaseClient client;
        private void RegistrationForm_Load(object sender, EventArgs e)
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

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegFullnametextBox.Text) &&
                string.IsNullOrWhiteSpace(RegUsernameTextBox.Text) &&
                string.IsNullOrWhiteSpace(RegInstituteTextBox.Text) &&
                string.IsNullOrWhiteSpace(RegAddressTextBox.Text) &&
                string.IsNullOrWhiteSpace(RegPasswordTextBox.Text) &&
                string.IsNullOrWhiteSpace(RegConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            else if (!Equals(RegPasswordTextBox.Text, RegConfirmPassword.Text))
            {
                MessageBox.Show("password did not match");
                return;
            }

            else
            {

                User myuser = new User()
                {
                    FullName = RegFullnametextBox.Text,
                    Username = RegUsernameTextBox.Text,
                    InstitutionName = RegInstituteTextBox.Text,
                    Address = RegAddressTextBox.Text,
                    Password = RegPasswordTextBox.Text,
                    ConfirmPassword = RegConfirmPassword.Text
                };

                SetResponse set = client.Set(@"Users/" + RegUsernameTextBox.Text, myuser);

                MessageBox.Show("user successfully registered!");
            }
        }
    }
}
