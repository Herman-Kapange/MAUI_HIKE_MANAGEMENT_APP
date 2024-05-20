// Importing necessary namespaces
using M_Hike_hk3971t_gre.ac.uk.Models; // Importing the HikeModel class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Hike_hk3971t_gre.ac.uk.Services
{
    // Definition of the IHikeService interface
    public interface IHikeService
    {
        // Method to retrieve a list of all hikes
        Task<List<HikeModel>> GetHikeList();

        // Method to add a new hike
        Task<int> AddHike(HikeModel hikeModel);

        // Method to delete a hike
        Task<int> DeleteHike(HikeModel hikeModel);

        // Method to update an existing hike
        Task<int> UpdateHike(HikeModel hikeModel);
    }
}
