using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Creating_Inteview.questions
{
    public class TimeQuestion
    {
        public Border border { get; }
        public TextBox hours { get; }
        public TextBox minutes { get; }

        public TimeQuestion()
        {
            border = new Border();
            Grid grid = new Grid();

            border.Child = grid;

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            TextBlock textBlock = new TextBlock();
            hours = new TextBox();
            minutes = new TextBox();

            grid.Children.Add(textBlock);
            grid.Children.Add(hours);
            grid.Children.Add(minutes);

            border.Style = (Style)grid.FindResource("TitleBlock");
            textBlock.Style = (Style)textBlock.FindResource("DescriptionText");
            hours.Style = (Style)hours.FindResource("HoursTextBox");
            minutes.Style = (Style)minutes.FindResource("MinutesTextBox");
        }
    }
}
