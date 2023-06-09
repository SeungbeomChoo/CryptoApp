﻿using CryptoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Handlers
{
    public class CryptoSearchHandler : SearchHandler
    {
        public IList<CryptoCurrency> AllCryptoCurrencies { get; set; }

        public IList<CryptoCurrency> CryptoCurrencies { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = AllCryptoCurrencies
                    .Where(x => x.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Let the animation complete
            await Task.Delay(1000);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            // The following route works because route names are unique in this app.
            await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={((CryptoCurrency)item).Name}");
        }

        string GetNavigationTarget()
        {
            return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        }
    }
}
