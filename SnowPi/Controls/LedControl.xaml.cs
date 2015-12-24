using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SnowPi.Controls
{
    public sealed partial class LedControl : UserControl
    {
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
            "IsActive", typeof (bool), typeof (LedControl), null);

        public static readonly DependencyProperty BulbColourProperty = DependencyProperty.Register(
            "BulbColour", typeof (Color), typeof (LedControl), new PropertyMetadata(default(Color)));

        public LedControl()
        {
            InitializeComponent();
        }

        public Color BulbColour
        {
            get { return (Color) GetValue(BulbColourProperty); }
            set { SetValue(BulbColourProperty, value); }
        }

        public bool IsActive
        {
            get { return (bool) GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
    }
}