using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Creating_Inteview.questions
{
    internal class GridManyVariantQuestion
    {
        public Border border { get; }
        Grid grid;
        public GridManyVariantQuestion()
        {
            border = new Border();
            grid = new Grid();

            border.Child = grid;

            grid.RowDefinitions.Add(new RowDefinition());

            TextBlock textBlock = new TextBlock();

            grid.Children.Add(textBlock);

            border.Style = (Style)grid.FindResource("TitleBlock");
            textBlock.Style = (Style)textBlock.FindResource("DescriptionText");
        }

        public void AddVariant(int countColumn, int countRow)
        {
            for (int i = 1; i < countColumn + 1; i++)
            {
                TextBlock row = new TextBlock();

                Grid.SetRow(row, i + 1);

                for (int j = 0; j < countRow + 1; j++)
                {
                    TextBlock column = new TextBlock();

                    Grid.SetRow(column, i);


                }
                
            }
        }
    }
}
