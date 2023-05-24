﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Creating_Inteview.questions
{
    public class MainBlock
    {
        public Border border { get; }

        public MainBlock() 
        {
            border = new Border();

            Grid grid = new Grid();

            border.Child = grid;

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            TextBlock title = new TextBlock();
            TextBlock description = new TextBlock();

            title.Style = (Style)title.FindResource("TitleText");
            description.Style = (Style)description.FindResource("DescriptionText");
            border.Style = (Style)border.FindResource("TitleBlock");

            grid.Children.Add(title);
            grid.Children.Add(description);
        }
    }
}
