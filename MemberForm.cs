using System;
using System.Linq;
using System.Windows.Forms;

namespace gomart
{
    public partial class MemberForm : Form
    {
        LinQClassesDataContext xdb = new LinQClassesDataContext();
        int row = -1;

        public MemberForm()
        {
            InitializeComponent();
        }

        private void loadDgv()
        {
            var a = xdb.Members.Where(x =>
                x.Name.Contains(txtSearch.Text) ||
                x.Email.Contains(txtSearch.Text) ||
                x.PhoneNumber.Contains(txtSearch.Text)).ToList();

            dgvMember.DataSource = a;
        }

        private void txtClear()
        {
            txtId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private void setAutoID(TextBox b)
        {
            var a = xdb.Members.Select(x => x.Id).OrderByDescending(x => x).FirstOrDefault();

            int id = 1;
            if (a != null)
            {
                id = Convert.ToInt32(a.Substring(5)) + 1;
            }

            b.Text = "M" + DateTime.Now.Year + id.ToString("D5");
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if (row != -1)
            {
                txtId.Text = dgvMember.Rows[row].Cells[0].Value.ToString();
                txtName.Text = dgvMember.Rows[row].Cells[1].Value.ToString();
                txtEmail.Text = dgvMember.Rows[row].Cells[2].Value.ToString();
                txtPhone.Text = dgvMember.Rows[row].Cells[3].Value.ToString();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            setAutoID(txtId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var mb = new Member();
            mb.Id = txtId.Text;
            mb.Name = txtName.Text;
            mb.Email = txtEmail.Text;
            mb.PhoneNumber = txtPhone.Text;

            xdb.Members.InsertOnSubmit(mb);
            xdb.SubmitChanges();

            MessageBox.Show("Data berhasil disimpan");
            txtClear();
            loadDgv();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var mb = xdb.Members.First(x => x.Id == txtId.Text);

            mb.Name = txtName.Text;
            mb.Email = txtEmail.Text;
            mb.PhoneNumber = txtPhone.Text;

            xdb.SubmitChanges();
            MessageBox.Show("Update berhasil");
            txtClear();
            loadDgv();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Yakin hapus?", "Delete", MessageBoxButtons.YesNo);

            if (dg == DialogResult.Yes)
            {
                var mb = xdb.Members.First(x => x.Id == txtId.Text);
                xdb.Members.DeleteOnSubmit(mb);
                xdb.SubmitChanges();

                MessageBox.Show("Delete berhasil");
                loadDgv();
            }
        }
    }
}
