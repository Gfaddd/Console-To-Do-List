using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_To_Do_List
{
    internal class Task
    {
        private string name;
        private bool isCompleted;
        private DateTime completingTime;
        public Task() { }
        public Task(string name) {
            this.name = name;
        }
        public void CompleteTask()
        {
            isCompleted = true;
            completingTime = DateTime.Now;
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"Некорректное значение названия");
                }
                name = value;
            }
        }
        public DateTime CompletingTime 
        {
            get => completingTime;
            set
            {
				if (value > DateTime.Now)
				{
                    throw new ArgumentOutOfRangeException($"Дата выполнения задачи не может быть больше текущей");
				}
				completingTime = value;
			}
        }
        public bool IsCompleted
        {
            get => isCompleted;

            set => isCompleted = value;
        }

        public override string ToString() => $"{name} {(isCompleted ? $"Выполнена - {completingTime.ToString()}" : "Невыполнена")}";

	}
}
