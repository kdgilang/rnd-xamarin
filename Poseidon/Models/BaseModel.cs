using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Poseidon.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private long _id;
        public long Id
        {
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
            get => _id;
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            set
            {
                _createdAt = value;
                OnPropertyChanged(nameof(CreatedAt));
            }
            get => _createdAt;
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            set
            {
                _updatedAt = value;
                OnPropertyChanged(nameof(UpdatedAt));
            }
            get => _updatedAt;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
