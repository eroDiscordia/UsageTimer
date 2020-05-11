/* -----------------------------------------------------------------
 *   FileName: StateTimer.cs
 *   Author: Carlos J. Owens
 *   Date: 04/28/2020 Time: 10:32
 *   Copyright (c) Carlos J. Owens
  ----------------------------------------------------------------- */
namespace UsageTimer.Helpers
{
    #region #	Usings					#

    using System;
    using System.Windows.Threading;
    using System.ComponentModel;

    #endregion

    public class StateTimer :  INotifyPropertyChanged
    {

        #region	#	INotifyPropertyChanged implementation		#

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<StateTimerEventArgs> StateTimeChanged;

        #endregion


        #region #	Private Fields						#

        private DispatcherTimer stateTimer;
        private const string ClockFormat = "hh\\:mm\\:ss";

        #endregion

        #region #	Private Properties					#

        private bool isEnabled;
        private string stateTime;
        private TimeSpan stateTimeSpan;
        private TimeSpan stateTimeSpanInSeconds;
        private DateTime stateStartTime;
        private DateTime stateStopTime;


        #endregion #	Private Properties						#


        #region #	Constructor					#

        public StateTimer()
        {
            this.isEnabled = false;

        }

        #endregion #	Constructor					#

        #region #	Public Methods						#

        public void StartStateTimer()
        {
            IsEnabled = true;
            stateTimer = new DispatcherTimer();
            stateTimer.Interval = TimeSpan.FromSeconds(1);
            stateTimer.Tick += StateTimer_Tick;
            StateStartTime = DateTime.Now;
            stateTimer.Start();
        }

        public void StopStateTimer()
        {
            if (isEnabled)
            {
                IsEnabled = false;
                stateTimer.Stop();
                StateStopTime = DateTime.Now;
            }
        }

        #endregion

        #region #	Public Properties					#


        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                isEnabled = value;
            }
        }

        public DateTime StateStartTime
        {
            get
            {
                return stateStartTime;
            }

            set
            {
                if (value == stateStartTime)
                {
                    return;
                }
                stateStartTime = value;
            }
        }

        public DateTime StateStopTime
        {
            get
            {
                return stateStopTime;
            }

            set
            {
                if (value == stateStopTime)
                {
                    return;
                }
                stateStopTime = value;
            }
        }

        public TimeSpan StateTimeSpan
        {
            get
            {
                return stateTimeSpan;
            }

            set
            {
                if (value == stateTimeSpan)
                {
                    return;
                }
                stateTimeSpan = value;
            }
        }

        public TimeSpan StateTimeSpanInSeconds
        {
            get
            {
                return stateTimeSpanInSeconds;
            }

            set
            {
                if (value == stateTimeSpanInSeconds)
                {
                    return;
                }
                stateTimeSpanInSeconds = value;
            }
        }

        public string StateTime
        {
            get
            {
                return stateTime;
            }

            set
            {
                stateTime = value;
                OnPropertyChanged("StateTime");
                OnStateTimeChanged(new StateTimerEventArgs(value));
                // Set(ref stateTime, value);
            }
        }

        #endregion #	Public Properties						#

        #region #	Public Event Handlers					#

        protected virtual void OnStateTimeChanged(StateTimerEventArgs e)
        {
            EventHandler<StateTimerEventArgs> handler = StateTimeChanged;
            if (handler != null)
                handler(this, e);
            GC.Collect();
        }

        public void StateTimer_Tick(object sender, EventArgs e)
        {
            StateTimeSpan = DateTime.Now.Subtract(StateStartTime);
            StateTimeSpanInSeconds = TimeSpan.FromSeconds(StateTimeSpan.TotalSeconds);
            StateTime = StateTimeSpanInSeconds.ToString(ClockFormat);
        }

        #endregion #	Public Event Handlers					#

        #region #	INotifyPropertyChanged Handler			#

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion #	INotifyPropertyChanged Handler			#
    }
}
