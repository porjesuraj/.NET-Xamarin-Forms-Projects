using Xamarin.Forms;

namespace ExpenseTrackingApp.Views
{
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            SizeChanged += CategoriesPage_SizeChanged;
        }

        private void CategoriesPage_SizeChanged(object sender, System.EventArgs e)
        {
            string visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState( catLabel, visualState);
            VisualStateManager.GoToState( catLabel1, visualState);

        }

       private void stateButton_Pressed(object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(stateButton, "Focused");
        }

        private void stateButton_Released(object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(stateButton, "Normal");

        }

        private void ImageButton_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
