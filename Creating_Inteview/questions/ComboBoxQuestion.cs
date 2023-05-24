using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Creating_Inteview.questions
{
    public class ComboBoxQuestion
    {
        public Border border { get; }

        public ComboBoxQuestion() 
        { 
            border = new Border();
            Grid grid = new Grid();

            border.Child = grid;

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            TextBlock textBlock = new TextBlock();
            ComboBox comboBox = new ComboBox();

            grid.Children.Add(textBlock);
            grid.Children.Add(comboBox);

            border.Style = (Style)grid.FindResource("TitleBlock");
            textBlock.Style = (Style)textBlock.FindResource("DescriptionText");
            comboBox.Style = (Style)comboBox.FindResource("ComboBoxQuestion");
        }   
    }
}
