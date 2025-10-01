using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Console_To_Do_List
{
    internal class TaskHandler : Task
    {
        private List<Task> tasks;
        private const string FILE_PATH = "addedTasks.txt";

		public TaskHandler() {
            tasks = new List<Task>();
        }
        public void AddTask(Task task) {
            tasks.Add(task);
        }
        public bool CheckIndex(int index) {
            if (index < 0 || index >= tasks.Count)
                return false;
            return true;
        }
		public void CompleteTask(int index) {
            if (!CheckIndex(index - 1)) {
                throw new IndexOutOfRangeException();
            }
            else {
                tasks[index-1].CompleteTask();
            }
        }
        public void EditTask(int index, string newName) {
            if (!CheckIndex(index - 1)) {
                throw new IndexOutOfRangeException();
            }
            else {
                tasks[index - 1].Name = newName;
            }
        }
        public void SaveInfo() {
            using (FileStream fs = new FileStream(FILE_PATH, FileMode.Create)) {
                JsonSerializer.Serialize<List<Task>>(fs, tasks);
            }
        }
        public void LoadInfo()
        {
            if(File.Exists(FILE_PATH))
                using (FileStream fs = new FileStream(FILE_PATH, FileMode.Open))
                    tasks = JsonSerializer.Deserialize<List<Task>>(fs);
        }
        public void RemoveTask(int index) {
			if (!CheckIndex(index - 1))
			{
				throw new IndexOutOfRangeException();
			}
			else
			{
                tasks.RemoveAt(index - 1);
			}
		}
        public string GetInfo()
        {
            string result = "";

            for(int i = 0;i<tasks.Count;i++)
				result += $"{i+1}. {tasks[i]}\n";
            return result;
        }
    }
}
