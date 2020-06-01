using System.Collections.Generic;

namespace Assignment6
{
    class TaskManager
    {
        int _count;
        public List<Task> taskList = new List<Task>();

        public TaskManager()
        {
            taskList = new List<Task>();
          
        }

       

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public void
            Add(Task taskIN)
        {
            
            if (taskIN != null)
            {
                taskList.Add(taskIN);
                Count++;
            }
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
