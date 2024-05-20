// Importing necessary namespaces
using M_Hike_hk3971t_gre.ac.uk.Models; // Importing the HikeModel class
using M_Hike_hk3971t_gre.ac.uk.Services; // Importing the IHikeService interface
using Microsoft.Toolkit.Mvvm.ComponentModel; // Importing the ObservableObject class
using Microsoft.Toolkit.Mvvm.Input; // Importing ICommand and related attributes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Hike_hk3971t_gre.ac.uk.ViewModels
{
    // ViewModel class for adding or updating Hike details
    [QueryProperty(nameof(HikeDetail), "HikeDetail")]
    public partial class AddUpdateHikeDetailViewModel : ObservableObject
    {
        // ObservableProperty for Hike details
        [ObservableProperty]
        private HikeModel _hikeDetail = new HikeModel();

        // IHikeService dependency for interacting with the Hike data
        private readonly IHikeService _hikeService;

        // Constructor accepting an IHikeService instance
        public AddUpdateHikeDetailViewModel(IHikeService hikeService)
        {
            _hikeService = hikeService; // Assigning the provided IHikeService instance
        }

        // ICommand method for adding or updating a Hike
        [ICommand]
        public async void AddUpdateHike()
        {
            // Validating required fields
            if (string.IsNullOrEmpty(HikeDetail.HikeName) ||
                string.IsNullOrEmpty(HikeDetail.HikeLocation) ||
                HikeDetail.HikeDate == default ||
                string.IsNullOrEmpty(HikeDetail.HikeParkingAvailable) ||
                string.IsNullOrEmpty(HikeDetail.HikeLength) ||
                string.IsNullOrEmpty(HikeDetail.HikeDifficulty))
            {
                // Building an error message for missing fields
                string errorMessage = "Please fill in all required fields:";
                if (string.IsNullOrEmpty(HikeDetail.HikeName))
                {
                    errorMessage += "\n- Name";
                }
                if (string.IsNullOrEmpty(HikeDetail.HikeLocation))
                {
                    errorMessage += "\n- Location";
                }
                if (HikeDetail.HikeDate == default)
                {
                    errorMessage += "\n- Date";
                }
                if (string.IsNullOrEmpty(HikeDetail.HikeParkingAvailable))
                {
                    errorMessage += "\n- Is parking Available?";
                }
                if (string.IsNullOrEmpty(HikeDetail.HikeLength))
                {
                    errorMessage += "\n- Length of Hike";
                }
                if (string.IsNullOrEmpty(HikeDetail.HikeDifficulty))
                {
                    errorMessage += "\n- Level of Difficulty";
                }

                // Displaying an alert for the validation error
                await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");
                return;
            }

            int response = -1;

            // Checking if the HikeId is greater than 0, indicating an existing Hike to be updated
            if (HikeDetail.HikeId > 0)
            {
                // Updating the existing Hike
                response = await _hikeService.UpdateHike(HikeDetail);
            }
            else
            {
                // Adding a new Hike
                response = await _hikeService.AddHike(new Models.HikeModel
                {
                    HikeName = HikeDetail.HikeName,
                    HikeLocation = HikeDetail.HikeLocation,
                    HikeDate = HikeDetail.HikeDate,
                    HikeParkingAvailable = HikeDetail.HikeParkingAvailable,
                    HikeLength = HikeDetail.HikeLength,
                    HikeDifficulty = HikeDetail.HikeDifficulty,
                    HikeDescription = HikeDetail.HikeDescription,
                    HikeSpecialRequirements = HikeDetail.HikeSpecialRequirements,
                    HikeRecommendedGear = HikeDetail.HikeRecommendedGear,
                });
            }

            // Displaying an alert based on the result of the add/update operation
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Hike Information Saved", "Record Saved", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Note Added", "Error occurred while adding Record", "Ok");
            }
        }
    }
}
