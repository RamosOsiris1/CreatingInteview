using Creating_Inteview.questions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Creating_Inteview
{
    public partial class PassInterview : Window
    {
        private Data quest;

        public MainWindow main;

        public PassInterview()
        {
            InitializeComponent();
        }

        public void LoadInterview(List<Data> interview)
        {

            for (int i = 0; i < interview.Count; i++)
            {
                quest = interview[i];

                if (i == 0) { CreateMainBlock(); continue; }

                switch (interview[i].Question_Index)
                {
                    case -1:
                        CreateTitleTextBlock();
                        break;
                    case 0:
                        CreateShortQuestion();
                        break;
                    case 1:
                        CreateLongQuestion();
                        break;
                    case 2:
                        CreateOneVariantQuestion();
                        break;
                    case 3:
                        CreateManyVariantQuestion();
                        break;
                    case 4:
                        CreateComboBoxQuestion();
                        break;
                    case 5:
                        CreateGridOneVariantQuestion();
                        break;
                    case 6:
                        CreateGridManyVariantQuestion();
                        break;
                    case 7:
                        CreateCalendarQuestuion();
                        break;
                    case 8:
                        CreateTimeQuestion();
                        break;
                }
            }

            CreateButtonSaveAnswer();
        }

        private void CreateButtonSaveAnswer()
        {
            Button button = new Button();

            button.Style = (Style)button.FindResource("SaveButtonAnswer");

            InterviewBody.Children.Add(button);
            InterviewBody.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(button, InterviewBody.RowDefinitions.Count - 1);
        }

        private void CreateMainBlock()
        {
            MainBlock mainBlock = new MainBlock(quest.Title_Text, quest.Description_Text);

            AddBlock(mainBlock.border);
        }

        private void CreateTitleTextBlock()
        {
            TitleTextBlock titleText = new TitleTextBlock(quest.Title_Text, quest.Description_Text);

            AddBlock(titleText.border);
        }

        private void CreateComboBoxQuestion()
        {
            ComboBoxQuestion question = new ComboBoxQuestion(quest.Question_Text, quest.LeftOptions.ToArray());

            AddBlock(question.border);
        }
        private void CreateShortQuestion()
        {
            ShortQuestion question = new ShortQuestion(quest.Question_Text);

            AddBlock(question.border);
        }
        private void CreateLongQuestion()
        {
            LongQuestion question = new LongQuestion(quest.Question_Text);

            AddBlock(question.border);
        }
        private void CreateOneVariantQuestion()
        {
            OneVariantQuestion question = new OneVariantQuestion(quest.Question_Text);
            question.AddVariant(quest.LeftOptions.ToArray());

            AddBlock(question.border);
        }
        private void CreateTimeQuestion()
        {
            TimeQuestion question = new TimeQuestion();
            question.hours.TextChanged += TimeTextBox_HoursChanged;
            question.minutes.TextChanged += TimeTextBox_MinutesChanged;

            AddBlock(question.border);
        }
        private void CreateCalendarQuestuion()
        {
            CalendarQuestion question = new CalendarQuestion();
            question.calendar.SelectedDatesChanged += Calendar_ChangeDate;

            AddBlock(question.border);
        }
        private void CreateManyVariantQuestion()
        {
            ManyVariantQuestion question = new ManyVariantQuestion(quest.Question_Text);
            question.AddVariant(quest.LeftOptions.ToArray());

            AddBlock(question.border);
        }
        private void CreateGridManyVariantQuestion()
        {
            GridManyVariantQuestion question = new GridManyVariantQuestion(quest.Question_Text);
            question.AddVariant(quest.LeftOptions.ToArray(), quest.RightOptions.ToArray());

            AddBlock(question.border);
        }
        private void CreateGridOneVariantQuestion()
        {
            GridOneVariantQuestion question = new GridOneVariantQuestion(quest.Question_Text);
            question.AddVariant(quest.LeftOptions.ToArray(), quest.RightOptions.ToArray());

            AddBlock(question.border);
        }
        private void AddBlock(Border block)
        {
            InterviewBody.Children.Add(block);
            InterviewBody.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(block, InterviewBody.RowDefinitions.Count - 1);
        }

        private void Calendar_ChangeDate(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            Grid grid = (Grid)calendar.Parent;

            TextBox textBox = (TextBox)grid.Children[1];

            textBox.Text = grid.Children[2].ToString().Split(' ')[0];
        }
        private void TimeTextBox_HoursChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (int.TryParse(textBox.Text, out int result))
            {
                if (int.Parse(textBox.Text) >= 24 || int.Parse(textBox.Text) < 0) textBox.Text = "";
                if (result < 24 && result > 0) textBox.Text = result.ToString();
            }
            else if (textBox.Text != "00") textBox.Text = "";
        }
        private void TimeTextBox_MinutesChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (int.TryParse(textBox.Text, out int result))
            {
                if (int.Parse(textBox.Text) >= 60 || int.Parse(textBox.Text) < 0) textBox.Text = "";
                if (result < 60 && result > 0) textBox.Text = result.ToString();
            }
            else if (textBox.Text != "00") textBox.Text = "";
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            main.IsEnabled = true;
        }
    }
}
