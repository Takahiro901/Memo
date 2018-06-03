using System;
using System.Collections.Generic;
using Memo.Database;
using Xamarin.Forms;

namespace Memo
{
    public partial class WritePage : ContentPage
    {
        readonly TodoItemDatabase todoItemDatabase = new TodoItemDatabase();

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
            todoItemDatabase.InsertItem(item);
            await Navigation.PopAsync();
        }


    }
}