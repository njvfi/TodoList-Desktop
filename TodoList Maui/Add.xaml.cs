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
			switch(CategoryPicker.SelectedIndex)
			{
				case 0:goal.Category = Category.Work; break;
				case 1:goal.Category = Category.Study; break;
				case 2:goal.Category = Category.Sport; break;
				case 3:goal.Category = Category.House; break;
				case 4:goal.Category = Category.Other; break;
				default: goal.Category = Category.Other; break;
			}
			App.GoalRepository.AddGoal(goal);
			Navigation.PushAsync(new MainPage());
		}
		else return;
	}
}