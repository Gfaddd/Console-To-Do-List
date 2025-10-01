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
            if (tasks[index] == null)
                return false;
            return true;
        }
        public void CompleteTask(int index) {
            if (CheckIndex(index)) {
                throw new IndexOutOfRangeException();
            }
            else {
                tasks[index].CompleteTask();
            }
        }
        public void EditTask(int index, string newName) {
            if (CheckIndex(index)) {
                throw new IndexOutOfRangeException();
            }
            else {
                tasks[index].Name = newName;
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
            tasks.RemoveAt(index);
        }
        public string GetInfo()
        {
            string result = "";

            foreach(var i in tasks)
            {
                result += $"{i}\n";
            }
            return result;
        }
    }
}
