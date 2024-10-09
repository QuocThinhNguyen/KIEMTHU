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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
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
            // Kiểm tra xem các ô nhập số có để trống hay không
            if (string.IsNullOrWhiteSpace(txtSo1.Text))
            {
                MessageBox.Show("Hãy nhập giá trị cho số thứ nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo1.Focus(); // Đặt con trỏ vào ô số 1
                return; // Dừng lại nếu thông tin không đầy đủ
            }

            if (string.IsNullOrWhiteSpace(txtSo2.Text))
            {
                MessageBox.Show("Hãy nhập giá trị cho số thứ hai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo2.Focus(); // Đặt con trỏ vào ô số 2
                return;
            }

            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);

            
            

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

        private void txtSo2_TextChanged(object sender, EventArgs e)
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
