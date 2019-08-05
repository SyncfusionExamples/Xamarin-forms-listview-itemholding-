# Handling ItemHolding event in ListView

ListView supports binding the [HoldCommand](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~HoldCommand.html) property with the item holding action from view model, where you can write navigation or any other action code in the execution. When defining the command, [ItemHoldingEventArgs](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemHoldingEventArgs.html) will be passed as command parameter which has item information in execution.

You can define the command parameter for the `HoldCommand` using [HoldCommandParameter](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~HoldCommandParameter.html), where you can get the element reference passed in view model.

```
<syncfusion:SfListView x:Name="listView"                     
                       HoldCommand="{Binding HoldCommand}"
                       ItemsSource="{Binding BookInfoCollection}"/>
```
```
//ViewModel.cs
public class BookInfoRepository : INotifyPropertyChanged
{
    private Command holdCommand;

    public Command HoldCommand
    {
        get { return holdCommand; }
        protected set { holdCommand = value; }
    }

    public BookInfoRepository()
    {
        holdCommand = new Command(OnHold);
    }

    ///<summary>
    /// Displays the item holding content
    ///</summary>
    public void OnHold(object obj)
    {
        var eventArgs = obj as Syncfusion.ListView.XForms.ItemHoldingEventArgs;           
        Application.Current.MainPage.DisplayAlert("Type Of Item :" + eventArgs.ItemType, "Item Tapped Position : + " +eventArgs.Position , "Ok");
    }
}
```
To know more about MVVM in ListView, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/mvvm)
