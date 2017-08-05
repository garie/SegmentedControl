using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace SegmentedControl.FormsPlugin.Abstractions
{
    /// <summary>
    /// SegmentedControl Interface
    /// </summary>
    public class SegmentedControl : View, IViewContainer<SegmentedControlOption>
    {
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public IList<SegmentedControlOption> Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SegmentedControl.FormsPlugin.Abstractions.SegmentedControl"/> class.
        /// </summary>
        public SegmentedControl()
        {
            Children = new List<SegmentedControlOption>();
        }

        /// <summary>
        /// The tint color property.
        /// </summary>
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create("TintColor", typeof(Color), typeof(SegmentedControl), Color.Blue);

        /// <summary>
        /// Gets or sets the color of the tint.
        /// </summary>
        /// <value>The color of the tint.</value>
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        /// <summary>
        /// The selected text color property.
        /// </summary>
        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create("SelectedTextColor", typeof(Color), typeof(SegmentedControl), Color.White);

        /// <summary>
        /// Gets or sets the color of the selected text.
        /// </summary>
        /// <value>The color of the selected text.</value>
        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        /// <summary>
        /// The selected segment property.
        /// </summary>
        public static readonly BindableProperty SelectedSegmentProperty = BindableProperty.Create("SelectedSegment", typeof(int), typeof(SegmentedControl), 0);

        /// <summary>
        /// Gets or sets the selected segment.
        /// </summary>
        /// <value>The selected segment.</value>
        public int SelectedSegment
        {
            get
            {
                return (int)GetValue(SelectedSegmentProperty);
            }
            set
            {
                SetValue(SelectedSegmentProperty, value);
            }
        }

        /// <summary>
        /// Occurs when value changed.
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        /// <summary>
        /// Sends the value changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendValueChanged()
        {
            ValueChanged?.Invoke(this, new ValueChangedEventArgs { SelectedIndex = this.SelectedSegment });
        }
    }

    /// <summary>
    /// Segmented control option.
    /// </summary>
    public class SegmentedControlOption : View
    {
        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(SegmentedControlOption), string.Empty);

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }

    /// <summary>
    /// Value changed event arguments.
    /// </summary>
    public class ValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex { get; set; }
    }
}
