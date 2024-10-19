using TodoList_Maui.Models;

namespace TodoList_Maui;

public partial class Edit : ContentPage
{
	Goals goal = new Goals();
	public Edit(int _id)
	{
		goal = App.GoalRepository.GetGoal(_id);
		BindingContext = this;
		InitializeComponent();
		Update();
	}

	private void Update()
	{
		Name.Text = goal.Name;
		Description.Text = goal.Description;
		Status.IsToggled = goal.Status;
		CategoryPicker.ItemsSource = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
		CategoryPicker.SelectedIndex = Convert.ToInt32(goal.Category);
	}

	private void OnSubmit(object sender, EventArgs e)
	{
		if (Name.Text != null)
		{
			goal.Name = Name.Text;
			goal.Description = Description.Text;
			goal.Status = Status.IsToggled;
			switch (CategoryPicker.SelectedIndex)
			{
				case 0: goal.Category = Category.Work; break;
				case 1: goal.Category = Category.Study; break;
				case 2: goal.Category = Category.Sport; break;
				case 3: goal.Category = Category.House; break;
				case 4: goal.Category = Category.Other; break;
				default: goal.Category = Category.Other; break;
			}
			App.GoalRepository.EditGoal(goal);
			Update();
		}
		else return;
	}

	private void OnToMainPage(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage());
	}
}