using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM
{
    public class BookInfoRepository : INotifyPropertyChanged
    {
        private ObservableCollection<BookInfo> bookInfoCollection;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BookInfo> BookInfoCollection
        {
            get { return bookInfoCollection; }
            set
            {
                this.bookInfoCollection = value;
                this.OnPropertyChanged("BookInfoCollection");
            }
        }

        private Command holdCommand;

        public Command HoldCommand
        {
            get { return holdCommand; }
            protected set { holdCommand = value; }
        }

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public BookInfoRepository()
        {
            GenerateNewBookInfo();
            holdCommand = new Command(OnItemHold);
        }

        private void GenerateNewBookInfo()
        {
            BookInfoCollection = new ObservableCollection<BookInfo>();
            BookInfoCollection.Add(new BookInfo() { BookName = "Machine Learning Using C#", BookDescription = "You’ll learn several different approaches to applying machine learning" });
            BookInfoCollection.Add(new BookInfo() { BookName = "Object-Oriented Programming in C#", BookDescription = "Object-oriented programming is the de facto programming paradigm" });
            BookInfoCollection.Add(new BookInfo() { BookName = "C# Code Contracts", BookDescription = "Code Contracts provide a way to convey code assumptions" });
        }

        ///<summary>
        /// Displays the item holding content
        ///</summary>
        public void OnItemHold(object obj)
        {
            var eventArgs = obj as Syncfusion.ListView.XForms.ItemHoldingEventArgs;
            Application.Current.MainPage.DisplayAlert("Type Of Item :" + eventArgs.ItemType, "Item Tapped Position : + " + eventArgs.Position, "Ok");
        }
    }
}
