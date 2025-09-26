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
        public void compleatTask()
        {
            isCompleted = true;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
            }
        }
        public DateTime CompletingTime { get { return completingTime; } }
    }
}
