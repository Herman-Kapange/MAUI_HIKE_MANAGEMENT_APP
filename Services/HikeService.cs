// Importing necessary namespaces
using M_Hike_hk3971t_gre.ac.uk.Models; // Importing the HikeModel class
using SQLite; // SQLite for database operations
using System;
using System.Collections.Generic;
using System.IO; // Importing the IO namespace for working with file paths
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Hike_hk3971t_gre.ac.uk.Services
{
    // Definition of the HikeService class implementing the IHikeService interface
    public class HikeService : IHikeService
    {
        private SQLiteAsyncConnection _dbConn; // SQLite connection object

        // Method for setting up the database connection and creating the HikeModel table if it doesn't exist
        private async Task DbSetup()
        {
            if (_dbConn == null)
            {
                // Creating a path for the SQLite database file in the local application data folder
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hike.db3");

                // Initializing the SQLite connection
                _dbConn = new SQLiteAsyncConnection(dbPath);

                // Creating the HikeModel table if it doesn't exist
                await _dbConn.CreateTableAsync<HikeModel>();
            }
        }

        // Method to add a new hike to the database
        public async Task<int> AddHike(HikeModel hikeModel)
        {
            await DbSetup(); // Ensure the database is set up
            return await _dbConn.InsertAsync(hikeModel); // Inserting the hikeModel into the HikeModel table
        }

        // Method to delete a hike from the database
        public async Task<int> DeleteHike(HikeModel hikeModel)
        {
            await DbSetup(); // Ensure the database is set up
            return await _dbConn.DeleteAsync(hikeModel); // Deleting the hikeModel from the HikeModel table
        }

        // Method to retrieve a list of all hikes from the database
        public async Task<List<HikeModel>> GetHikeList()
        {
            await DbSetup(); // Ensure the database is set up
            var hikeList = await _dbConn.Table<HikeModel>().ToListAsync(); // Querying all rows from the HikeModel table
            return hikeList; // Returning the list of hikes
        }

        // Method to update an existing hike in the database
        public async Task<int> UpdateHike(HikeModel hikeModel)
        {
            await DbSetup(); // Ensure the database is set up
            return await _dbConn.UpdateAsync(hikeModel); // Updating the hikeModel in the HikeModel table
        }
    }
}
