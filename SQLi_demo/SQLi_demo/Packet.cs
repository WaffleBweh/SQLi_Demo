using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLi_demo
{
    /// <summary>
    /// Class to draw network packets and animate them on a form
    /// </summary>
    public class Packet
    {
        #region fields
        private int _x;
        private int _y;
        private int _width;
        private int _height;

        private string _username;
        private string _password;

        private string _headerText;
        private string _bodyText;
        #endregion

        #region properties
        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public string HeaderText
        {
            get
            {
                return _headerText;
            }

            set
            {
                _headerText = value;
            }
        }

        public string BodyText
        {
            get
            {
                return _bodyText;
            }

            set
            {
                _bodyText = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Designated constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="headerText"></param>
        /// <param name="bodyText"></param>
        public Packet(int x, int y, int width, int height, string username, string password ,string headerText, string bodyText)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Username = username;
            this.Password = password;
            this.HeaderText = headerText;
            this.BodyText = bodyText;
        }

        /// <summary>
        /// Rectangle constructor
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="headerText"></param>
        /// <param name="bodyText"></param>
        public Packet(Rectangle rect, string username, string password, string headerText, string bodyText) : this(rect.X, rect.Y, rect.Width, rect.Height, username, password, headerText, bodyText)
        {
            // No code
        }

        /// <summary>
        /// Size and point constructor
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="sz"></param>
        /// <param name="headerText"></param>
        /// <param name="bodyText"></param>
        public Packet(Point pt, Size sz, string username, string password, string headerText, string bodyText) : this(pt.X, pt.Y, sz.Width, sz.Height, username, password, headerText, bodyText)
        {
            // No code
        }
        #endregion

        #region methods
        /// <summary>
        /// Draw the object
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g, int formWidth, int formHeight)
        {
            g.FillRectangle(Brushes.LightYellow, this.AsRectangle());
            g.DrawRectangle(Pens.Black, this.AsRectangle());
            g.DrawLine(Pens.Black, this.X, this.Y, this.X + this.Width / 2, this.Y + this.Height / 2);
            g.DrawLine(Pens.Black, this.X + this.Width / 2, this.Y + this.Height / 2, this.X + this.Width, this.Y);

            this.Y = this.Y + (int)Math.Round(Math.Sin(this.X / 4));
        }

        /// <summary>
        /// Convert the object to a rectangle
        /// </summary>
        /// <returns></returns>
        public Rectangle AsRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
        #endregion
    }
}
