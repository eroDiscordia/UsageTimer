using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Doghouse;
using Doghouse.Events;
using Doghouse.Timers;
using Doghouse.Tools;
using UsageTimer.Helpers;


/// <summary>
/// Purpose track usage time of applications run by the user
/// ability to 
///  know if program is background/idle such as spotify
/// 
/// Will later add ability to track additional applications
/// </summary>
namespace UsageTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ProgramTimer programTimer;
        StateTimer stateTimer;
        CustomList<string> colorNames;
        Dictionary<string, string> dictionary;
        ResourceDictionary rd;
        string currentColor;


        public MainWindow()
        {

            SetUpClock();
            InitializeComponent();
            DataContext = stateTimer;
            colorNames = new CustomList<string>();
            // BuildColorList();
            BuildGreyColorList();
            //  rd = new ResourceDictionary();


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

        private void OffButton_Click(object sender, RoutedEventArgs e)
        {
            stateTimer.StopStateTimer();
        }

        private void OnButton_Click(object sender, RoutedEventArgs e)
        {
            
            stateTimer.StartStateTimer();
          //  CurrentApplicationTotalTimeLabel.Content = stateTimer.StateStartTime;
        }

        private void SetUpClock()
        {
            stateTimer = new StateTimer();
            programTimer = new ProgramTimer();

            stateTimer.StateTimeChanged += StateTimer_StateTimeChanged;
            programTimer.ProgramTimeChanged += ProgramTimer_ProgramTimeChanged;
            
        }

        private void StateTimer_StateTimeChanged(object sender, StateTimerEventArgs e)
        {
            CurrentApplicationTimeLabel.Content = stateTimer.StateTime;
        }

        private void ProgramTimer_ProgramTimeChanged(object sender, ProgramTimerEventArgs e)
        {
            CurrentApplicationLabel.Content = programTimer.ProgramTime;
        }



        private void BuildGreyColorList()
        {
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("pack://application:,,,/Color/GreyColors.xaml", UriKind.RelativeOrAbsolute);

            foreach (var k in resourceDictionary.Keys)
            {
                if (k.ToString().Contains("brush"))
                {
                    colorNames.Add(k.ToString());
                }
            }

        }

        private void BuildColorList()
        {
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("pack://application:,,,/Color/FinalColors.xaml", UriKind.RelativeOrAbsolute);

            foreach (var k in resourceDictionary.Keys)
            {
                if (k.ToString().Contains("Brush"))
                {
                    colorNames.Add(k.ToString());
                }
            }

        }

        private void NextColorButton_Click(object sender, RoutedEventArgs e)
        {
            currentColor = colorNames.MoveNext;
            CurrentApplicationTimeLabel.Foreground = (Brush)this.FindResource(currentColor);
            CurrentColorNameLabel.Foreground = (Brush)this.FindResource(currentColor);
            CurrentColorNameLabel.Content = currentColor;
        }

        private void LastColorButton_Click(object sender, RoutedEventArgs e)
        {
            currentColor = colorNames.MovePrevious;
            CurrentApplicationTimeLabel.Foreground = (Brush)this.FindResource(currentColor);
            CurrentColorNameLabel.Foreground = (Brush)this.FindResource(currentColor);
            CurrentColorNameLabel.Content = currentColor;
        }


        private void SetLabelColor()
        {
            Dispatcher.Invoke(() =>
            {
                CurrentApplicationTimeLabel.Foreground = (Brush)Application.Current.Resources[currentColor];
            });
           
        }

    }
}
