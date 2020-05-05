/* -----------------------------------------------------------------
 *   FileName: ProgramTimerEventArgs.cs
 *   Author: Carlos J. Owens
 *   Date: 12/20/2016 Time: 19:49
 *   Copyright (c) Carlos J. Owens
  ----------------------------------------------------------------- */
using System;

namespace Doghouse.Events
{
	/// <summary>
	/// EventArgs for ProgramTimer
	/// </summary>
	public class ProgramTimerEventArgs : EventArgs
	{
		private string programTime;

		public string ProgramTime
		{
			get
			{
				return this.programTime;
			}

			set
			{
				this.programTime = value;
			}
		}

		public ProgramTimerEventArgs(string programtime)
		{
			this.ProgramTime = programtime;
		}
	}
}
