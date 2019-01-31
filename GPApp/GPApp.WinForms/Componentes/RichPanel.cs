using GPApp.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GPApp.WinForms.Componentes
{
    public partial class RichPanel : Panel
    {
        public enum SeparatorPosition
        {
            None,
            Bottom,
            Center
        }

        /*
         * Background
         */
        RichPanelHelper.FillStyle fillStyle = RichPanelHelper.FillStyle.None;
        [Browsable(true), Category("Background")]
        [DefaultValue(RichPanelHelper.FillStyle.None)]
        public RichPanelHelper.FillStyle FillStyle
        {
            get { return fillStyle; }
            set { fillStyle = value; Invalidate(); }
        }

        LinearGradientMode gradientStyle = LinearGradientMode.Vertical;
        [Browsable(true), Category("Background")]
        [DefaultValue(LinearGradientMode.Vertical)]
        public LinearGradientMode GradientStyle
        {
            get { return gradientStyle; }
            set { gradientStyle = value; Invalidate(); }
        }

        bool drawShadow = true;
        [Browsable(true), Category("Background")]
        [DefaultValue(true)]
        public bool DrawShadow
        {
            get { return drawShadow; }
            set { drawShadow = value; Invalidate(); }
        }

        int shadowOffSet = 10;
        [Browsable(true), Category("Background")]
        [DefaultValue(10)]
        public int ShadowOffSet
        {
            get { return shadowOffSet; }
            set { shadowOffSet = Math.Abs(value); Invalidate(); }
        }

        bool drawBorder = true;
        [Browsable(true), Category("Background")]
        [DefaultValue(true)]
        public bool DrawBorder
        {
            get { return drawBorder; }
            set { drawBorder = value; Invalidate(); }
        }

        int borderWidth = 2;
        [Browsable(true), Category("Background")]
        [DefaultValue(2)]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }

        Color borderColor = Color.Gray;
        [Browsable(true), Category("Background")]
        [DefaultValue("Color.Gray")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        int cornerRadius = 20;
        [Browsable(true), Category("Background")]
        [DefaultValue(20)]
        public int RoundCornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = Math.Abs(value); Invalidate(); }
        }

        RichPanelHelper.RoundRectType roundCornerType = RichPanelHelper.RoundRectType.Upper;
        [Browsable(true), Category("Background")]
        [DefaultValue("RichPanelHelper.RoundRectType.Upper")]
        public RichPanelHelper.RoundRectType RoundCornerType
        {
            get { return roundCornerType; }
            set { roundCornerType = value; Invalidate(); }
        }

        //FromArgb(89, 135, 214)
        Color backgroundColor1 = Color.Gray;
        [Browsable(true), Category("Background")]
        [DefaultValue("Color.Gray")]
        public Color BackgroundColor1
        {
            get { return backgroundColor1; }
            set { backgroundColor1 = value; Invalidate(); }
        }

        Color backgroundColor2 = Color.White;
        [Browsable(true), Category("Background")]
        [DefaultValue("Color.White")]
        public Color BackgroundColor2
        {
            get { return backgroundColor2; }
            set { backgroundColor2 = value; Invalidate(); }
        }

        public Action<bool,string> ExpandeChangedAction { get; set; }

        /*
         * Header
         */
        bool drawHeader = true;
        [Browsable(true), Category("Header")]
        [DefaultValue(true)]
        public bool DrawHeader
        {
            get { return drawHeader; }
            set { drawHeader = value; Invalidate(); }
        }

        string headerText = "GroupPanel";
        [Browsable(true), Category("Header")]
        [DefaultValue("GroupPanel")]
        public string HeaderText
        {
            get { return this.headerText; }
            set { this.headerText = value; Invalidate(); }
        }

        RichPanelHelper.Align headerTextAlign = RichPanelHelper.Align.Left;
        [Browsable(true), Category("Header")]
        [DefaultValue("RichPanelHelper.Align.Left")]
        public RichPanelHelper.Align HeaderTextAlign
        {
            get { return this.headerTextAlign; }
            set { this.headerTextAlign = value; Invalidate(); }
        }

        Font headerFont = new Font("Arial", 12F, System.Drawing.FontStyle.Bold);
        [Browsable(true), Category("Header")]
        public Font HeaderFont
        {
            get { return this.headerFont; }
            set { this.headerFont = value; Invalidate(); }
        }

        Color headerTextColor = Color.Black;
        [Browsable(true), Category("Header")]
        [DefaultValue("Color.Black")]
        public Color HeaderTextColor
        {
            get { return this.headerTextColor; }
            set { this.headerTextColor = value; Invalidate(); }
        }

        bool headerHasBackColor = false;
        [Browsable(true), Category("Header")]
        [DefaultValue(false)]
        public bool HeaderHasBackColor
        {
            get { return this.headerHasBackColor; }
            set { this.headerHasBackColor = value; Invalidate(); }
        }

        Color headerBackColor = Color.Gray;
        [Browsable(true), Category("Header")]
        [DefaultValue("Color.Gray")]
        public Color HeaderBackColor
        {
            get { return this.headerBackColor; }
            set { this.headerBackColor = value; Invalidate(); }
        }

        Image headerIcon = null;
        [Browsable(true), Category("Header")]
        public Image HeaderIcon
        {
            get { return this.headerIcon; }
            set { this.headerIcon = value; Invalidate(); }
        }

        RichPanelHelper.Align headerIconAlign = RichPanelHelper.Align.Right;
        [Browsable(true), Category("Header")]
        public RichPanelHelper.Align HeaderIconAlign
        {
            get { return this.headerIconAlign; }
            set { this.headerIconAlign = value; Invalidate(); }
        }

        SeparatorPosition separatorPosition = SeparatorPosition.Bottom;
        [Browsable(true), Category("Header")]
        [DefaultValue("SeparatorPosition.Bottom")]
        public SeparatorPosition SeparatorPos
        {
            get { return separatorPosition; }
            set { separatorPosition = value; Invalidate(); }
        }

        Color separatorColor = Color.Gray;
        [Browsable(true), Category("Header")]
        [DefaultValue("Color.Gray")]
        public Color SeparatorColor
        {
            get { return this.separatorColor; }
            set { this.separatorColor = value; Invalidate(); }
        }

        int separatorWidth = 3;
        [Browsable(true), Category("Header")]
        [DefaultValue(3)]
        public int SeparatorWidth
        {
            get { return separatorWidth; }
            set { separatorWidth = value; Invalidate(); }
        }

        bool expander = true;
        [Browsable(true), Category("Header")]
        [DefaultValue(true)]
        public bool Expander
        {
            get { return expander; }
            set { expander = value; Invalidate(); }
        }


        bool expanded = true;
        [Browsable(true), Category("Header")]
        [DefaultValue(true)]
        public bool Expanded
        {
            get { return expanded; }
            set { expanded = value; Invalidate(); }
        }

        private Rectangle expanderRectangle;
        private Size realSize;
        private bool inExpansion = false;
        private int headerHeight = 0;

        /*
         * Constructor
         */
        public RichPanel()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            //this.Padding = new Padding(5, this.headerHeight + 4, 5, 4);
        }

        /*
         * PRIVATE
         */
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (this.Width > 1 && this.Height > 1)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int tmpShadowOffSet = GetShadowOffSet();
                int tmpCornerRadius = GetCornerRadius();

                //Draw the Shadow
                if (DrawShadow)
                {
                    if (tmpCornerRadius > 0)
                    {
                        Rectangle rectShadow = new Rectangle(tmpShadowOffSet, tmpShadowOffSet, this.Width - tmpShadowOffSet - 1, this.Height - tmpShadowOffSet - 1);
                        GraphicsPath graphPathShadow = RichPanelHelper.GetRoundPath(rectShadow, tmpCornerRadius, this.roundCornerType);
                        using (PathGradientBrush gBrush = new PathGradientBrush(graphPathShadow))
                        {
                            gBrush.WrapMode = WrapMode.Clamp;
                            ColorBlend colorBlend = new ColorBlend(3);
                            colorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(180, Color.DimGray), Color.FromArgb(180, Color.DimGray) };
                            colorBlend.Positions = new float[] { 0f, .1f, 1f };
                            gBrush.InterpolationColors = colorBlend;

                            e.Graphics.FillPath(gBrush, graphPathShadow);
                        }
                    }
                }

                //Draw the background
                Rectangle rect = new Rectangle(0, 0, this.Width - tmpShadowOffSet - 1, this.Height - tmpShadowOffSet - 1);
                GraphicsPath graphPath = RichPanelHelper.GetRoundPath(rect, tmpCornerRadius, this.roundCornerType);
                if (this.FillStyle == RichPanelHelper.FillStyle.Gradient)
                {
                    LinearGradientBrush brush = new LinearGradientBrush(rect, this.BackgroundColor1, this.BackgroundColor2, this.GradientStyle);
                    e.Graphics.FillPath(brush, graphPath);
                }
                else if (this.FillStyle == RichPanelHelper.FillStyle.Solid)
                {
                    SolidBrush brush = new SolidBrush(this.BackgroundColor1);
                    e.Graphics.FillPath(brush, graphPath);
                }
                else
                {
                    SolidBrush brush = new SolidBrush(this.BackColor);
                    e.Graphics.FillPath(brush, graphPath);
                }

                //Draw the border
                if (DrawBorder)
                    e.Graphics.DrawPath(new Pen(Color.FromArgb(180, this.borderColor), borderWidth), graphPath);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            PaintHeader(pe.Graphics);
        }

        private void PaintHeader(Graphics graphics)
        {
            if (!DrawHeader)
                return;

            this.headerHeight = GetHeaderHeight(graphics);

            int tmpShadowOffSet = GetShadowOffSet();
            int tmpCornerRadius = GetCornerRadius();
            float margin = 3 + tmpCornerRadius / 4;

            List<float> separatorsXs = new List<float>();
            separatorsXs.Add(margin + 5);
            separatorsXs.Add(this.Width - tmpShadowOffSet - 7 - tmpCornerRadius / 4);

            //Text
            if (!string.IsNullOrEmpty(this.HeaderText))
            {
                float w = this.Width;
                if (this.headerTextAlign != RichPanelHelper.Align.Center)
                    w -= tmpShadowOffSet;

                SizeF size = graphics.MeasureString(this.HeaderText, this.HeaderFont);

                //Fill the header background
                if (HeaderHasBackColor)
                {
                    Rectangle rect = new Rectangle(0, 0, this.Width - tmpShadowOffSet - 1, headerHeight);
                    GraphicsPath graphPath = RichPanelHelper.GetRoundPath(rect, tmpCornerRadius, this.roundCornerType);

                    SolidBrush brush = new SolidBrush(this.HeaderBackColor);
                    graphics.FillPath(brush, graphPath);
                }

                //Draw the text
                float x = RichPanelHelper.GetXPos(this.HeaderTextAlign, w, size.Width, margin);
                using (Brush brush = new SolidBrush(this.HeaderTextColor))
                {
                    graphics.DrawString(this.HeaderText, this.HeaderFont, brush, x, (headerHeight - size.Height) / 2);
                }

                //Update separator position
                if (this.headerTextAlign == RichPanelHelper.Align.Left)
                    separatorsXs[0] = size.Width + 15;
                else if (this.headerTextAlign == RichPanelHelper.Align.Center)
                {
                    separatorsXs.Insert(1, x - 10);
                    separatorsXs.Insert(2, x + size.Width + 10);
                }
                else if (this.headerTextAlign == RichPanelHelper.Align.Right)
                    separatorsXs[1] = w - size.Width - 15 - tmpCornerRadius / 4;
            }

            //Image
            if (this.headerIcon != null)
            {
                float w = this.Width;
                if (this.headerIconAlign != RichPanelHelper.Align.Center)
                    w -= tmpShadowOffSet;

                //Draw the icon
                float x = RichPanelHelper.GetXPos(this.HeaderIconAlign, w, this.HeaderIcon.Width, margin);
                Point point = new Point((int)x, (headerHeight - this.HeaderIcon.Height) / 2);
                graphics.DrawImage(new Bitmap(this.HeaderIcon), point);

                //Update separator position
                if (this.HeaderIconAlign == RichPanelHelper.Align.Left)
                    separatorsXs[0] = x + this.headerIcon.Width + 10;
                else if (this.HeaderIconAlign == RichPanelHelper.Align.Center)
                {
                    separatorsXs.Insert(1, x - 10);
                    separatorsXs.Insert(2, x + this.headerIcon.Width + 10);
                }
                else if (this.HeaderIconAlign == RichPanelHelper.Align.Right)
                    separatorsXs[1] = w - this.headerIcon.Width - 10 - tmpCornerRadius / 4;
            }

            //Separator
            if (this.SeparatorPos != SeparatorPosition.None)
            {
                Pen pen = new Pen(this.SeparatorColor, SeparatorWidth);
                if (this.SeparatorPos == SeparatorPosition.Bottom)
                    graphics.DrawLine(pen,
                        this.BorderWidth, headerHeight,
                        this.Width - tmpShadowOffSet - this.BorderWidth, headerHeight);
                else
                {
                    float sepY = (headerHeight - this.SeparatorWidth) / 2;
                    for (int i = 0; i < separatorsXs.Count; i += 2)
                    {
                        graphics.DrawLine(pen,
                            new PointF(separatorsXs[i], sepY),
                            new PointF(separatorsXs[i + 1], sepY));
                    }
                }
            }

            //Expander
            if (this.Expander && this.shadowOffSet == 0)
            {
                Bitmap bitmap = GetExpanderBitmap();
                this.expanderRectangle = GetExpanderCoordinates(graphics);
                graphics.DrawImage(bitmap, this.expanderRectangle.X, this.expanderRectangle.Y);
            }
        }

        private int GetHeaderHeight(Graphics graphics)
        {
            int headerHeight = 25;
            if (!string.IsNullOrEmpty(this.HeaderText))
            {
                SizeF size = graphics.MeasureString(this.HeaderText, this.HeaderFont);
                if (size.Height > headerHeight)
                    headerHeight = (int)size.Height;
            }
            if (this.headerIcon != null)
            {
                if (this.headerIcon.Height > headerHeight)
                    headerHeight = this.headerIcon.Height;
            }
            return headerHeight;
        }

        private Bitmap GetExpanderBitmap()
        {
            if (this.Expanded)
                return Properties.Resources.expander_expand_hor;
            else
                return Properties.Resources.expander_collapse_hor;
        }

        private Rectangle GetExpanderCoordinates(Graphics graphics)
        {
            Bitmap bitmap = GetExpanderBitmap();

            int headerHeight = GetHeaderHeight(graphics);
            int x = (int)RichPanelHelper.GetXPos(RichPanelHelper.Align.Right, this.Width - GetShadowOffSet(), bitmap.Width, 5);
            int y = (headerHeight - bitmap.Height) / 2;
            return new Rectangle(x, y, bitmap.Width, bitmap.Height);
        }

        private int GetShadowOffSet()
        {
            if (!DrawShadow)
                return 0;
            return Math.Min(Math.Min(this.ShadowOffSet, this.Width - 2), this.Height - 2);
        }

        private int GetCornerRadius()
        {
            return Math.Min(Math.Min(cornerRadius, this.Width - 2), this.Height - 2);
        }

        private int noClick = 0;
        private void RichPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Expander && this.shadowOffSet == 0)
            {
                ++noClick;
                if (noClick == 2)
                {
                    noClick = 0;

                    if (this.expanderRectangle.IntersectsWith(new Rectangle(e.X, e.Y, 1, 1)))
                    {
                        this.Expanded = !this.Expanded;

                        ConfiguraExpansao();

                        Invalidate();
                        ExpandeChangedAction?.Invoke(Expanded, Name);
                    }
                }

            }
        }

        private void ConfiguraExpansao()
        {
            this.inExpansion = true;
            if (this.Expanded)
                this.Size = this.realSize;
            else
                this.Size = new Size(this.Width, this.headerHeight);
            this.inExpansion = false;
        }

        public void Contrair()
        {
            this.Expanded = false;
            ConfiguraExpansao();
        }

        private void RichPanel_SizeChanged(object sender, EventArgs e)
        {
            if (!this.inExpansion)
                this.realSize = this.Size;
        }
    }
}
