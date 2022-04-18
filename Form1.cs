using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Point_of_Sale
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

       

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable res = connection.selectData("select * from `accounts`where `username`='" + textBox1.Text + "' and password='" + connection.CreateMD5(textBox2.Text) + "'");
            if (res.Rows.Count>0) {
                String fname = res.Rows[0][3].ToString();
                String lname = res.Rows[0][4].ToString();
                String role = res.Rows[0][5].ToString();
                Properties.Settings.Default.firstname = fname;
                Properties.Settings.Default.lastname = lname;
                Properties.Settings.Default.role = role;
                Properties.Settings.Default.Save();
                this.Hide();
                
                cashier cashier = new cashier();
                
                cashier.Show();
            }
            
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                button1.PerformClick();


            }
        }
    }
}
