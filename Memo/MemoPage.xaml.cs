using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Memo.Database;

namespace Memo
{

    public partial class MemoPage : ContentPage
    {
        readonly TodoItemDatabase todoItemDatabase = new TodoItemDatabase();

        public MemoPage()
        {
            InitializeComponent();

            listView.ItemsSource = todoItemDatabase.GetItems();

            listView.ItemTapped += async (s, a) =>
            {
                var wItem = (TodoItem)a.Item;
                if (await DisplayAlert("削除しますか", wItem.Memo, "はい", "いいえ"))
                {
                    todoItemDatabase.DeleteItem(wItem);
                    listView.ItemsSource = todoItemDatabase.GetItems();
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = todoItemDatabase.GetItems();
        }

        async void Add_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WritePage());
        }
    }
}
