using System;
using System.Collections.Generic;
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

        public ButtonIcon()
        {
            InitializeComponent();
            BindingContext = this;
        }


        public string Label
        {
            get => (string)GetValue(ButtonIcon.LabelProperty);
            set => SetValue(ButtonIcon.LabelProperty, value);
        }
    }
}
