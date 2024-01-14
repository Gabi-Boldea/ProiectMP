﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PlatinumGymMAUI.Models
{
    public class Exercises
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }
    }
}