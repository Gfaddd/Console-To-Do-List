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
        public TaskHandler() { 
            tasks = new List<Task>();
        }
        public void AddTask(Task task) {
            tasks.Add(task);
        }
        public void CompleteTask(int index) {
            if (tasks[index] == null) {
                throw new IndexOutOfRangeException();
            }
            else {
                tasks[index].CompleteTask();
            }
        }
        public void EditTask(int index, string newName) {
            tasks[index].Name = newName;
        }
        public void SaveInfo() {
            using (FileStream fs = new FileStream("addedTasks.txt", FileMode.Create)) {
                JsonSerializer.Serialize<List<Task>>(fs, tasks);
            }
        }
        public void LoadInfo()
        {
            using (FileStream fs = new FileStream("addedTasks.txt", FileMode.Open)) {
                tasks = JsonSerializer.Deserialize<List<Task>>(fs);
            }
        }
        public void RemoveTask(int index) {
            tasks.RemoveAt(index);
        }
    }
}
