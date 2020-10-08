using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace testVisibleAndFocus
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        private List<ItemViewModel> _items;
        public List<ItemViewModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged();
            }
        }

        private ItemViewModel _selectedItem;
        public ItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public Command SetSelectionFocusCommand { get; set; }

        public MainPageViewModel()
        {
            SetSelectionFocusCommand = new Command(ExecuteSetSelectionFocusCommand);

            Items = new List<ItemViewModel>();
            Items.Add(new ItemViewModel() { Name = "First" });
            Items.Add(new ItemViewModel() { Name = "Second" });
            Items.Add(new ItemViewModel() { Name = "Third" });
        }

        private void ExecuteSetSelectionFocusCommand(object obj)
        {
            Debug.WriteLine("New item selected.");
            if (obj is ItemViewModel item)
            {
                SelectedItem = item;
            }
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
