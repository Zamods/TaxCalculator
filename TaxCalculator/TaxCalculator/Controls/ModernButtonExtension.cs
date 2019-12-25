using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator.Controls
{
    [ContentProperty("Command")]
    public class CommandExtension : BindableObject, IMarkupExtension
    {
        public string Command { get; set; }

        //Binding source for Command
        public object Source { get; set; }

        //CommandParameter
        public object Parameter { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

    public class Gesture
    {
        #region TapCommand Bindable Implementation

        public static readonly BindableProperty TapCommandProperty = BindableProperty.CreateAttached("TapCommand", typeof(CommandExtension), typeof(Gesture),
            null, propertyChanged: HandleTapCommandPropertyChanged);

        private static void HandleTapCommandPropertyChanged(BindableObject source, object oldValue, object newValue)
        {
            var tapGesture = new TapGestureRecognizer();
            var oldVal = oldValue as CommandExtension;
            var newVal = newValue as CommandExtension;
            
            //set Command
            var commandBinding = new Binding(newVal.Command, source: newVal.Source);
            tapGesture.SetBinding(TapGestureRecognizer.CommandProperty, commandBinding);

            //set Command Parameter
            if (newVal.Parameter is Binding)
            {
                tapGesture.SetBinding(TapGestureRecognizer.CommandParameterProperty, newVal.Parameter as Binding);
            }
            else
            {
                tapGesture.CommandParameter = newVal.Parameter;
            }

            var view = source as ContentView ;
            //Removing all Previous Tap Gestures from GestureRecognizers.
            foreach(var gestureItem in view.GestureRecognizers)
            {
                if(gestureItem is TapGestureRecognizer localTapGesture)
                {
                    view.GestureRecognizers.Remove(localTapGesture);
                }
            }
            //Subscribed to Tapped Event for Animation 
            tapGesture.Tapped += OnItemTapped;
            //Assign Tap Gesture to Control
            view.GestureRecognizers.Add(tapGesture);

        }
      
        public static object GetTapCommand(BindableObject view)
        {
            return (object)view.GetValue(TapCommandProperty);
        }

        public static void SetTapCommand(BindableObject view, object value)
        {
            view.SetValue(TapCommandProperty, value);
        }

        #endregion

        #region Animation

        private async static void OnItemTapped(object sender, EventArgs e)
        {
            if (sender is VisualElement visualElement)
            {
                var xVal = visualElement.X;
                await visualElement.FadeTo(.2, 150, Easing.SinIn);
                await visualElement.TranslateTo(80, 0, 350, Easing.SinInOut);
                await visualElement.TranslateTo(xVal, 0, 300, Easing.SinInOut);
                await visualElement.FadeTo(1, 100, Easing.SinOut);
            }
        }

        #endregion
    }
}
