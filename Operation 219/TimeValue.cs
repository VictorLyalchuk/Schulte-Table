using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Operation_219
{
    public partial class TimeValue : INotifyPropertyChanged
    {
        static private double mytime;
        public double MyTime
        {
            get
            {
                return mytime;
            }
            set
            {
                mytime = value;
                OnPropertyChanged();
            }
        }
        public TimeValue()
        {
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
