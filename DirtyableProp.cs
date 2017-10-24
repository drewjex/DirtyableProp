using SkyTrack.Annotations;
using SkyWest.Common.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyTrack.LaborSetup.Models
{
    class DirtyableProp<T> : NotifyPropertyChangedBase, ICloneable
    {
        private bool _isDirty = false;
        private bool _isInvalid = false;
        private T _value;
        public Action<object, PropertyChangedEventArgs> Handler;

        public DirtyableProp(Action<object, PropertyChangedEventArgs> handler = null) {
            if (handler != null)
            {
                Handler = handler;
                (this as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(Handler);
            }
        }

        public T Value
        {
            get { return _value; }
            set {
                _value = value;
                OnPropertyChanged();
            }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                if (_isDirty == value)
                    return;
                _isDirty = value;
                OnPropertyChanged();
            }
        }

        public bool IsInvalid
        {
            get { return _isInvalid; }
            set
            {
                if (_isInvalid == value)
                    return;
                _isInvalid = value;
                OnPropertyChanged();
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
