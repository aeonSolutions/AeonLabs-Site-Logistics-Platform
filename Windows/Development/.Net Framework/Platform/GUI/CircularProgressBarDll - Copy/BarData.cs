using System.ComponentModel;
using System.Drawing;

namespace CircularProgressBar.CircularProgress
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BarData : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _barID;
        private bool _enabled = false;
        private int _smoothAmount = 1;
        private int _smoothValue = 0;
        private int _value = 0;
        private int _maximum = 100;
        private Color _borderColor = Color.Black;
        private Color _finishColor = Color.LightGreen;
        private Color _activeColor = Color.LightSeaGreen;
        private Color _inactiveColor = Color.LightGray;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public BarData(int barID)
        {
            _barID = barID;
            if (_barID == 1)
                Enabled = true;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public override string ToString()
        {
            return "Data #" + _barID;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [DefaultValue(false)]
        [DisplayName("Enabled")]
        [Description("Gets or Sets the enabled value of the bar. If the bar is enabled, then the bar will be visible.")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                if (_barID == 1)
                    value = true;
                _enabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Enabled"));
            }
        }

        [DefaultValue(1)]
        [DisplayName("Smooth Amount")]
        [Description("Gets or Sets the smooth amount per timer tick. The higher this is, the less smooth it will look, but the faster it will go. Setting it lower will feel more smooth, but may take too long.")]
        public int SmoothAmount
        {
            get
            {
                return _smoothAmount;
            }

            set
            {
                _smoothAmount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SmoothAmount"));
            }
        }

        internal int SmoothValue
        {
            get
            {
                return _smoothValue;
            }

            set
            {
                if (value < 0)
                    value = 0;
                if (value > _maximum)
                    value = _maximum;
                _smoothValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SmoothValue"));
            }
        }

        [DefaultValue(0)]
        [DisplayName("Value")]
        [Description("Gets or Sets the value. The value cannot be higher then maximum, and less then 0.")]
        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (value < 0)
                    value = 0;
                if (value > _maximum)
                    value = _maximum;
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        [DefaultValue(100)]
        [DisplayName("Maximum")]
        [Description("Gets or Sets the maximum value. The value cannot lower then 1.")]
        public int Maximum
        {
            get
            {
                return _maximum;
            }

            set
            {
                if (value < 1)
                    value = 1;
                if (_value > value)
                {
                    _smoothValue = value;
                    _value = value;
                }

                _maximum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Maximum"));
            }
        }

        [DefaultValue(typeof(Color), "Color.Black")]
        [DisplayName("Border Color")]
        [Description("Gets or Sets the border color. This is the color for the border itself aroudn the bar.")]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }

            set
            {
                _borderColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BorderColor"));
            }
        }

        [DefaultValue(typeof(Color), "Color.LightGreen")]
        [DisplayName("Finish Color")]
        [Description("Gets or Sets the finish color. This is the color of the bar when the bar value is equal to maximum value.")]
        public Color FinishColor
        {
            get
            {
                return _finishColor;
            }

            set
            {
                _finishColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FinishColor"));
            }
        }

        [DefaultValue(typeof(Color), "Color.LightSeaGreen")]
        [DisplayName("Active Color")]
        [Description("Gets or Sets the active color. This is the color of the active portion of the bar while not complete.")]
        public Color ActiveColor
        {
            get
            {
                return _activeColor;
            }

            set
            {
                _activeColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ActiveColor"));
            }
        }

        [DefaultValue(typeof(Color), "Color.LightGray")]
        [DisplayName("Inactive Color")]
        [Description("Gets or Sets the inactive color. This is the color of the inactive portion of the bar while not complete.")]
        public Color InactiveColor
        {
            get
            {
                return _inactiveColor;
            }

            set
            {
                _inactiveColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InactiveColor"));
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Increment(int amount)
        {
            Value += amount;
        }

        public void Decrement(int amount)
        {
            Value -= amount;
        }

        public void Reset()
        {
            Value = 0;
        }

        public void Max()
        {
            Value = Maximum;
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}