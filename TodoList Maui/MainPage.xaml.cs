using TodoList_Maui.Data;
using TodoList_Maui.Models;

namespace TodoList_Maui
{
    public partial class MainPage : ContentPage
    {
        private class Goal : Goals
        {
            public string ButtonColor { get; set; }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            UpdateData();
        }

        public void UpdateData()
        {
            List<Goals> goals = App.GoalRepository.GetGoals();
            List<Goal> finalGoals = new List<Goal>();
            finalGoals.Clear();
            foreach (var item in goals)
            {
                if (item.Status)
                {
                    Goal newGoal = new Goal
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Category = item.Category,
                        Description = item.Description,
                        Status = item.Status,
                        ButtonColor = "Green"
                    };
                    finalGoals.Add(newGoal);
                }
                else
                {
                    Goal newGoal = new Goal
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Category = item.Category,
                        Description = item.Description,
                        Status = item.Status,
                        ButtonColor = "Red"
                    };
                    finalGoals.Add(newGoal);
                    var debug = 0;
                }
            }
            GoalsList.ItemsSource = finalGoals;
        }

        public void OnDeleteGoal(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            App.GoalRepository.DeleteGoal((int)button.BindingContext);

            UpdateData();
        }

        public void OnSwitchGoalStatus(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            App.GoalRepository.SwitchGoalStatus((int)button.BindingContext);

            UpdateData();
        }


        public void OnAddGoal(object sender, EventArgs e)
        {

            if (AddEntry.Text != null)
            {
                Goals goal = new Goals { Name = AddEntry.Text, Category = Category.Other, Status = false };
                App.GoalRepository.AddGoal(goal);

                AddEntry.Text = null;

                UpdateData();
            }
            else return;
        }
        #region Navigation
        public void OnToAddGoal(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add());
        }

        public void OnToEdit(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Navigation.PushAsync(new Edit((int)button.BindingContext));
        }
		#endregion
	}
}
