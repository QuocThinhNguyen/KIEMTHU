using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        private ErrorProvider errorProvider;

        public Form1()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
            txtSo1.TextChanged += new EventHandler(txtSo1_TextChanged);
            txtSo2.TextChanged += new EventHandler(txtSo2_TextChanged);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        // Kiểm tra khi người dùng nhập vào ô số 1
        private void txtSo1_TextChanged(object sender, EventArgs e)
        {
            decimal so1;
            if (!decimal.TryParse(txtSo1.Text, out so1))
            {
                errorProvider.SetError(txtSo1, "Vui lòng nhập số hợp lệ!");
                txtSo2.Enabled = false;
                btnTinh.Enabled = false;
            }
            else
            {
                errorProvider.SetError(txtSo1, string.Empty); // Xóa lỗi nếu giá trị hợp lệ
                txtSo2.Enabled = true;
                btnTinh.Enabled = true;
            }
        }

        // Kiểm tra khi người dùng nhập vào ô số 2
        private void txtSo2_TextChanged(object sender, EventArgs e)
        {
            decimal so2;
            if (!decimal.TryParse(txtSo2.Text, out so2))
            {
                errorProvider.SetError(txtSo2, "Vui lòng nhập số hợp lệ!");
                txtSo1.Enabled= false;
                btnTinh.Enabled= false;
            }
            else
            {
                errorProvider.SetError(txtSo2, string.Empty); // Xóa lỗi nếu giá trị hợp lệ
                txtSo1.Enabled = true;
                btnTinh.Enabled = true;
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            decimal so1, so2, kq = 0;
            so1 = decimal.Parse(txtSo1.Text);
            so2 = decimal.Parse(txtSo2.Text);

            // Nếu có lỗi ở các ô nhập liệu thì không thực hiện tính toán
            if (!decimal.TryParse(txtSo1.Text, out so1) || !decimal.TryParse(txtSo2.Text, out so2))
            {
                MessageBox.Show("Vui lòng sửa lỗi trước khi tính toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        private void txtSo1_Leave(object sender, EventArgs e)
        {
            // Biểu thức chính quy chỉ cho phép số, dấu chấm (.) và dấu trừ (-)
            string pattern = @"[^0-9.-]";

            // Kiểm tra nếu ô nhập liệu chứa ký tự đặc biệt
            if (Regex.IsMatch(txtSo1.Text, pattern))
            {
                MessageBox.Show("Ô số thứ nhất không được chứa ký tự đặc biệt! Vui lòng chỉ nhập số và dấu thập phân (.)",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo1.Focus(); // Đưa con trỏ trở lại ô số 1
            }
        }

        private void txtSo2_Leave(object sender, EventArgs e)
        {
            // Biểu thức chính quy chỉ cho phép số, dấu chấm (.) và dấu trừ (-)
            string pattern = @"[^0-9.-]";

            // Kiểm tra nếu ô nhập liệu chứa ký tự đặc biệt
            if (Regex.IsMatch(txtSo2.Text, pattern))
            {
                MessageBox.Show("Ô số thứ hai không được chứa ký tự đặc biệt! Vui lòng chỉ nhập số và dấu thập phân (.)",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo2.Focus(); // Đưa con trỏ trở lại ô số 2
            }
        }

        private void txtSo1_Enter(object sender, EventArgs e)
        {
            txtSo1.SelectAll(); // Chọn toàn bộ nội dung trong ô số 1
        }

        private void txtSo2_Enter(object sender, EventArgs e)
        {
            txtSo2.SelectAll(); // Chọn toàn bộ nội dung trong ô số 2
        }
    }
}
