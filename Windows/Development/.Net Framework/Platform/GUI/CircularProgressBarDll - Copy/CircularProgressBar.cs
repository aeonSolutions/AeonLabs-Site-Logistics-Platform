using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CircularProgressBar.CircularProgress
{
    public class CircularProgressBar : UserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Size minimumSizeAllowed;
        private Size _minimumSize;
        private int _barCount = 4;
        private BarData[] _bars = new BarData[5];
        private System.Timers.Timer _smoothTimer;
        private bool _borderEnabled = false;
        private Image _image = null;
        private int _barSeperation = 1;
        private int _barWidth = 4;
        private bool _displayPercentage = true;
        private bool _displayTotalPercentage = false;
        private bool _smoothBars = false;
        private string _info = "Data";
        private bool _textShadow = false;
        private Color _textShadowColor = Color.White;
        private bool _inactiveColorEnabled = true;
        private bool _imageEnabled = true;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public CircularProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            for (int i = 0, loopTo = _bars.Count() - 1; i <= loopTo; i++)
            {
                _bars[i] = new BarData(i + 1);
                _bars[i].PropertyChanged += Bars_PropertyChanged;
            }

            Size = new Size(150, 150);
            base.Font = new Font("Verdana", 14.0F);
            _smoothTimer = new System.Timers.Timer();
            _smoothTimer.Elapsed += Smoother_Tick;
            _smoothTimer.Enabled = false;
            _smoothTimer.Interval = 1;
            SetMinimumSize();
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle = 0x20;
                return cp;
            }
        }

        public override Size MinimumSize
        {
            get
            {
                return _minimumSize;
            }

            set
            {
                if (value.Height < minimumSizeAllowed.Height)
                    value.Height = minimumSizeAllowed.Height;
                if (value.Width < minimumSizeAllowed.Width)
                    value.Height = minimumSizeAllowed.Height;
                _minimumSize = value;
            }
        }

        public override string Text
        {
            get
            {
                return _info;
            }

            set
            {
                _info = value;
                RefreshControl();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int circleSize = _barWidth;
            var realPercentage = new float[_barCount + 1];
            var setPercentage = new float[_barCount + 1];
            var currentAngle = new float[_barCount + 1];
            var remainderAngle = new float[_barCount + 1];
            for (int i = 0, loopTo = _barCount; i <= loopTo; i++)
            {
                if (!_bars[i].Enabled)
                    continue;
                setPercentage[i] = (float)(_bars[i].SmoothValue / (double)_bars[i].Maximum * 100);
                realPercentage[i] = (float)(_bars[i].Value / (double)_bars[i].Maximum * 100);
                currentAngle[i] = (float)(360 / (double)100 * setPercentage[i]);
                remainderAngle[i] = 360 - currentAngle[i];
            }

            using (var B = new Bitmap(Width, Height))
            {
                using (var G = Graphics.FromImage(B))
                {
                    G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    if (BackColor != Color.Transparent)
                    {
                        G.Clear(BackColor);
                    }

                    for (int i = 0, loopTo1 = _barCount; i <= loopTo1; i++)
                    {
                        if (!_bars[i].Enabled)
                            continue;
                        Color colorToUse;
                        if (_bars[i].SmoothValue >= _bars[i].Maximum)
                        {
                            colorToUse = _bars[i].FinishColor;
                        }
                        else
                        {
                            colorToUse = _bars[i].ActiveColor;
                        }

                        using (var progressPen = new Pen(colorToUse, circleSize))
                        using (var remainderPen = new Pen(_bars[i].InactiveColor, circleSize))
                        using (var BorderPen = new Pen(_bars[i].BorderColor, circleSize + 2))
                        {
                            progressPen.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                            progressPen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                            remainderPen.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                            remainderPen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                            BorderPen.StartCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                            BorderPen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                            if (_borderEnabled)
                            {
                                if (_inactiveColorEnabled)
                                {
                                    G.DrawArc(BorderPen, _barSeperation * i + circleSize * (i + 1), _barSeperation * i + circleSize * (i + 1), Width - _barSeperation * i * 2 - (i + 1) * circleSize * 2, Height - _barSeperation * i * 2 - (i + 1) * circleSize * 2, 0, 360);
                                }
                                else if (currentAngle[i] >= 1)
                                    G.DrawArc(BorderPen, _barSeperation * i + circleSize * (i + 1), _barSeperation * i + circleSize * (i + 1), Width - _barSeperation * i * 2 - (i + 1) * circleSize * 2, Height - _barSeperation * i * 2 - (i + 1) * circleSize * 2, -90, currentAngle[i]);
                            }

                            if (currentAngle[i] >= 1)
                                G.DrawArc(progressPen, _barSeperation * i + circleSize * (i + 1), _barSeperation * i + circleSize * (i + 1), Width - _barSeperation * i * 2 - (i + 1) * circleSize * 2, Height - _barSeperation * i * 2 - (i + 1) * circleSize * 2, -90, currentAngle[i]);
                            if (_inactiveColorEnabled && remainderAngle[i] >= 1)
                                G.DrawArc(remainderPen, _barSeperation * i + circleSize * (i + 1), _barSeperation * i + circleSize * (i + 1), Width - _barSeperation * i * 2 - (i + 1) * circleSize * 2, Height - _barSeperation * i * 2 - (i + 1) * circleSize * 2, currentAngle[i] - 90, remainderAngle[i]);
                        }
                    }

                    if (Image is object)
                        G.DrawImage(Image, new Point((int)((int)(Width / (double)2) - Image.Width / (double)2), (int)((int)(Height / (double)2) - Image.Height / (double)2)));
                    using (var fnt = new Font(base.Font.FontFamily, base.Font.Size))
                    {
                        string textDisplay = string.Empty;
                        if (_displayPercentage)
                        {
                            if (_displayTotalPercentage)
                            {
                                int percentageCalculate = 0;
                                for (int i = 0, loopTo2 = _barCount; i <= loopTo2; i++)
                                {
                                    if (!_bars[i].Enabled)
                                        continue;
                                    percentageCalculate += realPercentage[i];
                                }

                                percentageCalculate /= (double)_barCount;
                                textDisplay += percentageCalculate.ToString() + "%";
                            }
                            else
                            {
                                for (int i = 0, loopTo3 = _barCount; i <= loopTo3; i++)
                                {
                                    if (!_bars[i].Enabled)
                                        continue;
                                    if ((textDisplay ?? "") == (string.Empty ?? ""))
                                    {
                                        textDisplay += realPercentage[i].ToString() + "%";
                                    }
                                    else
                                    {
                                        textDisplay += Constants.vbNewLine + realPercentage[i].ToString() + "%";
                                    }
                                }
                            }
                        }
                        else
                        {
                            textDisplay = _info;
                        }

                        var stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Center;
                        stringFormat.LineAlignment = StringAlignment.Center;
                        var textRect = new Rectangle(0, 0, Width, Height);
                        if (_textShadow)
                        {
                            var textRectShadow = new Rectangle(1, 1, Width, Height);
                            G.DrawString(textDisplay, fnt, new SolidBrush(_textShadowColor), textRectShadow, stringFormat);
                        }

                        G.DrawString(textDisplay, fnt, new SolidBrush(base.ForeColor), textRect, stringFormat);
                    }

                    e.Graphics.DrawImageUnscaled(B, 0, 0);
                }
            }
        }

        [DisplayName("BackColor")]
        [Description("Gets or Sets the enabled value of the back color to use.")]
        [Category("Bar Info")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
                RefreshControl();
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [DisplayName("Bar #1")]
        [Description("Bar #1 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar1
        {
            get
            {
                return _bars[0];
            }

            set
            {
                _bars[0] = value;
            }
        }

        [DisplayName("Bar #2")]
        [Description("Bar #2 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar2
        {
            get
            {
                return _bars[1];
            }

            set
            {
                _bars[1] = value;
            }
        }

        [DisplayName("Bar #3")]
        [Description("Bar #3 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar3
        {
            get
            {
                return _bars[2];
            }

            set
            {
                _bars[2] = value;
            }
        }

        [DisplayName("Bar #4")]
        [Description("Bar #4 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar4
        {
            get
            {
                return _bars[3];
            }

            set
            {
                _bars[3] = value;
            }
        }

        [DisplayName("Bar #5")]
        [Description("Bar #5 Data")]
        [Category("Bars")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BarData Bar5
        {
            get
            {
                return _bars[4];
            }

            set
            {
                _bars[4] = value;
            }
        }

        [DefaultValue(1)]
        [DisplayName("Bar Seperation")]
        [Description("Gets or Sets the bar seperation value. This is the amount in pixels the distance between each bar defined.")]
        [Category("Bar Info")]
        public int Seperation
        {
            get
            {
                return _barSeperation;
            }

            set
            {
                if (value < 0)
                    value = 0;
                _barSeperation = value;
                RefreshControl();
                SetMinimumSize();
            }
        }

        [DefaultValue(4)]
        [DisplayName("Bar Width")]
        [Description("Gets or Sets the bar width. This is the actual bar width, per bar.")]
        [Category("Bar Info")]
        public int BarWidth
        {
            get
            {
                return _barWidth;
            }

            set
            {
                _barWidth = value;
                RefreshControl();
                SetMinimumSize();
            }
        }

        [DefaultValue(true)]
        [DisplayName("Display Percentages")]
        [Description("Gets or Sets the display of bar percentages. This will display a percentage per bar displayed.")]
        [Category("Bar Info")]
        public bool DisplayPercentage
        {
            get
            {
                return _displayPercentage;
            }

            set
            {
                _displayPercentage = value;
                RefreshControl();
            }
        }

        [DefaultValue(false)]
        [DisplayName("Display Total Percentage")]
        [Description("Gets or Sets the display of a total percentage. This will calculate all the bars and display only one percentage.")]
        [Category("Bar Info")]
        public bool DisplayTotalPercentage
        {
            get
            {
                return _displayTotalPercentage;
            }

            set
            {
                _displayTotalPercentage = value;
                RefreshControl();
            }
        }

        [DefaultValue(false)]
        [DisplayName("Smooth Bars")]
        [Description("Gets or Sets if the bars will increment in a smooth motion. This is good if your values change heavier and you want a smooth look to them.")]
        [Category("Bar Info")]
        public bool SmoothBars
        {
            get
            {
                return _smoothBars;
            }

            set
            {
                _smoothBars = value;
                RefreshControl();
            }
        }

        [DefaultValue("Data")]
        [DisplayName("Text Data")]
        [Description("Gets or Sets the text when percentages is not enabled. This will display a set text (that can be edited at runtime) rather then percentages if 'Display Percentages' is disabled.")]
        [Category("Appearance")]
        public string Info
        {
            get
            {
                return _info;
            }

            set
            {
                _info = value;
                RefreshControl();
            }
        }

        [DefaultValue(false)]
        [DisplayName("Text Shadow")]
        [Description("Gets or Sets there will be text shadowing.")]
        [Category("Appearance")]
        public bool TextShadow
        {
            get
            {
                return _textShadow;
            }

            set
            {
                _textShadow = value;
                RefreshControl();
            }
        }

        [DefaultValue(typeof(Color), "Color.White")]
        [DisplayName("Text Shadow Color")]
        [Description("Gets or Sets the color of text shadowing. This requires the Text Shadow boolean to be true.")]
        [Category("Appearance")]
        public Color TextShadowColor
        {
            get
            {
                return _textShadowColor;
            }

            set
            {
                _textShadowColor = value;
                RefreshControl();
            }
        }

        [DefaultValue("Nothing")]
        [DisplayName("Image")]
        [Description("Gets or Sets the bar image. This will display a bar image in the middle of the bar.")]
        [Category("Bar Info")]
        public Image Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                RefreshControl();
            }
        }

        [DefaultValue(false)]
        [DisplayName("Borders Enabled")]
        [Description("Gets or Sets the enabled value of the border around the bar.")]
        [Category("Bar Info")]
        public bool BorderEnabled
        {
            get
            {
                return _borderEnabled;
            }

            set
            {
                _borderEnabled = value;
                RefreshControl();
            }
        }

        [DefaultValue(true)]
        [DisplayName("Inactive Colors Enabled")]
        [Description("Gets or Sets the enabled value of the inactive colors. If this is disabled, then the inactive bars won't be displayed.")]
        [Category("Bar Info")]
        public bool InactiveColorEnabled
        {
            get
            {
                return _inactiveColorEnabled;
            }

            set
            {
                _inactiveColorEnabled = value;
                RefreshControl();
            }
        }

        [DefaultValue(true)]
        [DisplayName("Image Enabled")]
        [Description("Gets or Sets the enabled value of the image. If this is disabled, the image will not be rendered.")]
        [Category("Bar Info")]
        public bool ImageEnabled
        {
            get
            {
                return _imageEnabled;
            }

            set
            {
                _imageEnabled = value;
                RefreshControl();
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Smoother_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            bool allDone = true;
            for (int i = 0, loopTo = _barCount; i <= loopTo; i++)
            {
                if (_bars[i].Value > _bars[i].SmoothValue)
                {
                    _bars[i].SmoothValue += _bars[i].SmoothAmount;
                    if (_bars[i].SmoothValue > _bars[i].Value)
                        _bars[i].SmoothValue = _bars[i].Value;
                    allDone = false;
                }
                else if (_bars[i].Value < _bars[i].SmoothValue)
                {
                    _bars[i].SmoothValue -= _bars[i].SmoothAmount;
                    if (_bars[i].SmoothValue < _bars[i].Value)
                        _bars[i].SmoothValue = _bars[i].Value;
                    allDone = false;
                }
            }

            if (allDone)
                _smoothTimer.Enabled = false;
        }

        private void RefreshControl()
        {
            Invalidate();
        }

        public bool ShouldSerializeBars()
        {
            return _bars is object;
        }

        public void ResetBars()
        {
            for (int i = 0, loopTo = _bars.Count() - 1; i <= loopTo; i++)
            {
                _bars[i] = new BarData(i);
                _bars[i].PropertyChanged += Bars_PropertyChanged;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private void Bars_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Enabled")
                SetMinimumSize();
            if (e.PropertyName == "Value")
            {
                if (_smoothBars == true)
                {
                    _smoothTimer.Enabled = true;
                }
                else
                {
                    BarData bar = (BarData)sender;
                    bar.SmoothValue = bar.Value;
                }
            }

            RefreshControl();
        }

        private void SetMinimumSize()
        {
            int bCount = 0;
            for (int i = _bars.Count() - 1; i >= 0; i -= 1)
            {
                if (_bars[i].Enabled)
                {
                    bCount = i + 1;
                    break;
                }
            }

            int minSize = (bCount + 1) * (_barWidth + _barSeperation) * 2;
            minimumSizeAllowed = new Size(minSize, minSize);
            MinimumSize = minimumSizeAllowed;
            int width = Size.Width;
            int height = Size.Width;
            if (width < minSize)
                width = minSize;
            if (height < minSize)
                height = minSize;
            Size = new Size(width, height);
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}