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
    public partial class DisplayPacketInfo : Form
    {
        public DisplayPacketInfo(Packet pckt)
        {
            InitializeComponent();

            // Set the form's info
            lblTitle.Text = pckt.HeaderText + " packet content";
            lblBody.Text = pckt.BodyText;
            this.Text = "Information on " + pckt.HeaderText + " packet.";
        }
    }
}
