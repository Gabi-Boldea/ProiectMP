using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PlatinumGymMAUI.Models
{
    public class ListExercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ExercisesId { get; set; }
        public int ProductId { get; set; }
    }

}
