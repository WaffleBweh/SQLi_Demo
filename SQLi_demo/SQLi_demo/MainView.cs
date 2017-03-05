using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLi_demo
{
    public partial class MainView : Form
    {
        List<Packet> packets;
        List<Packet> packetsToRemove;
        const int rectWidth = 75;
        const int rectHeight = 50;

        public MainView()
        {
            InitializeComponent();
            this.rtbSql.WriteToSql("$username", "$password");

            // Initialize our object
            packets = new List<Packet>();
            packetsToRemove = new List<Packet>();
        }

        /// <summary>
        /// Controls on the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Send the package
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Set the start position of the packet
            int startX = groupBox1.Left + groupBox1.Width - rectWidth - 1; // -1px for the border
            int startY = groupBox1.Top + (groupBox1.Height / 2) - (rectHeight / 2);
            Rectangle tmpRect = new Rectangle(startX, startY, rectWidth, rectHeight);

            // Create our object
            packets.Add(new Packet(tmpRect, tbUsername.Text, tbPassword.Text, "TCP/IP", "STP REQUEST"));

            // Launch the timer
            MainTimer.Enabled = true;
        }


        /// <summary>
        /// Check and uncheck to show and unshow the password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            // Force refresh the form
            Refresh();
        }

        private void MainView_Paint(object sender, PaintEventArgs e)
        {
            // Draw the packets
            foreach (var packet in packets)
            {
                if (packets.Count > 0)
                {
                    packet.Draw(e.Graphics, this.Width, this.Height);
                    packet.X++;

                    if (packet.X > rtbSql.Left)
                    {
                        packetsToRemove.Add(packet);

                        // Change the text of the SQL output
                        this.rtbSql.WriteToSql(packet.Username, packet.Password);
                    }
                }
                else
                {
                    // Stop the timer if there are no more packets
                    MainTimer.Stop();
                }
            }

            // Remove packets
            foreach (var packet in packetsToRemove)
            {
                packets.Remove(packet);
            }
        }

        /// <summary>
        /// Check if we click on a packet
        /// If we click on a packet, we show its information and pause the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var packet in packets)
            {
                if (packet.isHit(e.X, e.Y))
                {
                    packet.OnClick();
                    MainTimer.Stop();
                    break;
                }
            }
        }
    }
}
