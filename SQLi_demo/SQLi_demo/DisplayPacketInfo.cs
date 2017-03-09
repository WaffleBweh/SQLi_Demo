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
        Packet packet;

        public DisplayPacketInfo(Packet pckt)
        {
            InitializeComponent();
            packet = pckt;
            // Set the form's info
            lblTitle.Text = pckt.HeaderText + " packet content";
            rtbContent.Text = pckt.BodyText;
            this.Text = "Information on " + pckt.HeaderText + " packet.";
        }

        private void DisplayPacketInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Change the state of the packet
            packet.RemoveInfo();
        }
    }
}
