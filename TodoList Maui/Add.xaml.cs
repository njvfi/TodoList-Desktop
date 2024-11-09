using TodoList_Maui.Models;

namespace TodoList_Maui;

public partial class Add : ContentPage
{
	public Add()
	{
		InitializeComponent();
		BindingContext = this;
		CategoryPicker.ItemsSource = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
		CategoryPicker.SelectedIndex = 5;
	}

	public void OnSubmit(object sender, EventArgs e)
	{
		if (NameEntry.Text != null)
		{
			Goals goal = new Goals();
			goal.Name = NameEntry.Text;
			goal.Description = DescriptionEntry.Text;
			goal.Status = false;
			goal.Category = CategoryPicker.SelectedIndex switch
			{
				0 => Category.Work,
				1 => Category.Study,
				2 => Category.Sport,
				3 => Category.House,
				4 => Category.Other,
				_ => Category.Other,
			};
			App.GoalRepository.AddGoal(goal);
			Navigation.PushAsync(new MainPage());
		}
		else return;
	}
}