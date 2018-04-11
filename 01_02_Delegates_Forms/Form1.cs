using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_02_Delegates_Forms
{
    public partial class Form1 : Form
    {
        delegate void DoWorkDelegate();

        public Form1()
        {
            InitializeComponent();

        }

        private void btn_Sync_Click(object sender, EventArgs e)
        {
            DoWork();
        }
        private void DoWork()
        {
            label1.Text = "DoWork worked!";
        }

        private void btn_Async_Click(object sender, EventArgs e)
        {
            DoWorkDelegate m = new DoWorkDelegate(DoWork);
            IAsyncResult asyncResult = m.BeginInvoke(null, null);
            m.EndInvoke(asyncResult);
        }
    }
}
