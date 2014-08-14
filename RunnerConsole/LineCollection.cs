using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunnerConsole
{
    public class LineCollection : List<string>
    {
        private StringBuilder content;
        private int startIndex, endIndex = 0;
        private const int _DEFAULT_BUFFER_SIZE = 50;
        private int bufferSize = 0;

        /// <summary>
        /// The console text.
        /// </summary>
        public String Content 
        { 
            get{ return content.ToString(); }
        }

        /// <summary>
        /// default ctor
        /// </summary>
        public LineCollection()
        {
            this.content = new StringBuilder();
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="bufferSize">size of buffer to use; number of lines</param>
        public LineCollection(int bufferSize) : base(bufferSize)
        {
            this.content = new StringBuilder(0, bufferSize);
            this.bufferSize = bufferSize;
        }

        public void AppendLine()
        {
            //use an array as the buffer base rather than a stringbuilder.
        }

        public void Append(string value)
        {
        }

        public void AppendFormat(string format, params string[] args)
        {

        }
    }
}
