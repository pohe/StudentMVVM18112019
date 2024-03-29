﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace StudentMVVM18112019.Common
{
    /// <summary>
    /// Denne klasse kan anvendes til at præsentere beskeder til brugeren i en dialogboks
    /// </summary>
    public class MessageDialogHelper
    {
        public static async void Show(string content, string title)
        {
            MessageDialog messageDialog = new MessageDialog(content, title);
            await messageDialog.ShowAsync();
        }
    }
}
