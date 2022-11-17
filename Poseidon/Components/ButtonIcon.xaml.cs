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

        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
            "BackgroundColor",
            typeof(Color),
            typeof(ButtonIcon),
            Color.Transparent);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            "TextColor",
            typeof(Color),
            typeof(ButtonIcon),
            Color.Black);

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(
            "IconSource",
            typeof(string),
            typeof(ButtonIcon),
            string.Empty);

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

        public Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public string IconSource
        {
            get => (string)GetValue(IconSourceProperty);
            set => SetValue(IconSource, value);
        }

        public ICommand TapCommand
        {
            get => (ICommand)GetValue(TapCommandProperty);
            set => SetValue(TapCommandProperty, value);
        }
    }
}
