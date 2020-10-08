using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace testVisibleAndFocus
{
    public class ItemViewModel : INotifyPropertyChanged
    {

        public string Name { get; set; }

        public string Value1 { get; set; }

        public Command SpecificFocusCommand { get; set; }


        public ItemViewModel()
        {
            SpecificFocusCommand = new Command(ExecuteSpecificFocusCommand);
            Value1 = "test value";
        }

        private void ExecuteSpecificFocusCommand(object obj)
        {
            Debug.WriteLine($"Focus event for {Name}.");
        }

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
