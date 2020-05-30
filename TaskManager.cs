using System.Collections.Generic;

namespace Assignment6
{
    class TaskManager
    {
        public List<Task> taskList = new List<Task>();

        public TaskManager()
        {
            taskList = new List<Task>();
        }

        private readonly int _count;

        public int Count
        {
            get { return _count; }
            // set { _count = value; }
        }

        public bool Add(Task taskIN)
        {
            bool ok = false;
            if (taskIN != null)
            {
                taskList.Add(taskIN);
                ok = true;
            }
            return ok;
        }

        public string[] ListToStringArray()
        {
            string[] stringInfoStrings = new string[taskList.Count];
            int i = 0;
            foreach (Task ItemObject in taskList)
            {
                // passing through all the list objects one-by-one until the very end, adding one to i for-each count... Adding, adding.  
                stringInfoStrings[i] = ItemObject.ToString();
                i++;
            }
            return stringInfoStrings;

        }


    }
}
