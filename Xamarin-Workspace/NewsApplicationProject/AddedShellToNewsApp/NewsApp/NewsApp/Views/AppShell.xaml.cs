using Xamarin.Forms;

namespace NewsApp.Views
{
    public partial class AppShell : Shell   
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(FavoriteArticlePage), typeof(FavoriteArticlePage));
            Routing.RegisterRoute("articledetails", typeof(ArticleDetailsPage));
           // Routing.RegisterRoute(nameof(ArticleDetailsPage), typeof(ArticleDetailsPage));


        }
    }
}
