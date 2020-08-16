using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinDatronik.Views.CustomControls
{
    public class TouchReactiveFrame : Frame
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TouchReactiveFrame));

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TouchReactiveFrame), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public void ExecuteCommand() =>
            Command?.Execute(CommandParameter);
    }
}
