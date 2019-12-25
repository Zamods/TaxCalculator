using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TaxCalculator.Controls
{
    public class ModernButton : ContentView
    {
        public ModernButton()
        {

            //Properties for grid
            var ModernButtonHeight = 50;
            RowDefinitionCollection ModernButtonRowDef = new RowDefinitionCollection()
            {
                new RowDefinition()
                {
                    Height = ModernButtonHeight
                }
            };
            ColumnDefinitionCollection ModernButtonColDef = new ColumnDefinitionCollection()
            {
                new ColumnDefinition()
                {
                    Width = GridLength.Auto
                },
                new ColumnDefinition()
                {
                    Width = GridLength.Star
                }
            };

            //Properties for children
            Image ModernButtonIcon = new Image()
            {
                Aspect = Aspect.AspectFit,
                Margin = new Thickness(20.0, 0.0, 10.0, 0.0)
            };
            Label ModernButtonText = new Label()
            {
                Margin = new Thickness(10.0, 0.0, 10.0, 0.0),
                FontSize = (double)new FontSizeConverter().ConvertFromInvariantString("Medium"),
                VerticalOptions = LayoutOptions.Center
            };

            //Adding elements to Grid
            Grid ModernButtonLayout = new Grid()
            {
                ColumnDefinitions = ModernButtonColDef,
                RowDefinitions = ModernButtonRowDef,
            };

            //Adding children to grid
            Grid.SetColumn(ModernButtonIcon, 0);
            Grid.SetRow(ModernButtonIcon, 0);
            Grid.SetColumn(ModernButtonText, 1);
            Grid.SetRow(ModernButtonText, 0);

            Content = ModernButtonLayout;
        }
       
        #region Bindable Properties related to Button Text

        #region ButtonText Bindable Implementation

        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(
            nameof(ButtonText), typeof(string), typeof(CustomImageButton), default(string), propertyChanged: HandleButtonTextPropertyChanged);

        private static void HandleButtonTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.FlatButtonHeading.Text = (string)newValue;
        }

        public string ButtonText
        {
            get => (string)GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        #endregion

        #region ButtonTextMargin Bindable Implementation

        public static readonly BindableProperty ButtonTextMarginProperty = BindableProperty.Create(
            nameof(ButtonTextMargin), typeof(Thickness), typeof(CustomImageButton), null, propertyChanged: HandleButtonTextMarginPropertyChanged);

        private static void HandleButtonTextMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.FlatButtonHeading.Margin = (Thickness)newValue;
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
            nameof(ButtonTextHorizontalOptions), typeof(LayoutOptions), typeof(CustomImageButton), LayoutOptions.Start, propertyChanging: HandleButtonTextHorizontalOptionsPropertyChanged);

        private static void HandleButtonTextHorizontalOptionsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.FlatButtonHeading.HorizontalOptions = (LayoutOptions)newValue;
        }

        public LayoutOptions ButtonTextHorizontalOptions
        {
            get => FlatButtonHeading.HorizontalOptions;
            set => FlatButtonHeading.HorizontalOptions = value;
        }

        #endregion

        #region ButtonTextVerticalOptions Bindable Implementation

        public static readonly BindableProperty ButtonTextVerticalOptionsProperty = BindableProperty.Create(
            nameof(ButtonTextVerticalOptions), typeof(LayoutOptions), typeof(CustomImageButton), null, propertyChanged: HandleButtonTextVerticalOptionsPropertyChanged);

        private static void HandleButtonTextVerticalOptionsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.FlatButtonHeading.VerticalOptions = (LayoutOptions)newValue;
        }

        public LayoutOptions ButtonTextVerticalOptions
        {
            get => (LayoutOptions)GetValue(ButtonTextVerticalOptionsProperty);
            set => SetValue(ButtonTextVerticalOptionsProperty, value);
        }

        #endregion

        #region  ButtonTextFontSize Bindable Implementation

        public static readonly BindableProperty ButtonTextFontSizeProperty = BindableProperty.Create(
            nameof(ButtonTextFontSize), typeof(NamedSize), typeof(CustomImageButton), NamedSize.Default, propertyChanged: HandleButtonTextFontSizePropertyChanged);

        private static void HandleButtonTextFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
            {
                var convertToNamedSize = (NamedSize)newValue;
                var convertToNumString = new FontSizeConverter().ConvertFromInvariantString(convertToNamedSize.ToString()).ToString();
                targetView.FlatButtonHeading.FontSize = double.Parse(convertToNumString);
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
            nameof(ButtonTextFontColor), typeof(Color), typeof(CustomImageButton), Color.Black, propertyChanged: HandleButtonTextFontColorPropertyChanged);

        private static void HandleButtonTextFontColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.FlatButtonHeading.TextColor = (Color)newValue;
        }

        public Color ButtonTextFontColor
        {
            get => (Color)GetValue(ButtonTextFontColorProperty);
            set => SetValue(ButtonTextFontColorProperty, value);
        }

        #endregion

        #endregion

        #region Bindable Properties related to Button 

        #region ButtonBackgroundColor Bindable Implementation

        public static readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(
          nameof(ButtonBackgroundColor), typeof(Color), typeof(CustomImageButton), Color.Black, propertyChanged: HandleButtonBackgroundColorPropertyChanged);

        private static void HandleButtonBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.ButtonFrame.BackgroundColor = (Color)newValue;
        }

        public Color ButtonBackgroundColor
        {
            get => (Color)GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }

        #endregion

        #region ButtonCornerRadius Bindable Implementation

        public static readonly BindableProperty ButtonCornerRadiusProperty = BindableProperty.Create(
            nameof(ButtonCornerRadius), typeof(float), typeof(CustomImageButton), null, propertyChanged: HandleButtonCornerRadiusPropertyChanged);

        private static void HandleButtonCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.ButtonFrame.CornerRadius = (float)newValue;
        }

        public float ButtonCornerRadius
        {
            get => (float)GetValue(ButtonCornerRadiusProperty);
            set => SetValue(ButtonCornerRadiusProperty, value);
        }

        #endregion

        #region ButtonBorderColor Bindable Implementation

        public static readonly BindableProperty ButtonBorderColorProperty = BindableProperty.Create(
          nameof(ButtonBorderColor), typeof(Color), typeof(CustomImageButton), Color.Black, propertyChanged: HandleButtonBorderColorPropertyChanged);

        private static void HandleButtonBorderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton targetView;
            targetView = (CustomImageButton)bindable;
            if (targetView != null)
                targetView.ButtonFrame.BorderColor = (Color)newValue;
        }

        public Color ButtonBorderColor
        {
            get => (Color)GetValue(ButtonBorderColorProperty);
            set => SetValue(ButtonBorderColorProperty, value);
        }

        #endregion

        #endregion
    }
}
