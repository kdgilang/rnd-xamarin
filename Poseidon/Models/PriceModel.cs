using System;
using System.Globalization;

namespace Poseidon.Models
{
    public class PriceModel : BaseModel
    {
        private double _value;
        public double Value {
            get => _value;
            set
            {
                _value = value;

                CultureInfo culture = new CultureInfo("id-ID");

                Text =  value.ToString("C", culture);

                OnPropertyChanged(nameof(Value));
            }
        }

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}
