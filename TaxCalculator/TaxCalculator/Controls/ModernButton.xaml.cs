using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModernButton : ContentView
	{

        public ModernButton ()
		{
			InitializeComponent ();
        }

        #region Bindable Properties related to Button Text

        #region ButtonText Bindable Implementation

        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(
            nameof(ButtonText), typeof(string), typeof(ModernButton), default(string), propertyChanged: HandleButtonTextPropertyChanged);

        private static void HandleButtonTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonText.Text = (string)newValue;
        }

        public string ButtonText
        {
            get => (string)GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        #endregion

        #region ButtonTextMargin Bindable Implementation

        public static readonly BindableProperty ButtonTextMarginProperty = BindableProperty.Create(
            nameof(ButtonTextMargin), typeof(Thickness), typeof(ModernButton), null, propertyChanged: HandleButtonTextMarginPropertyChanged);

        private static void HandleButtonTextMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonText.Margin = (Thickness)newValue;
        }

        //Prefer (10,0,0,0)
        public Thickness ButtonTextMargin
        {
            get => (Thickness)GetValue(ButtonTextMarginProperty);
            set => SetValue(ButtonTextMarginProperty, value);
        }

        #endregion

        #region ButtonTextHorizontalOptions Bindable Implementation

        public static readonly BindableProperty ButtonTextHorizontalOptionsProperty = BindableProperty.Create(
            nameof(ButtonTextHorizontalOptions), typeof(LayoutOptions), typeof(ModernButton), LayoutOptions.Start, propertyChanging: HandleButtonTextHorizontalOptionsPropertyChanged);

        private static void HandleButtonTextHorizontalOptionsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonText.HorizontalOptions = (LayoutOptions)newValue;
        }

        public LayoutOptions ButtonTextHorizontalOptions
        {
            get => ModernButtonText.HorizontalOptions;
            set => ModernButtonText.HorizontalOptions = value;
        }

        #endregion

        #region ButtonTextVerticalOptions Bindable Implementation

        public static readonly BindableProperty ButtonTextVerticalOptionsProperty = BindableProperty.Create(
            nameof(ButtonTextVerticalOptions), typeof(LayoutOptions), typeof(ModernButton), null, propertyChanged: HandleButtonTextVerticalOptionsPropertyChanged);

        private static void HandleButtonTextVerticalOptionsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonText.VerticalOptions = (LayoutOptions)newValue;
        }

        public LayoutOptions ButtonTextVerticalOptions
        {
            get => (LayoutOptions)GetValue(ButtonTextVerticalOptionsProperty);
            set => SetValue(ButtonTextVerticalOptionsProperty, value);
        }

        #endregion

        #region  ButtonTextFontSize Bindable Implementation

        public static readonly BindableProperty ButtonTextFontSizeProperty = BindableProperty.Create(
            nameof(ButtonTextFontSize), typeof(NamedSize), typeof(ModernButton), NamedSize.Default, propertyChanged: HandleButtonTextFontSizePropertyChanged);

        private static void HandleButtonTextFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
            {
                var convertToNamedSize = (NamedSize)newValue;
                var convertToNumString = new FontSizeConverter().ConvertFromInvariantString(convertToNamedSize.ToString()).ToString();
                targetView.ModernButtonText.FontSize = double.Parse(convertToNumString);
            }
        }

        public double ButtonTextFontSize
        {
            get => (double)GetValue(ButtonTextFontSizeProperty);
            set => SetValue(ButtonTextFontSizeProperty, value);
        }

        #endregion

        #region ButtonTextFontColor Bindable Implementation

        public static readonly BindableProperty ButtonTextFontColorProperty = BindableProperty.Create(
            nameof(ButtonTextFontColor), typeof(Color), typeof(ModernButton), Color.Black, propertyChanged: HandleButtonTextFontColorPropertyChanged);

        private static void HandleButtonTextFontColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonText.TextColor = (Color)newValue;
        }

        public Color ButtonTextFontColor
        {
            get => (Color)GetValue(ButtonTextFontColorProperty);
            set => SetValue(ButtonTextFontColorProperty, value);
        }

        #endregion

        #endregion

        #region Bindable Properties related to Button Frame

        #region ButtonBackgroundColor Bindable Implementation

        public static readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(
          nameof(ButtonBackgroundColor), typeof(Color), typeof(ModernButton), Color.Black, propertyChanged: HandleButtonBackgroundColorPropertyChanged);

        private static void HandleButtonBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonFrame.BackgroundColor = (Color)newValue;
        }

        public Color ButtonBackgroundColor
        {
            get => (Color)GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }

        #endregion

        #region ButtonCornerRadius Bindable Implementation

        public static readonly BindableProperty ButtonCornerRadiusProperty = BindableProperty.Create(
            nameof(ButtonCornerRadius), typeof(float), typeof(ModernButton), null, propertyChanged: HandleButtonCornerRadiusPropertyChanged);

        private static void HandleButtonCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonFrame.CornerRadius = (float)newValue;
        }

        public float ButtonCornerRadius
        {
            get => (float)GetValue(ButtonCornerRadiusProperty);
            set => SetValue(ButtonCornerRadiusProperty, value);
        }

        #endregion

        #region ButtonBorderColor Bindable Implementation

        public static readonly BindableProperty ButtonBorderColorProperty = BindableProperty.Create(
          nameof(ButtonBorderColor), typeof(Color), typeof(ModernButton), Color.Black, propertyChanged: HandleButtonBorderColorPropertyChanged);

        private static void HandleButtonBorderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonFrame.BorderColor = (Color)newValue;
        }

        public Color ButtonBorderColor
        {
            get => (Color)GetValue(ButtonBorderColorProperty);
            set => SetValue(ButtonBorderColorProperty, value);
        }

        #endregion

        #region ButtonHasShadow Bindable Implementation

        public static readonly BindableProperty ButtonHasShadowProperty = BindableProperty.Create(
          nameof(ButtonHasShadow), typeof(bool), typeof(ModernButton), false, propertyChanged: HandleButtonHasShadowPropertyChanged);

        private static void HandleButtonHasShadowPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonFrame.HasShadow= (bool)newValue;
        }

        public bool ButtonHasShadow
        {
            get => (bool)GetValue(ButtonHasShadowProperty);
            set => SetValue(ButtonHasShadowProperty, value);
        }

        #endregion

        #endregion

        #region Bindable Properties related to Button Icon

        #region ButtonIconSource Bindable Implementation

        public static readonly BindableProperty ButtonIconSourceProperty = BindableProperty.Create(
            nameof(ButtonIconSource), typeof(ImageSource), typeof(ModernButton), null, propertyChanged: HandleButtonIconSourcePropertyChanged);

        private static void HandleButtonIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonIcon.Source = (ImageSource)newValue;
        }

        public ImageSource ButtonIconSource
        {
            get => (ImageSource)GetValue(ButtonIconSourceProperty);
            set => SetValue(ButtonIconSourceProperty, value);
        }

        #endregion

        #region ButtonIconAspect Bindable Implementation

        public static readonly BindableProperty ButtonIconAspectProperty = BindableProperty.Create(
            nameof(ButtonIconAspect), typeof(Aspect), typeof(ModernButton), Aspect.AspectFit, propertyChanged: HandleButtonIconAspectPropertyChanged);

        private static void HandleButtonIconAspectPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonIcon.Aspect = (Aspect)newValue;
        }
        public Aspect ButtonIconAspect
        {
            get => (Aspect)GetValue(ButtonIconAspectProperty);
            set => SetValue(ButtonIconAspectProperty, value);
        }

        #endregion

        #region ButtonIconMargin Bindable Implementation

        public static readonly BindableProperty ButtonIconMarginProperty = BindableProperty.Create(
            nameof(ButtonIconMargin), typeof(Thickness), typeof(ModernButton), null, propertyChanged: HandleButtonIconMarginPropertyChanged);

        private static void HandleButtonIconMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonIcon.Margin = (Thickness)newValue;
        }

        public Thickness ButtonIconMargin
        {
            get => (Thickness)GetValue(ButtonIconMarginProperty);
            set => SetValue(ButtonIconMarginProperty, value);
        }

        #endregion

        #endregion

        #region Bindable Properties to control Button Layout

        #region ButtonHeight Bindable Implementation

        public static readonly BindableProperty ButtonHeightProperty = BindableProperty.Create(
            nameof(ButtonHeight), typeof(GridLength), typeof(ModernButton), null, propertyChanged: HandleButtonHeightPropertyChanged);

        private static void HandleButtonHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonHeight.Height = (GridLength)newValue;
        }

        public GridLength ButtonHeight
        {
            get => (GridLength)GetValue(ButtonHeightProperty);
            set => SetValue(ButtonHeightProperty, value);
        }

        #endregion

        #region ButtonIconWidth Bindable Implementation

        public static readonly BindableProperty ButtonIconWidthProperty = BindableProperty.Create(
            nameof(ButtonIconWidth), typeof(GridLength), typeof(ModernButton), GridLength.Auto, propertyChanged: HandleButtonIconWidthPropertyChanged);

        private static void HandleButtonIconWidthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonIconWidth.Width = (GridLength)newValue;
        }

        public GridLength ButtonIconWidth
        {
            get => (GridLength)GetValue(ButtonIconWidthProperty);
            set => SetValue(ButtonIconWidthProperty, value);
        }

        #endregion

        #region ButtonLabelWidth Bindable Implementation

        public static readonly BindableProperty ButtonLabelWidthProperty = BindableProperty.Create(
            nameof(ButtonLabelWidth), typeof(GridLength), typeof(ModernButton), GridLength.Star, propertyChanged: HandleButtonLabelWidthPropertyChanged);

        private static void HandleButtonLabelWidthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ModernButton targetView;
            targetView = (ModernButton)bindable;
            if (targetView != null)
                targetView.ModernButtonTextWidth.Width = (GridLength)newValue;
        }

        public GridLength ButtonLabelWidth
        {
            get => (GridLength)GetValue(ButtonLabelWidthProperty);
            set => SetValue(ButtonLabelWidthProperty, value);
        }

        #endregion

        #endregion
    }
}