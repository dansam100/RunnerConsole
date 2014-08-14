using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunnerConsole
{
    public interface IConsole
    {
        /// <summary>
        /// Move to the next line on the console.
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Write a desired formatted string onto the console terminated by a newline
        /// </summary>
        /// <param name="format">format to write</param>
        /// <param name="args">the format parameters</param>
        void WriteLine(string format, params string[] args);

        /// <summary>
        /// Writes string value onto the console terminted by a newline.
        /// </summary>
        /// <param name="value">string to write</param>
        void WriteLine(string value);

        /// <summary>
        /// Writes an object onto the console terminated by a newline.
        /// </summary>
        /// <param name="value">object to write</param>
        void WriteLine(object value);

        /// <summary>
        /// Writes a string value onto the console.
        /// </summary>
        /// <param name="value">string to write</param>
        void Write(string value);

        /// <summary>
        /// Write a desired formatted string onto the console.
        /// </summary>
        /// <param name="format">format to write</param>
        /// <param name="args">the format parameters</param>
        void Write(string format, params string[] args);

        /// <summary>
        /// Writes an object value to the console.
        /// </summary>
        /// <param name="value">object to write</param>
        void Write(object value);

        /// <summary>
        /// Clears the console.
        /// </summary>
        void Clear();

        /// <summary>
        /// Console back color.
        /// </summary>
        System.Drawing.Color BackColor { get; set; }
    }
}
