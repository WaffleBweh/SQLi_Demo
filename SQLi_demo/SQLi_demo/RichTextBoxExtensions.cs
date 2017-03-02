using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLi_demo
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void WriteToSql(this RichTextBox box, string username, string password)
        {
            box.Clear();
            box.AppendText("SELECT ", Color.Green);
            box.AppendText("id" + Environment.NewLine);

            box.AppendText("FROM ", Color.Green);
            box.AppendText("Users" + Environment.NewLine);

            box.AppendText("WHERE ", Color.Green);
            box.AppendText("name = ");
            box.AppendText("'" + username + "'" + Environment.NewLine, Color.DarkRed);

            box.AppendText("AND ", Color.Green);
            box.AppendText("password = ");
            box.AppendText("'" + password + "'", Color.DarkRed);

            box.AppendText(";");
        }
    }
}
