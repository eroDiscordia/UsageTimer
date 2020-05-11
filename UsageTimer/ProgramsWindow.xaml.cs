using Doghouse.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace UsageTimer
{
    /// <summary>
    /// Interaction logic for ProgramsWindow.xaml
    /// </summary>
    public partial class ProgramsWindow : Window
    {

        Process[] processes = Process.GetProcesses();
        CustomList<Process> processList;
        CustomList<KeyValuePair<string, string>> kvpList;
        private const string TIMEFORMAT = "hh\\:mm\\:ss";
        DateTimeTest dateTimeTest;

        public ProgramsWindow()
        {
            InitializeComponent();
            processList = new CustomList<Process>();
            kvpList = new CustomList<KeyValuePair<string, string>>();
            dateTimeTest = new DateTimeTest();
        }

        private void GetProgramsButton_Click(object sender, RoutedEventArgs e)
        {
            GetProcesses();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message.ToString());
                Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void GetProcesses()
        {

            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    processList.Add(p);
                    // OutputListBox.Items.Add(p.MainWindowTitle);
                }
            }
        }

        private void ShowProgramsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Process p in processList)
            {

                DateTime startTime = p.StartTime;
                DateTime currentTime = DateTime.Now;
                TimeSpan h1 = startTime - currentTime;
                TimeSpan h2 = currentTime - startTime;

                TimeSpan diff = currentTime - startTime;
                TimeSpan StateTimeSpanInSeconds;
                TimeSpan StateTimeSpan;
                string StateTime;

                StateTimeSpanInSeconds = TimeSpan.FromSeconds(diff.TotalSeconds);
                StateTimeSpan = DateTime.Now.Subtract(startTime);
                StateTime = StateTimeSpanInSeconds.ToString(TIMEFORMAT);

                Debug.WriteLine(p.ProcessName);
               // Debug.WriteLine(@"Elapsed Time: {0:s\:fff} seconds", DateTime.Now - startTime);
                WriteTimeDetails(StateTimeSpan);
              //  FormatTimeString(StateTimeSpan);
                OutputListBox.Items.Add($"ID: {p.Id}  |   Name:{p.ProcessName}  |  Title: {p.MainWindowTitle} | diff: {StateTime}");
            }
        }

        private void FormatTimeString(TimeSpan interval)
        {
            dateTimeTest.ValueOfDaysComponent = interval.Days;
            dateTimeTest.TotalNumberofDays = interval.TotalDays;

            dateTimeTest.ValueofHoursComponent = interval.Hours;
            dateTimeTest.TotalNumberofHours = interval.TotalHours;

            dateTimeTest.ValueofMinutesComponent = interval.Minutes;
            dateTimeTest.TotalNumberofMinutes = interval.TotalMinutes;

            dateTimeTest.ValueofSecondsComponent = interval.Seconds;
            dateTimeTest.TotalNumberofSeconds = interval.TotalSeconds;

            dateTimeTest.ValueofMillisecondsComponent = interval.Milliseconds;
            dateTimeTest.TotalNumberofMilliseconds = interval.TotalMilliseconds;
            dateTimeTest.Ticks = interval.Ticks;
        }

        private void WriteTimeDetails(TimeSpan interval)
        {

            if (interval.Days >= 1)
            {
                if(interval.Days == 1)
                {
                    Console.WriteLine($"{interval.Days} Day,  {interval.Hours} Hours, {interval.Minutes} Minutes");
                }
                else
                {
                    Console.WriteLine($"{interval.Days} Day(s),  {interval.Hours} Hours, {interval.Minutes} Minutes");
                }
                

            }
            else
            {
                Console.WriteLine($"Hours: {interval.Hours} Minutes: {interval.Minutes}");
            }

            
            // Console.WriteLine("{0:%d} days {0:%h} hours {0:%m} minutes {0:%s} seconds", interval);
            // Display individual properties of the resulting TimeSpan object.
            //Debug.WriteLine("   {0,-35} {1,20}", "Value of Days Component:", interval.Days);
            //Debug.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
            //Debug.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
            //Debug.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
            //Debug.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
            //Debug.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
            //Debug.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
            //Debug.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
            //Debug.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);
            //Debug.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Milliseconds:", interval.TotalMilliseconds);
            //Debug.WriteLine("   {0,-35} {1,20:N0}", "Ticks:", interval.Ticks);
            //Debug.WriteLine("   {0,-35} {1,20:N0}", "----------------------------------------");
        }
    }
}


