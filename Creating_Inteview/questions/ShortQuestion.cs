﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Creating_Inteview.questions
{
    public class ShortQuestion
    {
        public Border border { get; }

        public ShortQuestion(string textQuestion)
        {
            border = new Border();
            Grid grid = new Grid();

            border.Child = grid;

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            TextBlock textBlock = new TextBlock();
            TextBox textBox = new TextBox();

            textBlock.Text = textQuestion;

            grid.Children.Add(textBlock);
            grid.Children.Add(textBox);

            border.Style = (Style)grid.FindResource("TitleBlock");
            textBlock.Style = (Style)textBlock.FindResource("DescriptionText");
            textBox.Style = (Style)textBox.FindResource("ShortTextBoxQuestion");
        }
    }
}
