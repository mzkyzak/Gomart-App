using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace gomart
{
    public partial class LoginForm : Form
    {
        QDataClassesDataContext qdb = new QDataClassesDataContext();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var build = new StringBuilder();
            var sha256 = new SHA256CryptoServiceProvider();
            var bytes = sha256.ComputeHash(new UTF8Encoding().GetBytes(txtPass.Text));

            for (int i = 0; i < bytes.Length; i++)
            {
                build.Append(bytes[i].ToString("x2"));
            }

            var a = qdb.Employees
                .Where(x => x.Email == txtEmail.Text && x.Password == build.ToString())
                .FirstOrDefault();

            if (a == null)
            {
                MessageBox.Show("Email atau Password salah");
            }
            else
            {
                ClassData.id = a.Id;
                ClassData.position = a.PositionId;

                MainForm f = new MainForm();
                f.Show();
                this.Hide();
            }
        }
    }
}