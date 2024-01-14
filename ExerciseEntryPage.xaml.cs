using PlatinumGymMAUI.Models;
using System.Diagnostics.CodeAnalysis;

namespace PlatinumGymMAUI;

public partial class ExerciseEntryPage : ContentPage
{
    public Exercises currentExercise;

    public ExerciseEntryPage()
    {
        InitializeComponent();
        currentExercise = new Exercises();
        BindingContext = currentExercise;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var exercise = (Exercises)BindingContext;
        exercise.Date = DateTime.UtcNow;
        Gym selectedGym = (GymPicker.SelectedItem as Gym);
        exercise.GymId = selectedGym.Id;
        await App.Database.SaveExerciseAsync(exercise);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var exercise = (Exercises)BindingContext;
        await App.Database.DeleteExerciseAsync(exercise);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        var selectedExercises = (Exercises)this.BindingContext;
        var product = new Product(); // create a new instance
        await Navigation.PushAsync(new ProductPage(selectedExercises, product));
    }
    async void OnDeleteSelectedExerciseButtonClicked(object sender, EventArgs e)
    {
        if (listView.SelectedItem != null)
        {
            var selectedExercise = listView.SelectedItem as Product;
            await App.Database.DeleteProductAsync(selectedExercise);
            listView.ItemsSource = await App.Database.GetListExercisesAsync(currentExercise.Id);
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var gyms = await App.Database.GetGymsAsync();

        GymPicker.ItemsSource = gyms;
        GymPicker.ItemDisplayBinding = new Binding("GymDetails");

        var currentExercise = (Exercises)BindingContext;
        if (currentExercise.GymId != 0)
        {
            var selectedGym = gyms.FirstOrDefault(g => g.Id == currentExercise.GymId);
            GymPicker.SelectedItem = selectedGym;
        }

        listView.ItemsSource = await App.Database.GetListExercisesAsync(currentExercise.Id);
    }
}