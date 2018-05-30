using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Memo.Database;

namespace Memo
{

    public partial class MemoPage : ContentPage
    {

        public MemoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void Add_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WritePage());
        }
    }
}
