using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using Memo.Database;
using System.Collections.Generic;

namespace Memo
{

    public partial class MemoPage : ContentPage
    {
        readonly TodoItemDatabase todoItemDatabase = new TodoItemDatabase();

        public MemoPage()
        {
            InitializeComponent();

            listView.ItemTapped += async (s, a) =>
            {
                var wItem = (TodoItem)a.Item;
                await Navigation.PushAsync(new EditPage(wItem));
            };

            searchbar.TextChanged += (sender, e) => this.SearchFilter(e.NewTextValue);
            searchbar.SearchButtonPressed += (sender, e) => this.SearchFilter(searchbar.Text);

        }


        public  async void SearchFilter(string filter)
        {
            listView.BeginRefresh();
            
            if (string.IsNullOrWhiteSpace(filter))
            {
                listView.ItemsSource = await todoItemDatabase.GetItemsAsync();
            }
            else
            {
                listView.ItemsSource = todoItemDatabase.GetItemsAsync().Result.Where(x => x.Memo.ToLower().Contains(filter));
            }

            listView.EndRefresh();
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
