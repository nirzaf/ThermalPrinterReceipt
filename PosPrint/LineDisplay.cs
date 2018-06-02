using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosPrint
{

        public class LineDisplay
        {
            private Graphics graphics;
            private Rectangle bounds;
            private Brush brush;
            private Font font;
            private PointF position;


            public LineDisplay(Graphics graphics, Font font, Rectangle bounds)
            {
                this.graphics = graphics;
                this.bounds = bounds;
                brush = System.Drawing.Brushes.Black;
                this.font = font;
                position = new PointF(bounds.Left, bounds.Top);
            }


            public void WriteLine(string text)
            {
                graphics.DrawString(text, font, brush, position);
                NewLine();
            }


            public void NewLine()
            {
                position.X = bounds.Left;
                position.Y += font.Height;
            }

        public void WriteAtColumn(int x, string text)
        {
            this.graphics.DrawString(text, this.font, this.brush, x, this.position.Y);
        }


        public void WriteTwoColumnLine(string leftText, string rightText)
        {
            this.WriteAtColumn(this.bounds.Left, leftText);
            this.WriteAtColumn(this.bounds.Left + (this.bounds.Width / 2), rightText);
            this.NewLine();
        }

    }
}

