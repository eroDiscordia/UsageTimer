using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsageTimer.Helpers
{
    public class StateTimerEventArgs : EventArgs
    {
		private string stateTime;

		public string StateTime
		{
			get
			{
				return this.stateTime;
			}

			set
			{
				this.stateTime = value;
			}
		}

		public StateTimerEventArgs(string statetime)
		{
			this.StateTime = statetime;
		}

	}
}
