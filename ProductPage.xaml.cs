using PlatinumGymMAUI.Models;

namespace PlatinumGymMAUI;

public partial class ProductPage : ContentPage
{
    Exercises s1;
    Product product;

    public ProductPage(Exercises slist, Product existingProduct)
    {
        InitializeComponent();
        s1 = slist;
        product = existingProduct;
        BindingContext = product;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        await App.Database.SaveProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        await App.Database.DeleteProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        if (listView.SelectedItem != null)
        {
            var selectedProduct = listView.SelectedItem as Product;
            var lp = new ListExercise()
            {
                ExercisesId = s1.Id,
                ProductId = selectedProduct.Id
            };
            await App.Database.SaveListExerciseAsync(lp);

            // Note: Remove the following line that clears ListExercises
            // selectedProduct.ListExercises = new List<ListExercise>();

            await App.Database.SaveProductAsync(selectedProduct);
            await Navigation.PopAsync();
        }
    }




    async void OnDeleteExerciseButtonClicked(object sender, EventArgs e)
    {
        if (listView.SelectedItem != null)
        {
            var selectedProduct = listView.SelectedItem as Product;
            await App.Database.DeleteProductAsync(selectedProduct);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
    }
}