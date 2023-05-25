using System;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;
using Label = System.Windows.Controls.Label;

namespace Creating_Inteview
{
    internal class Question
    {
        [JsonIgnore]
        private Border border = new Border();
        [JsonIgnore]

        private Grid bodyQuestion = new Grid();
        [JsonIgnore]
        private Grid listAnswersLeft = new Grid();
        [JsonIgnore]
        private Grid listAnswersRight = new Grid();
        [JsonIgnore]

        private TextBox question = new TextBox();
        [JsonIgnore]
        private ComboBox comboBox = new ComboBox();
        [JsonIgnore]
        private TextBox stringAnswer = new TextBox();
        [JsonIgnore]

        private Button addAnswerLeft = new Button();
        [JsonIgnore]
        private Button removeAnswerLeft = new Button();
        [JsonIgnore]

        private Button addAnswerRight = new Button();
        [JsonIgnore]
        private Button removeAnswerRight = new Button();
        [JsonIgnore]

        private Border addButtonNewAnswer = new Border();
        [JsonIgnore]
        private Border removeButtonAnswer = new Border();
        [JsonIgnore]
        private Border addButtonNewTitleBlock = new Border();
        [JsonIgnore]

        private TextBox title = new TextBox();
        [JsonIgnore]
        private TextBox description = new TextBox();
        [JsonIgnore]

        public string style;
        [JsonIgnore]

        public Border GetBorder => border;
        [JsonIgnore]
        public ComboBox GetComboBox => comboBox;
        [JsonIgnore]
        public Grid GetGrid => bodyQuestion;
        [JsonIgnore]

        public TextBox GetQuestion => question;
        [JsonIgnore]

        public Button GetButton_addAnswerLeft => addAnswerLeft;
        [JsonIgnore]
        public Button GetButton_removeAnswerLeft => removeAnswerLeft;
        [JsonIgnore]

        public Button GetButton_addAnswerRight => addAnswerRight;
        [JsonIgnore]
        public Button GetButton_removeAnswerRight => removeAnswerRight;
        [JsonIgnore]

        public Image GetButton_Image_addButtonNewAnswer => Image_addButtonNewAnswer;
        [JsonIgnore]
        public Image GetButton_Image_removeButtonAnswer => Image_removeButtonAnswer;
        [JsonIgnore]
        public Image GetButton_Image_addButtonTitleBlock => Image_addButtonTitleBlock;
        [JsonIgnore]
        public TextBox GetTitle => title;
        [JsonIgnore]
        public TextBox GetDescription => description;

        [JsonIgnore]
        private Image Image_addButtonNewAnswer = new Image();
        [JsonIgnore]
        private Image Image_removeButtonAnswer = new Image();
        [JsonIgnore]
        private Image Image_addButtonTitleBlock = new Image();


        public int ComboBox_Index => comboBox.SelectedIndex;
        public string Title_Text => title.Text;
        public string Description_Text => description.Text;
        public string Question_Text => question.Text;

        public Grid Get_RightList => listAnswersRight;
        public Grid Get_LeftList => listAnswersLeft;

        public Question()
        {
            border.Child = bodyQuestion;

            for (int i = 0; i < 2; i++) bodyQuestion.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 7; i++) bodyQuestion.RowDefinitions.Add(new RowDefinition());

            bodyQuestion.Children.Add(question);
            bodyQuestion.Children.Add(comboBox);
            bodyQuestion.Children.Add(stringAnswer);

            bodyQuestion.Children.Add(listAnswersLeft);
            bodyQuestion.Children.Add(listAnswersRight);

            bodyQuestion.Children.Add(addAnswerLeft);
            bodyQuestion.Children.Add(removeAnswerLeft);

            bodyQuestion.Children.Add(addAnswerRight);
            bodyQuestion.Children.Add(removeAnswerRight);

            bodyQuestion.Children.Add(title);
            bodyQuestion.Children.Add(description);

            bodyQuestion.Children.Add(addButtonNewAnswer);
            bodyQuestion.Children.Add(removeButtonAnswer);
            bodyQuestion.Children.Add(addButtonNewTitleBlock);

            for (int i = 0; i < 2; i++) listAnswersLeft.ColumnDefinitions.Add(new ColumnDefinition());
            listAnswersLeft.ColumnDefinitions[0].Width = GridLength.Auto;

            for (int i = 0; i < 2; i++) listAnswersRight.ColumnDefinitions.Add(new ColumnDefinition());
            listAnswersRight.ColumnDefinitions[0].Width = GridLength.Auto;

            border.Style = (Style)border.FindResource("QuestionBody");

            question.Style = (Style)question.FindResource("Question");
            comboBox.Style = (Style)comboBox.FindResource("ListQuestion");
            stringAnswer.Style = (Style)stringAnswer.FindResource("Answer");

            addAnswerLeft.Style = (Style)addAnswerLeft.FindResource("AddOptionAnswer");
            removeAnswerLeft.Style = (Style)removeAnswerLeft.FindResource("RemoveOptionAnswer");

            addAnswerRight.Style = (Style)addAnswerRight.FindResource("AddOptionAnswer");
            removeAnswerRight.Style = (Style)removeAnswerRight.FindResource("RemoveOptionAnswer");

            addButtonNewAnswer.Style = (Style)addButtonNewAnswer.FindResource("AddButtonNewAnswer");
            removeButtonAnswer.Style = (Style)removeButtonAnswer.FindResource("RemoveButtonAnswer");
            addButtonNewTitleBlock.Style = (Style)addButtonNewTitleBlock.FindResource("AddButtonTitleBlock");

            Image_addButtonNewAnswer.Style = (Style)Image_addButtonNewAnswer.FindResource("AddAnswerImage");
            Image_removeButtonAnswer.Style = (Style)Image_removeButtonAnswer.FindResource("RemoveAnswerImage");
            Image_addButtonTitleBlock.Style = (Style)Image_addButtonTitleBlock.FindResource("AddTitleBlockImage");

            title.Style= (Style)title.FindResource("MyWaterMarkStyle");
            description.Style= (Style)description.FindResource("MyWaterMarkStyle");

            listAnswersLeft.Tag = "left";
            listAnswersRight.Tag = "right";

            comboBox.Items.Add("Текст (строка)");
            comboBox.Items.Add("Текст (абзац)");
            comboBox.Items.Add("Один из списка");
            comboBox.Items.Add("Несколько из списка");
            comboBox.Items.Add("Раскрывающийся список");
            comboBox.Items.Add("Сетка (множ. выбор)");
            comboBox.Items.Add("Сетка флажков");
            comboBox.Items.Add("Дата");
            comboBox.Items.Add("Время");

            addButtonNewAnswer.Child = Image_addButtonNewAnswer;
            removeButtonAnswer.Child = Image_removeButtonAnswer;
            addButtonNewTitleBlock.Child = Image_addButtonTitleBlock;

            comboBox.SelectedIndex = -1;

            addAnswerLeft.Tag = "0";
            removeAnswerLeft.Tag = "0";

            addAnswerRight.Tag = "1";
            removeAnswerRight.Tag = "1";

            Grid.SetRow(question, 0);
            Grid.SetColumn(question, 0);

            Grid.SetRow(comboBox, 0);
            Grid.SetColumn(comboBox, 1);

            Grid.SetRow(stringAnswer, 1);
            Grid.SetColumn(stringAnswer, 0);

            /*****/

            Grid.SetRow(listAnswersLeft, 2);
            Grid.SetColumn(listAnswersLeft, 0);

            Grid.SetRow(listAnswersRight, 2);
            Grid.SetColumn(listAnswersRight, 1);

            /*******/

            Grid.SetRow(addAnswerLeft, 3);
            Grid.SetColumn(addAnswerLeft, 0);

            Grid.SetRow(removeAnswerLeft, 3);
            Grid.SetColumn(removeAnswerLeft, 0);

            Grid.SetRow(addAnswerRight, 3);
            Grid.SetColumn(addAnswerRight, 1);

            Grid.SetRow(removeAnswerRight, 3);
            Grid.SetColumn(removeAnswerRight, 1);

            /**********/

            Grid.SetRow(addButtonNewAnswer, 4);
            Grid.SetColumn(addButtonNewAnswer, 1);

            Grid.SetRow(addButtonNewTitleBlock, 4);
            Grid.SetColumn(addButtonNewTitleBlock, 1);

            Grid.SetRow(removeButtonAnswer, 4);
            Grid.SetColumn(removeButtonAnswer, 1);

            /**********/

            Grid.SetRow(Image_addButtonNewAnswer, 4);
            Grid.SetColumn(Image_addButtonNewAnswer, 1);

            Grid.SetRow(Image_addButtonTitleBlock, 4);
            Grid.SetColumn(Image_addButtonTitleBlock, 1);

            Grid.SetRow(Image_removeButtonAnswer, 4);
            Grid.SetColumn(Image_removeButtonAnswer, 1);

            /**********/

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 0);

            Grid.SetRow(description, 1);
            Grid.SetColumn(description, 0);
        }

        public Question(string title, string description) : this()
        {
            this.title.Text = title;
            this.description.Text = description;
        }

        public Question(string textQuestion, int indexQuestion) : this()
        {
            question.Text = textQuestion;
            comboBox.SelectedIndex = indexQuestion;
        }

        public void AddStringAnswer(string text)
        {
            HideMainElement();

            stringAnswer.Visibility = Visibility.Visible;

            stringAnswer.Text = text;
        }

        public void AddListAnswerLeft(bool flag)
        {
            HideMainElement();

            if (flag)
            {
                listAnswersLeft.Children.Clear();
                listAnswersLeft.RowDefinitions.Clear();
            }

            listAnswersLeft.Visibility = Visibility.Visible;

            addAnswerLeft.Visibility = Visibility.Visible;
            removeAnswerLeft.Visibility = Visibility.Visible;

            AddOptionAnswer(listAnswersLeft);
        }

        public void AddListAnswerBoth(bool flag)
        {
            HideMainElement();

            if (flag)
            {
                listAnswersLeft.Children.Clear();
                listAnswersLeft.RowDefinitions.Clear();

                listAnswersRight.Children.Clear();
                listAnswersRight.RowDefinitions.Clear();
            }

            listAnswersLeft.Visibility = Visibility.Visible;
            listAnswersRight.Visibility = Visibility.Visible;

            addAnswerLeft.Visibility = Visibility.Visible;
            removeAnswerLeft.Visibility = Visibility.Visible;

            addAnswerRight.Visibility = Visibility.Visible;
            removeAnswerRight.Visibility = Visibility.Visible;

            AddOptionAnswer(listAnswersLeft);
            AddOptionAnswer(listAnswersRight); 
        }

        private void SelectLabel(Grid grid)
        {
            style = "LabelOptionAnswer";

            Label label = new Label();
            label.Style = (Style)label.FindResource(style);

            label.Content += $"{grid.RowDefinitions.Count}.";

            grid.Children.Add(label);

            Grid.SetRow(label, grid.RowDefinitions.Count - 1);
            Grid.SetColumn(label, 0);
        }

        private void SelectFigure(Grid grid)
        {
            style = "CircleButtonOptionAnswer";

            if (comboBox.SelectedIndex == 2 || comboBox.SelectedIndex == 5) style = "CircleButtonOptionAnswer";
            else if (comboBox.SelectedIndex == 3 || comboBox.SelectedIndex == 6) style = "SquareButtonOptionAnswer";

            Rectangle figure = new Rectangle();
            figure.Style = (Style)figure.FindResource(style);

            grid.Children.Add(figure);

            Grid.SetRow(figure, grid.RowDefinitions.Count - 1);
            Grid.SetColumn(figure, 0);
        }

        public void AddOptionAnswer(Grid grid, string s = "")
        {
            TextBox textBox = new TextBox();

            textBox.Style = (Style)textBox.FindResource("OptionAnswer");

            textBox.Text = s;

            textBox.Tag += $"Вариант {grid.RowDefinitions.Count + 1}";

            grid.RowDefinitions.Add(new RowDefinition());

            int index = comboBox.SelectedIndex;

            if (index == 4 || (grid.Tag.ToString() == "left" && index == 5) || (grid.Tag.ToString() == "left" && index == 6)) SelectLabel(grid);
            else SelectFigure(grid);

            grid.Children.Add(textBox);

            Grid.SetColumn(textBox, 1);
            Grid.SetRow(textBox, grid.RowDefinitions.Count - 1);
        }

        public void RemoveOptionAnswer(Grid grid)
        {
            int index0 = grid.RowDefinitions.Count - 1;
            int index1 = grid.Children.Count;

            if (index0 > 0)
            {
                grid.Children.RemoveRange(index1 - 2, 2);
                grid.RowDefinitions.RemoveAt(index0);
            }
        }

        public void HideMainElement()
        {
            addAnswerLeft.Visibility = Visibility.Collapsed;
            removeAnswerLeft.Visibility = Visibility.Collapsed;

            addAnswerRight.Visibility = Visibility.Collapsed;
            removeAnswerRight.Visibility = Visibility.Collapsed;

            listAnswersLeft.Visibility = Visibility.Collapsed;
            listAnswersRight.Visibility = Visibility.Collapsed;

            stringAnswer.Visibility = Visibility.Collapsed;

            title.Visibility = Visibility.Collapsed;
            description.Visibility = Visibility.Collapsed;
        }
        public void HideAllElement()
        {
            listAnswersLeft.Children.Clear();
            listAnswersRight.Children.Clear();

            question.Visibility= Visibility.Collapsed;
            comboBox.Visibility= Visibility.Collapsed;
            stringAnswer.Visibility= Visibility.Collapsed;

            addAnswerLeft.Visibility= Visibility.Collapsed;
            addAnswerRight.Visibility= Visibility.Collapsed;

            removeAnswerLeft.Visibility=Visibility.Collapsed;
            removeAnswerRight.Visibility= Visibility.Collapsed;
        }
    }
}
