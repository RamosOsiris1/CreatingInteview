using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Creating_Inteview.questions
{
    public class CalendarQuestion
    {
        public Border border { get; }
        public Calendar calendar { get; }

        public TextBox text { get; }

        public CalendarQuestion()
        {
            border = new Border();
            Grid grid = new Grid();

            border.Child = grid;

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            TextBlock textBlock = new TextBlock();
            text = new TextBox();
            calendar = new Calendar();

            grid.Children.Add(textBlock);
            grid.Children.Add(text);
            grid.Children.Add(calendar);

            border.Style = (Style)grid.FindResource("TitleBlock");
            textBlock.Style = (Style)textBlock.FindResource("DescriptionText");
            text.Style = (Style)text.FindResource("DateTextBox");
            calendar.Style = (Style)calendar.FindResource("CalendarQuestion");
        }
    }
}
