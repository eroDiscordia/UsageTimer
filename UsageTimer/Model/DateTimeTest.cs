using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsageTimer
{
    public class DateTimeTest
    {

        #region Constants

        // Constants

        #endregion


        #region Variables

        private double valueOfDaysComponent;
        private double totalNumberofDays;
        private double valueofHoursComponent;
        private double totalNumberofHours;
        private double valueofMinutesComponent;
        private double totalNumberofMinutes;
        private double valueofSecondsComponent;
        private double totalNumberofSeconds;
        private double valueofMillisecondsComponent;
        private double totalNumberofMilliseconds;
        private double ticks;
        

        #endregion


        #region Constructor

        public DateTimeTest()
		{

		}

        #endregion


        #region Events

        // Events

        #endregion


        #region Fields

        public double ValueOfDaysComponent
        {
            get { return valueOfDaysComponent; }
            set { valueOfDaysComponent = value; }
        }
        public double TotalNumberofDays
        {
            get { return totalNumberofDays; }
            set { totalNumberofDays = value; }
        }
        public double ValueofHoursComponent
        {
            get { return valueofHoursComponent; }
            set { valueofHoursComponent = value; }
        }
        public double TotalNumberofHours
        {
            get { return totalNumberofHours; }
            set { totalNumberofHours = value; }
        }
        public double ValueofMinutesComponent
        {
            get { return valueofMinutesComponent; }
            set { valueofMinutesComponent = value; }
        }
        public double TotalNumberofMinutes
        {
            get { return totalNumberofMinutes; }
            set { totalNumberofMinutes = value; }
        }
        public double ValueofSecondsComponent
        {
            get { return valueofSecondsComponent; }
            set { valueofSecondsComponent = value; }
        }
        public double TotalNumberofSeconds
        {
            get { return totalNumberofSeconds; }
            set { totalNumberofSeconds = value; }
        }
        public double ValueofMillisecondsComponent
        {
            get { return valueofMillisecondsComponent; }
            set { valueofMillisecondsComponent = value; }
        }
        public double TotalNumberofMilliseconds
        {
            get { return totalNumberofMilliseconds; }
            set { totalNumberofMilliseconds = value; }
        }
        public double Ticks
        {
            get { return ticks; }
            set { ticks = value; }
        }


        #endregion


        #region	Methods

        public string GetTimeString()
        {
            return "";
        }

        #endregion




    }
}
