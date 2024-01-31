using CryptoApp.Models;

namespace CryptoApp.Handlers
{
    public class CryptoSearchHandler : SearchHandler
    {
        public List<CryptoCurrency> AllCryptoCurrencies { get; set; }
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
                    .Where(animal => animal.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList<CryptoCurrency>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            CryptoCurrency cryptoCurrency = item as CryptoCurrency;

            var navigationParameter = new Dictionary<string, object>
            {
                { "CryptoCurrency", cryptoCurrency }
            };

            await Shell.Current.GoToAsync($"cryptoDetail", navigationParameter);
        }
    }
}
