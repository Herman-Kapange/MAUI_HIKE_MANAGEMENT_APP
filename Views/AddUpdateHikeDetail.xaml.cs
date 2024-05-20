using M_Hike_hk3971t_gre.ac.uk.ViewModels; // Importing the ViewModel namespace

namespace M_Hike_hk3971t_gre.ac.uk.Views
{
    // Partial class for the AddUpdateHikeDetail view, inheriting from ContentPage
    public partial class AddUpdateHikeDetail : ContentPage
    {
        // Constructor for the AddUpdateHikeDetail view, accepting an instance of the ViewModel
        public AddUpdateHikeDetail(AddUpdateHikeDetailViewModel viewModel)
        {
            InitializeComponent(); // Initializing the view components

            // Setting the BindingContext to the provided ViewModel
            this.BindingContext = viewModel;
        }
    }
}
