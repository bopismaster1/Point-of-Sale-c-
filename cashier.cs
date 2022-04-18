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

namespace Point_of_Sale
{
    public partial class cashier : Form
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
        public cashier()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void cashier_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            label2.Text = Properties.Settings.Default.firstname.ToUpper();
            label3.Text = Properties.Settings.Default.lastname.ToUpper();
            //this.KeyDown += new KeyEventHandler(cashier_KeyDown);
        }

        private void cashier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                MessageBox.Show("f1 pressed");
            }
            else if(e.KeyCode.ToString() == "F4"){
                button3.PerformClick();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
