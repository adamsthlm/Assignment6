/*
Denna fil har skapats som en del av kursen [C# I] på Malmö Universitet 2020
Namn: Carl-Adam Berglund
e-mail: ak7764@mau.se
*/


using System;

namespace Assignment6
{
	class Task
	{
		// the date field and property
		private DateTime _date;
		public DateTime Date
		{
			get { return _date; }
			set { _date = value; }
		}

		// the description field and property
		private string _description;
		public string Description
		{
			get { return _description; }
			set
			{
				// check for valid string
				if (!string.IsNullOrEmpty(value))
				{
					_description = value;
				}
			}
		}

		// the priority field and property
		private PriorityType _priority;
		public PriorityType Priority
		{
			get { return _priority; }
			set { _priority = value; }
		}

		// CONSTRUCTOR 
		public Task(DateTime date, PriorityType priority, string description)
		{
			_date = date;
			_priority = priority;
			_description = description;
		}

		public Task()
		{
		}


		// priority to string
		public string GetPriorityString() 
		{
			string fix_ToSpace = Priority.ToString();
			fix_ToSpace.Replace('_', ' ');
			return fix_ToSpace;
		}

		// time to string
		public string GetTimeString()
		{
			string time_str = Date.ToString("HH:mm");
			return time_str;
		}

		// ToString

		public override string ToString()
		{
			return $"{Date.ToShortDateString(),-12}" +
					$"{GetTimeString(),-7}" +
					$"{Description}" +
					$"    {GetPriorityString()}";
		}



	} // class
} // namespace
