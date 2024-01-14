using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PlatinumGymMAUI.Models
{
    public class Gym
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string GymName { get; set; }
        public string Address { get; set; }
        public string GymDetails { get { return GymName + Address; } }
        [OneToMany]
        public List<Exercises> Exercises { get; set; }
    }
}
