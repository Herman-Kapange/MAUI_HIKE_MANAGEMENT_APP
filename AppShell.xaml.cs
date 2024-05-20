using M_Hike_hk3971t_gre.ac.uk.Views;

namespace M_Hike_hk3971t_gre.ac.uk
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddUpdateHikeDetail),typeof(AddUpdateHikeDetail));
        }
    }
}