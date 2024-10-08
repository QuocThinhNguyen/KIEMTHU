using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
            txtKq.ScrollBars = ScrollBars.Horizontal; 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            decimal so1, so2, kq = 0;
            try
            {
                so1 = decimal.Parse(txtSo1.Text.Trim());
            }
            catch (Exception error)
            {
                DialogResult dr;
                dr = MessageBox.Show(error.Message,
                                     "Thông báo");
                txtSo1.ResetText();
                txtSo1.Focus();
                return;
            }
            so2 = decimal.Parse(txtSo2.Text);
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        private void txtSo1_TextChanged(object sender, EventArgs e)
        {
            double so1 = 0;
            try
            {
                so1 = double.Parse(txtSo1.Text.Trim());
            } catch (Exception error) {
                DialogResult dr;
                dr = MessageBox.Show(error.Message,
                                     "Thông báo");
                txtSo1.ResetText();
                txtSo1.Focus();
            }
        }
    }
}
