using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IntroductionToWPF
{
    public class Match
    {
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public string Team1 { get; set; }
        public string Team2 { get; set; }

        public int Completion { get; set; }


    }

    /// <summary>
    /// Interaction logic for ListBoxDemo.xaml
    /// </summary>
    public partial class ListBoxDemo : Page
    {
       
        public ListBoxDemo()
        {



            InitializeComponent();

            List<Match> matches = new List<Match>()
            {
                new Match(){Team1="Munich",Team2="Barcelona",Score1=3,Score2=1,Completion = 65},
                new Match(){Team1="Berlin",Team2="Barcelona",Score1=2,Score2=1,Completion = 45},
                new Match(){Team1="Zurich",Team2="Madrid",Score1=3,Score2=2,Completion = 85},
            };
           
            lbMatches.ItemsSource = matches;

        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(lbMatches.SelectedItem != null)
            {
                var currentMatch = lbMatches.SelectedItem as Match;

                MessageBox.Show($"  Selected Match:  {currentMatch.Team1} = {currentMatch.Score1} Score and {currentMatch.Team2}" +
                 $" = {currentMatch.Score2} Score , Completion = {currentMatch.Completion} minutes.");
            }

        }
    }
}
