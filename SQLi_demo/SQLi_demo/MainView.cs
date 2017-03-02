using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLi_demo
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            this.rtbSql.WriteToSql("$username", "$password");

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            if ((tbUsername.Text == String.Empty) || (tbPassword.Text == String.Empty))
            {
                btnSend.Enabled = false;
            }
            else
            {
                btnSend.Enabled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.rtbSql.WriteToSql(tbUsername.Text, tbPassword.Text);
        }

        private void isShown_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isShown.Checked)
            {
                this.tbPassword.PasswordChar = '\0';
            }
            else
            {
                this.tbPassword.PasswordChar = '*';
            }
            
        }
    }
}
