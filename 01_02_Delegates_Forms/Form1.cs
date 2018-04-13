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
        DoWorkDelegate m;

        public Form1()
        {
            InitializeComponent();
            m = new DoWorkDelegate(DoWork);

        }

        private void btn_Sync_Click(object sender, EventArgs e)
        {
            DoWork();
        }
        private void DoWork()
        {
            System.Threading.Thread.Sleep(10000);
            lock (this)
            {
                label1.Text = "DoWork worked!"; 
            }
        }

        private void btn_Async_Click(object sender, EventArgs e)
        {         
            IAsyncResult asyncResult = m.BeginInvoke(null, null);
            m.EndInvoke(asyncResult);
        }
    }
}
