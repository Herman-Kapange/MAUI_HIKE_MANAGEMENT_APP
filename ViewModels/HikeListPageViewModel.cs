// Importing necessary namespaces
using M_Hike_hk3971t_gre.ac.uk.Models; // Importing the HikeModel class
using M_Hike_hk3971t_gre.ac.uk.Services; // Importing the IHikeService interface
using M_Hike_hk3971t_gre.ac.uk.Views; // Importing the AppShell class
using Microsoft.Toolkit.Mvvm.ComponentModel; // Importing the ObservableObject class
using Microsoft.Toolkit.Mvvm.Input; // Importing ICommand and related attributes
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Hike_hk3971t_gre.ac.uk.ViewModels
{
    // ViewModel class for the HikeListPage
    public partial class HikeListPageViewModel : ObservableObject
    {
        // ObservableCollection to hold a list of hikes
        public ObservableCollection<HikeModel> Hikes { get; set; } = new ObservableCollection<HikeModel>();

        // IHikeService dependency for interacting with the Hike data
        private readonly IHikeService _hikeService;

        // Constructor accepting an IHikeService instance
        public HikeListPageViewModel(IHikeService hikeService)
        {
            _hikeService = hikeService; // Assigning the provided IHikeService instance
        }

        // ICommand method for retrieving and updating the list of hikes
        [ICommand]
        public async void GetHikeList()
        {
            Hikes.Clear(); // Clearing the existing list
            var hikeList = await _hikeService.GetHikeList(); // Getting the updated list of hikes from the service
            if (hikeList?.Count > 0)
            {
                foreach (var hike in hikeList)
                {
                    Hikes.Add(hike); // Adding each hike to the ObservableCollection
                }
            }
        }

        // ICommand method for navigating to the AddUpdateHikeDetail page
        [ICommand]
        public async void AddUpdateHike()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateHikeDetail)); // Navigating to the AddUpdateHikeDetail page
        }

        // ICommand method for editing a specific hike
        [ICommand]
        public async void EditHike(HikeModel hikeModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("HikeDetail", hikeModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateHikeDetail), navParam); // Navigating to the AddUpdateHikeDetail page with a parameter
        }

        // ICommand method for deleting a specific hike
        [ICommand]
        public async void DeleteHike(HikeModel hikeModel)
        {
            var delResponse = await _hikeService.DeleteHike(hikeModel); // Deleting the specified hike
            if (delResponse > 0)
            {
                GetHikeList(); // Refreshing the list after deletion
            }
        }

        // ICommand method for displaying an action sheet with options for a specific hike
        [ICommand]
        public async void DisplayAction(HikeModel hikeModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("HikeDetail", hikeModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateHikeDetail), navParam); // Navigating to the AddUpdateHikeDetail page for editing
            }
            else if (response == "Delete")
            {
                var delResponse = await _hikeService.DeleteHike(hikeModel); // Deleting the specified hike
                if (delResponse > 0)
                {
                    GetHikeList(); // Refreshing the list after deletion
                }
            }
        }
    }
}
