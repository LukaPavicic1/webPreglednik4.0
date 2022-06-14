using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using EasyTabs;

namespace webPreglednik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitChromium();
        }

        public ChromiumWebBrowser c;
        public void InitChromium()
        {
            Cef.Initialize(new CefSettings());

            c = new ChromiumWebBrowser("https://www.google.com");
            c.AddressChanged += C_AddressChanged;
            c.TitleChanged += C_TitleChanged;
            this.panel.Controls.Add(c);
            CheckForIllegalCrossThreadCalls = false;
        }

        private void C_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Text = e.Title;
        }

        private void C_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            tbSearch.Text = e.Address.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            c.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            c.Forward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            c.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            c.Load(tbSearch.Text);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            c.Load("Google.com");
        }

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }


    }
}
