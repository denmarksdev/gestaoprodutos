using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GPApp.WinForms.Helpers
{
    public static class  RichPanelHelper
    {
        public enum FillStyle
        {
            None,
            Solid,
            Gradient
        }

        public enum Align
        {
            Left,
            Center,
            Right
        }

        public enum RoundRectType
        {
            None,
            AllCorner,
            Upper,
            Lower
        }

        public static float GetXPos(Align align, float totalWidth, float componentWidth, float margin)
        {
            float x = 0;
            if (align == Align.Left)
                x = margin;
            else if (align == Align.Right)
                x = totalWidth - margin - componentWidth;
            else if (align == Align.Center)
                x = (totalWidth - (2 * margin) - componentWidth) / 2;
            return x;
        }

        public static GraphicsPath GetRoundPath(Rectangle r, int depth, RoundRectType roundRectType)
        {
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            int radius = depth / 2;
            int x = r.X;
            int y = r.Y;
            int width = r.Width;
            int height = r.Height;

            //Upper
            if ((roundRectType == RoundRectType.AllCorner || roundRectType == RoundRectType.Upper) && depth >= 2)
                p.AddArc(x, y, 2 * radius, 2 * radius, 180, 90);
            else
            {
                p.AddLine(x, y, x + r.Width, y);
                p.AddLine(x, y, x + depth / 2, y);
            }
            p.AddLine(x + radius, y, x + width - radius, y);

            if ((roundRectType == RoundRectType.AllCorner || roundRectType == RoundRectType.Upper) && depth >= 2)
                p.AddArc(x + width - 2 * radius, y, 2 * radius, 2 * radius, 270, 90);
            else
            {
                p.AddLine(x + width - radius, y, x + width, y);
                p.AddLine(x + width, y, x + width, y + radius);
            }
            p.AddLine(x + width, y + radius, x + width, y + height - radius);

            //Lower
            if ((roundRectType == RoundRectType.AllCorner || roundRectType == RoundRectType.Lower) && depth >= 2)
                p.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90);
            else
            {
                p.AddLine(x + width, y + height - radius, x + width, y + height);
                p.AddLine(x + width, y + height, x + width - radius, y + height);
            }
            p.AddLine(x + width - radius, y + height, x + radius, y + height);

            if ((roundRectType == RoundRectType.AllCorner || roundRectType == RoundRectType.Lower) && depth >= 2)
                p.AddArc(x, y + height - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            else
            {
                p.AddLine(x + radius, y + height, x, y + height);
                p.AddLine(x, y + height, x, y + height - radius);
            }
            p.AddLine(x, y + height - radius, x, y + radius);

            p.CloseFigure();
            return p;
        }


        public static double Distance(PointF p1, PointF p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}

