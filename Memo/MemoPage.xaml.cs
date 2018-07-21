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

            //listView.ItemsSource = await todoItemDatabase.GetItemsAsync();

            listView.ItemTapped += async (s, a) =>
            {
                var wItem = (TodoItem)a.Item;
                await Navigation.PushAsync(new EditPage(wItem));
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await todoItemDatabase.GetItemsAsync();
        }

        async void Add_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WritePage());
        }
    }
}
