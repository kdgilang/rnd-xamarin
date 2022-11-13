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
                OnPropertyChanged(nameof(Value));
            }
        }

        public string Text
        {
            get
            {
                CultureInfo culture = new CultureInfo("id-ID");

                return Value.ToString("C", culture);
            }
        }
    }
}
