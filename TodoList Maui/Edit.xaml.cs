using TodoList_Maui.Models;

namespace TodoList_Maui;

public partial class Edit : ContentPage
{
	private Goals goal = new Goals();
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
		StatusSwitch.IsToggled = goal.Status;//TODO change text on switch
		Status.Text = goal.Status ? "Done" : "Not ready";
		CategoryPicker.ItemsSource = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
		CategoryPicker.SelectedIndex = Convert.ToInt32(goal.Category);
	}

	private void OnStatus(object sender, EventArgs e)
	{
		Status.Text = StatusSwitch.IsToggled ? "Done" : "Not ready";
	}

	private void OnSubmit(object sender, EventArgs e)
	{
		if (Name.Text != null)
		{
			goal.Name = Name.Text;
			goal.Description = Description.Text;
			goal.Status = StatusSwitch.IsToggled;
			goal.Category = CategoryPicker.SelectedIndex switch
			{
				0 => Category.Work,
				1 => Category.Study,
				2 => Category.Sport,
				3 => Category.House,
				4 => Category.Other,
				_ => Category.Other,
			};
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