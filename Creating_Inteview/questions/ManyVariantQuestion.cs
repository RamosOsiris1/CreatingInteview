using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Creating_Inteview.questions
{
    public class ManyVariantQuestion
    {
        public Border border { get; }
        Grid grid;
        public ManyVariantQuestion()
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

        public void AddVariant(int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                TextBlock nameVariant = new TextBlock();
                CheckBox radioButton = new CheckBox();

                nameVariant.Style = (Style)nameVariant.FindResource("TextVariant");
                radioButton.Style = (Style)radioButton.FindResource("CheckBoxQuestion");

                grid.Children.Add(nameVariant);
                grid.Children.Add(radioButton);

                grid.RowDefinitions.Add(new RowDefinition());

                Grid.SetRow(nameVariant, i);
                Grid.SetRow(radioButton, i);
            }
        }
    }
}
