using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.Common;

namespace Creating_Inteview.questions
{
    public class GridManyVariantQuestion
    {
        public Border border { get; }
        Grid grid;
        public Grid gridAnswers;
        public GridManyVariantQuestion(string textQuestion)
        {
            border = new Border();
            grid = new Grid();

            gridAnswers = new Grid();

            border.Child = grid;

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            gridAnswers.RowDefinitions.Add(new RowDefinition());
            gridAnswers.ColumnDefinitions.Add(new ColumnDefinition());

            TextBlock textBlock = new TextBlock();

            textBlock.Text = textQuestion;

            grid.Children.Add(textBlock);
            grid.Children.Add(gridAnswers);

            border.Style = (Style)grid.FindResource("TitleBlock");
            textBlock.Style = (Style)textBlock.FindResource("DescriptionText");

            Grid.SetRow(textBlock, 0);
            Grid.SetRow(gridAnswers, 1);
        }

        public void AddVariant(string[] rows, string[] columns)
        {
            int countRow = rows.Length;
            int countColumn = columns.Length;

            for (int j = 0; j < countRow; j++)
            {
                TextBlock row = new TextBlock();
                row.Text = $"{j + 1}";

                gridAnswers.RowDefinitions.Add(new RowDefinition());
                gridAnswers.Children.Add(row);

                Grid.SetRow(row, j + 1);
                Grid.SetColumn(row, 0);
            }

            for (int i = 0; i < countColumn; i++)
            {
                TextBlock column = new TextBlock();
                column.Text = $"{i + 1}";

                gridAnswers.ColumnDefinitions.Add(new ColumnDefinition());
                gridAnswers.Children.Add(column);

                Grid.SetColumn(column, i + 1);
                Grid.SetRow(column, 0);
            }

            for (int i = 1; i < countRow + 1; i++)
            {
                for (int j = 1; j < countColumn + 1; j++)
                {
                    CheckBox checkBox = new CheckBox();

                    gridAnswers.Children.Add(checkBox);

                    Grid.SetColumn(checkBox, j);
                    Grid.SetRow(checkBox, i);
                }
            }
        }
    }
}
