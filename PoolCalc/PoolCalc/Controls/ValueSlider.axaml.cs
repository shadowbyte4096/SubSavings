using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

namespace PoolCalc.Controls
{
    public partial class ValueSlider : ContentControl
    {
        public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<ValueSlider, string>(nameof(Text));

        public string Text
        {
            get { return GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly StyledProperty<double> ScalingProperty =
        AvaloniaProperty.Register<ValueSlider, double>(nameof(Scaling));

        public double Scaling
        {
            get { return GetValue(ScalingProperty); }
            set { SetValue(ScalingProperty, value); }
        }

        public static readonly StyledProperty<string> MinValueProperty =
        AvaloniaProperty.Register<ValueSlider, string>(nameof(MinValue));

        public string MinValue
        {
            get { return GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly StyledProperty<string> MaxValueProperty =
        AvaloniaProperty.Register<ValueSlider, string>(nameof(MaxValue));

        public string MaxValue
        {
            get { return GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public ValueSlider()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
