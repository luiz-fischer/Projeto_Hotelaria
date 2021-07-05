using System.Drawing;

namespace System.Windows.Forms
{
    public class PlaceholderTextBox : TextBox
    {

        string _placeholderText = DEFAULT_PLACEHOLDER;
        bool _isPlaceholderActive = true;

        public bool IsPlaceholderActive
        {
            get { return _isPlaceholderActive; }
            private set
            {
                if (_isPlaceholderActive == value) return;

                SetStyle(ControlStyles.UserMouse, value);
                Invalidate();

                _isPlaceholderActive = value;
                OnPlaceholderActiveChanged(value);
            }
        }
    
        public string PlaceholderText
        {
            get { return _placeholderText; }
            set
            {
                _placeholderText = value;

                if (IsPlaceholderActive)
                    Text = value;
            }
        }

        public override string Text
        {
            get
            {
                if (IsPlaceholderActive && base.Text == PlaceholderText)
                    return "";

                return base.Text;
            }
            set { base.Text = value; }
        }

        Color _placeholderTextColor;
        public Color PlaceholderTextColor
        {
            get { return _placeholderTextColor; }
            set
            {
                if (_placeholderTextColor == value) return;
                _placeholderTextColor = value;

                if (DesignMode)
                    Invalidate();
            }
        }

        public Color TextColor { get; set; }
        public override Color ForeColor
        {
            get
            {
                if (IsPlaceholderActive)
                    return PlaceholderTextColor;

                return TextColor;
            }
            set { TextColor = value; }
        }


        public override int TextLength => IsPlaceholderActive ? 0 : base.TextLength;

        public event EventHandler<PlaceholderActiveChangedEventArgs> PlaceholderActiveChanged;


        const string DEFAULT_PLACEHOLDER = "<Input>";
        const int EM_SETSEL = 0x00B1;
        bool avoidTextChanged;

        public PlaceholderTextBox()
        {
            base.Text = PlaceholderText;
            TextColor = SystemColors.WindowText;
            PlaceholderTextColor = SystemColors.InactiveCaption;

            SetStyle(ControlStyles.UserMouse, true);
        }





        public void Reset()
        {
            if (IsPlaceholderActive) return;

            IsPlaceholderActive = true;

            Text = PlaceholderText;
            Select(0, 0);
        }

        private void ActionWithoutTextChanged(Action act)
        {
            avoidTextChanged = true;

            act.Invoke();

            avoidTextChanged = false;
        }

        private void UpdateText()
        {
            ActionWithoutTextChanged(delegate
            {
                if (!IsPlaceholderActive && String.IsNullOrEmpty(Text))
                {
                    MaxLength = 32767;
                    Reset();
                }
                else if (IsPlaceholderActive && Text.Length > 0)
                {
                    MaxLength = customMaxLength;

                    IsPlaceholderActive = false;

                    if (Text.EndsWith(PlaceholderText))
                    {
                        Text = Text.Substring(0, TextLength - PlaceholderText.Length);
                    }

                    if (Text.Length > MaxLength)
                        Text = Text.Substring(0, MaxLength);

                    Select(TextLength, 0);
                }
            });
        }




        int customMaxLength;
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            customMaxLength = MaxLength;
            MaxLength = 32767;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (avoidTextChanged) return;

            UpdateText();

            base.OnTextChanged(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (IsPlaceholderActive && m.Msg == EM_SETSEL) return;
            base.WndProc(ref m);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (IsPlaceholderActive)
            {
                if (e.KeyCode == Keys.Left ||
                    e.KeyCode == Keys.Right ||
                    e.KeyCode == Keys.Up ||
                    e.KeyCode == Keys.Down ||
                    e.KeyCode == Keys.Delete ||
                    e.KeyCode == Keys.Home ||
                    e.KeyCode == Keys.End ||
                    e.KeyCode == Keys.Back)
                {
                    e.SuppressKeyPress = true;
                }

                if (e.KeyCode == Keys.A && e.Modifiers.HasFlag(Keys.Control))
                {
                    e.SuppressKeyPress = true;
                }
            }

            base.OnKeyDown(e);
        }

        protected virtual void OnPlaceholderActiveChanged(bool newValue)
        {
            PlaceholderActiveChanged?.Invoke(this, new PlaceholderActiveChangedEventArgs(newValue));
        }



        bool selectionSet;

        protected override void OnGotFocus(EventArgs e)
        {
            bool needToDeselect = false;

            if (!selectionSet)
            {
                selectionSet = true;

                if (SelectionLength == 0 && MouseButtons == MouseButtons.None)
                {
                    needToDeselect = true;
                }
            }

            base.OnGotFocus(e);

            if (!needToDeselect) return;

            SelectionStart = 0;
            DeselectAll();
        }

    }


    public class PlaceholderActiveChangedEventArgs : EventArgs
    {
        public PlaceholderActiveChangedEventArgs(bool isActive)
        {
            IsActive = isActive;
        }

        public bool IsActive { get; private set; }
    }
}