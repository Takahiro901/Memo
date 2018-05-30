using System;
using System.Collections.Generic;
using Memo.Database;
using Xamarin.Forms;

namespace Memo
{
    public partial class WritePage : ContentPage
    {
        public WritePage()
        {
            InitializeComponent();
        }

        async void Save_clicked(object sender, EventArgs e)
        {
            
            var item = new TodoItem
            {
                Memo = eMemo.Text,
                InsertDate = DateTime.Now
            };
            await App.Database.SaveItemAsync(item);
            await Navigation.PopAsync();
        }


    }
}