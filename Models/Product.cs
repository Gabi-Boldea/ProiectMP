using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PlatinumGymMAUI.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ListExercise> ListExercises { get; set; }
    }
}
