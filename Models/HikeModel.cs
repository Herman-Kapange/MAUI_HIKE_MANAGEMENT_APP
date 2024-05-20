// Importing necessary namespaces
using SQLite; // SQLite for database operations
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Hike_hk3971t_gre.ac.uk.Models
{
    // Definition of the HikeModel class
    public class HikeModel
    {
        // Primary key for the database, AutoIncrement attribute is used to automatically generate unique IDs
        [PrimaryKey, AutoIncrement]
        public int HikeId { get; set; }

        // Properties representing various attributes of a hiking event
        public string HikeName { get; set; } // Name of the hike
        public string HikeLocation { get; set; } // Location where the hike takes place
        public string HikeDate { get; set; } // Date of the hike
        public string HikeParkingAvailable { get; set; } // Availability of parking
        public string HikeLength { get; set; } // Length of the hike
        public string HikeDifficulty { get; set; } // Difficulty level of the hike
        public string HikeDescription { get; set; } // Description of the hike
        public string HikeSpecialRequirements { get; set; } // Special requirements for the hike
        public string HikeRecommendedGear { get; set; } // Recommended gear for the hike
    }
}
