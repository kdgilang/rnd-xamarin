using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poseidon.Components
{
    public partial class ButtonIcon : ContentView
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(
            "Label",
            typeof(string),
            typeof(ButtonIcon),
            string.Empty);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            "TextColor",
            typeof(Color),
            typeof(ButtonIcon),
            Color.Black);

        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(
            "TapCommand",
            typeof(ICommand),
            typeof(ButtonIcon),
            null);

        public ButtonIcon()
        {
            InitializeComponent();
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public ICommand TapCommand
        {
            get => (ICommand)GetValue(TapCommandProperty);
            set => SetValue(TapCommandProperty, value);
        }
    }
}
