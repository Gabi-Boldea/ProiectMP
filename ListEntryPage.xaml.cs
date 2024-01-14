using PlatinumGymMAUI.Models;

namespace PlatinumGymMAUI;

public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
        InitializeComponent();
	}
	protected override async void OnAppearing()
	{
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetExercisesAsync();
    }
	async void OnExerciseAddedClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ExerciseEntryPage
		{
            BindingContext = new Exercises()
        });
        Console.WriteLine(BindingContext);

    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
        if (e.SelectedItem != null)
		{
            await Navigation.PushAsync(new ExerciseEntryPage
			{
                BindingContext = e.SelectedItem as Exercises
            });
        }
    }
}