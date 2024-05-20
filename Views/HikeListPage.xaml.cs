using M_Hike_hk3971t_gre.ac.uk.ViewModels; // Importing the ViewModel namespace

namespace M_Hike_hk3971t_gre.ac.uk.Views
{
    // Partial class for the HikeListPage view, inheriting from ContentPage
    public partial class HikeListPage : ContentPage
    {
        // Private field to store the associated ViewModel
        private HikeListPageViewModel _viewModel;

        // Constructor for the HikeListPage view, accepting an instance of the ViewModel
        public HikeListPage(HikeListPageViewModel viewModel)
        {
            InitializeComponent(); // Initializing the view components
            _viewModel = viewModel; // Assigning the provided ViewModel to the private field
            this.BindingContext = viewModel; // Setting the BindingContext to the ViewModel
        }

        // Override method called when the page is about to appear
        protected override void OnAppearing()
        {
            base.OnAppearing(); // Calling the base class implementation

            // Executing the GetHikeListCommand in the ViewModel to refresh the list of hikes
            _viewModel.GetHikeListCommand.Execute(null);
        }
    }
}
