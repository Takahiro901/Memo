﻿using System;
using System.Collections.Generic;
using Memo.Database;
using Xamarin.Forms;

namespace Memo
{
    public partial class EditPage : ContentPage
    {
        readonly TodoItemDatabase todoItemDatabase = new TodoItemDatabase();

        public EditPage(TodoItem wItem)
        {
            InitializeComponent();
            BindingContext = wItem;
        }

        async void Save_clicked(object sender, EventArgs e)
        {
            var wItem = (TodoItem)BindingContext;
            await todoItemDatabase.UpdateItemsAsync(wItem);
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var wItem = (TodoItem)BindingContext;
            await todoItemDatabase.DeleteItemsAsync(wItem);
            await Navigation.PopAsync();
        }
    }
}
