namespace Pi_Plant
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

        Routing.RegisterRoute(nameof(ShopPage), typeof(ShopPage));
        Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
    }
}
