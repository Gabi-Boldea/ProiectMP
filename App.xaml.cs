using System;
using PlatinumGymMAUI.Data;
using System.IO;

namespace PlatinumGymMAUI
{
    public partial class App : Application
    {
        static ExercisesDatabase database;
        public static ExercisesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ExercisesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Exercises.db3"));
                }
                return database;
            }
        }
        public App()
        { 
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
