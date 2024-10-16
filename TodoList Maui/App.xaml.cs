using TodoList_Maui.Data;

namespace TodoList_Maui
{
    public partial class App : Application
    {
        public static GoalRepository GoalRepository { get; private set; }

        public App(GoalRepository goalRepository)
        {
            InitializeComponent();

            MainPage = new AppShell();

            GoalRepository = goalRepository;
            goalRepository.Init();
        }
    }
}
