using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

    private async void AddTaskClicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;

		var selectedCategory =
			vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();

		if (selectedCategory != null)
		{
			var task = new MyTask
			{
				TaskName = vm.Task,
				CategoryId = selectedCategory.Id,
			};
			vm.Tasks.Add(task);
			await Navigation.PopAsync();
		} 
		else
		{
			await DisplayAlert("Invalid Selection", "You must select a category", "Ok");
		}
    }
}