using PlatinumGymMAUI.Models;
using Plugin.LocalNotification;

namespace PlatinumGymMAUI;

public partial class GymPage : ContentPage
{
	public GymPage()
	{
		InitializeComponent();
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
        var gym = (Gym)BindingContext;
        await App.Database.SaveGymAsync(gym);
        await Navigation.PopAsync();
    }

	async void OnShowMapButtonClicked(object sender, EventArgs e)
	{
        var gym = (Gym)BindingContext;
        var address = gym.Address;
		var locations = await Geocoding.GetLocationsAsync(address);
		var options = new MapLaunchOptions { Name = gym.GymName };
		var location = locations?.FirstOrDefault();
		var myLocation = new Location(46.7731796289, 23.6213886738);
		var distance = myLocation.CalculateDistance(location, DistanceUnits.Kilometers);
		if(distance <2)
		{
			var request = new NotificationRequest
			{
				Title = "Gym is near",
				Description = address,
				Schedule = new NotificationRequestSchedule
				{
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
			};
			LocalNotificationCenter.Current.Show(request);
		}
		await Map.OpenAsync(location, options);
    }
}