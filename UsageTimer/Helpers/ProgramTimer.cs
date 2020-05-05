namespace Doghouse.Timers
{
	using System;
	using Doghouse.Events;
	using System.Windows.Input;
	using System.Windows.Threading;
	using System.ComponentModel;

	public class ProgramTimer : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler<ProgramTimerEventArgs> ProgramTimeChanged;
		private DispatcherTimer programTimer;
		private string programTime;

		public ProgramTimer()
		{
			this.programTimer = new DispatcherTimer();
			this.programTimer.Interval = TimeSpan.FromSeconds(1);
			this.programTimer.Tick += ProgramTimer_Tick;
			this.programTimer.Start();
			this.ProgramTime = DateTime.Now.ToLongTimeString();
		}

		private void ProgramTimer_Tick(object sender, EventArgs e)
		{
			this.ProgramTime = DateTime.Now.ToLongTimeString();
		}

		public void StartProgramTimer()
		{
			if (programTimer == null)
			{
				this.programTimer = new DispatcherTimer();
				this.programTimer.Interval = TimeSpan.FromSeconds(1);
				this.programTimer.Tick += ProgramTimer_Tick;
				this.programTimer.Start();
				this.ProgramTime = DateTime.Now.ToLongTimeString();
			}
			else
			{
				this.programTimer.Start();
				this.ProgramTime = DateTime.Now.ToLongTimeString();
			}
		}

		public void StopProgramTimer()
		{
			if (programTimer != null)
			{
				this.programTimer.Stop();
			}
		}

		public string ProgramTime
		{
			get
			{
				return programTime;
			}

			set
			{
				if (programTimer != null)
				{
					programTime = value;
					OnPropertyChanged("ProgramTime");
					OnProgramTimeChanged(new ProgramTimerEventArgs(value));
				}
			}
		}

		protected virtual void OnProgramTimeChanged(ProgramTimerEventArgs e)
		{
			EventHandler<ProgramTimerEventArgs> handler = ProgramTimeChanged;
			if (handler != null)
				handler(this, e);
			GC.Collect();
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
