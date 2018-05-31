using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosPrint
{
        public class PrintText
        {
            public PrintText(string text, Font font) : this(text, font, new StringFormat()) { }

            public PrintText(string text, Font font, StringFormat stringFormat)
            {
                Text = text;
                Font = font;
                StringFormat = stringFormat;
            }

            public string Text { get; set; }

            public Font Font { get; set; }

            /// <summary> Default is horizontal string formatting </summary>
            public StringFormat StringFormat { get; set; }
        }
  }

