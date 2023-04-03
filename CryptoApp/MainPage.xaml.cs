using System.Windows.Input;

namespace CryptoApp;

public partial class MainPage : ContentPage
{
    public ICommand TapCommand => new Command<string>(async (url) => await DoSometjings());

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public async Task DoSometjings()
    {
        this.BindingContext = this;
    }
}

