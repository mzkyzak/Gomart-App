using System;
using System.Windows.Forms;

namespace gomart
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberForm m = new MemberForm();
            m.MdiParent = this;
            m.Show();
        }
    }
}
