using SQLite;
using TodoList_Maui.Models;

namespace TodoList_Maui.Data
{
    public class GoalRepository
    {
        string _dbPath;
        private SQLiteConnection connection;

        public GoalRepository(string dbPath)
        {
            _dbPath = dbPath;
            connection = new SQLiteConnection(_dbPath);
        }

        public void Init()
        {
            connection.CreateTable<Goals>();
            Goals goals = new Goals { Name = "TodoList", Description = "Create todo list via Maui", Category = Category.Work, Status = false};
            List<Goals> list = connection.Table<Goals>().ToList();
            if(list.Count == 0) connection.Insert(goals);
        }

#region Goal
        public Goals GetGoal(int id)
        {
            return connection.Table<Goals>().SingleOrDefault(p => p.Id == id);
        }
        public List<Goals> GetGoals()
        {
            return connection.Table<Goals>().ToList();
        }
        
        public void AddGoal(Goals goal)
        {
            connection.Insert(goal);
        }

        public void DeleteGoal(int id)
        {
            connection.Delete(new Goals { Id = id });
        }

        public void EditGoal(Goals goal)
        {
            connection.Update(goal);
        }

        public void SwitchGoalStatus(int id)
        {
            var goal = GetGoal(id);
            goal.Status = !goal.Status;
            EditGoal(goal);
        }
#endregion
    }
}