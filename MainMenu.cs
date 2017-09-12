using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyHouse
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(59, 160, 232);
            button2.BackColor = Color.FromArgb(59, 160, 232);
        }
    }
}
