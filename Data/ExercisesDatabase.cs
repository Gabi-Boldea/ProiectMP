using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatinumGymMAUI.Models;

namespace PlatinumGymMAUI.Data
{
    public class ExercisesDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ExercisesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Exercises>().Wait();
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListExercise>().Wait();
            _database.CreateTableAsync<Gym>().Wait();
        }
        public Task<int> SaveProductAsync(Product product)
        {
            if (product.Id != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }   
        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }

        public Task<List<Exercises>> GetExercisesAsync()
        {
            return _database.Table<Exercises>().ToListAsync();
        }
        public Task<Exercises> GetExerciseAsync(int id)
        {
            return _database.Table<Exercises>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }
        public Task<int> SaveExerciseAsync(Exercises exercise)
        {
            if (exercise.Id != 0)
            {
                return _database.UpdateAsync(exercise);
            }
            else
            {
                return _database.InsertAsync(exercise);
            }
        }
        public Task<int> DeleteExerciseAsync(Exercises exercise)
        {
            return _database.DeleteAsync(exercise);
        }

        public Task<int> SaveListExerciseAsync(ListExercise listExercise)
        {
            if (listExercise.Id != 0)
            {
                return _database.UpdateAsync(listExercise);
            }
            else
            {
                return _database.InsertAsync(listExercise);
            }
        }

        public Task<List<Product>> GetListExercisesAsync(int shoplistid)
        {
            return _database.QueryAsync<Product>("SELECT * FROM [Product] WHERE [Id] IN (SELECT [ProductId] FROM [ListExercise] WHERE [ExercisesId] = ?)", shoplistid);
        }

        public Task<List<Gym>> GetGymsAsync()
        {
            return _database.Table<Gym>().ToListAsync();
        }

        public Task<int> SaveGymAsync(Gym gym)
        {
            if (gym.Id != 0)
            {
                return _database.UpdateAsync(gym);
            }
            else
            {
                return _database.InsertAsync(gym);
            }
        }
    }
}
