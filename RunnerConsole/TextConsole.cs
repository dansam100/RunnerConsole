using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RunnerConsole;

namespace Runner
{
    public partial class TextConsole : TextBox, IConsole
    {
        private StringBuilder content = new StringBuilder();
        //private LineCollection content = new LineCollection();

        public TextConsole()
        {
            InitializeComponent();
        }

        private delegate void WriteFormatDelegate(string value, params string[] args);
        private delegate void WriteDelegate(string value);

        private delegate void WriteLineFormatDelegate(string format, params string[] args);
        private delegate void WriteLineEmptyDelegate();
        private delegate void WriteLineDelegate(string value);

        private delegate void RemoveLineEmptyDelegate();
        private delegate void RemoveLineDelegate(int line);

        /// <summary>
        /// Move to the next line on the console.
        /// </summary>
        public void WriteLine()
        {
            try {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WriteLineEmptyDelegate(WriteLine));
                }
                else
                {
                    content.AppendLine();
                }
            }
            catch (Exception){}
        }

        /// <summary>
        /// Write a desired formatted string onto the console.
        /// </summary>
        /// <param name="format">format to write</param>
        /// <param name="args">the format parameters</param>
        public void WriteLine(string format, params string[] args)
        {
            try {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WriteLineFormatDelegate(WriteLine), format, args);
                }
                else
                {
                    content.AppendFormat(format, args);
                    WriteLine();
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Writes string value onto the console terminted by a newline.
        /// </summary>
        /// <param name="value">string to write</param>
        public void WriteLine(string value)
        {
            try {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WriteLineDelegate(WriteLine), value);
                }
                else
                {
                    content.AppendLine(value);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Writes an object onto the console terminated by a newline.
        /// </summary>
        /// <param name="value">object to write</param>
        public void WriteLine(object value)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WriteLineDelegate(WriteLine), value.ToString());
                }
                else
                {
                    this.WriteLine(value.ToString());
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Writes a string value onto the console.
        /// </summary>
        /// <param name="value">string to write</param>
        public void Write(string value)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WriteDelegate(Write), value);
                }
                else
                {
                    content.Append(value);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Write a desired formatted string onto the console.
        /// </summary>
        /// <param name="format">format to write</param>
        /// <param name="args">the format parameters</param>
        public void Write(string format, params string[] args)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WriteLineDelegate(Write), format, args);
                }
                else
                {
                    content.AppendFormat(format, args);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Writes an object value to the console.
        /// </summary>
        /// <param name="value">object to write</param>
        public void Write(object value)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new WriteDelegate(Write), value.ToString());
                }
                else
                {
                    this.Write(value.ToString());
                }
            }
            catch (Exception) { }
        }
    }
}
