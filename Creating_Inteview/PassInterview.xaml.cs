using Creating_Inteview.questions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Creating_Inteview
{
    public partial class PassInterview : Window
    {
        private Data quest;

        private List<ComboBoxQuestion> comboBoxQuestions = new List<ComboBoxQuestion>();
        private List<GridManyVariantQuestion> gridManyVariantQuestions = new List<GridManyVariantQuestion>();
        private List<GridOneVariantQuestion> gridOneVariantQuestion = new List<GridOneVariantQuestion>();
        private List<LongQuestion> longQuestions = new List<LongQuestion>();
        private List<ShortQuestion> shortQuestions = new List<ShortQuestion>();
        private List<TimeQuestion> timeQuestions = new List<TimeQuestion>();
        private List<CalendarQuestion> calendarQuestions = new List<CalendarQuestion>();
        private List<ManyVariantQuestion> manyVariantQuestions = new List<ManyVariantQuestion>();
        private List<OneVariantQuestion> oneVariantQuestions = new List<OneVariantQuestion>();

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

            button.Click += SaveAnswer_Click;
            button.Style = (Style)button.FindResource("SaveButtonAnswer");

            InterviewBody.Children.Add(button);
            InterviewBody.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(button, InterviewBody.RowDefinitions.Count - 1);
        }

        private void SaveAnswer_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;

            for (int i = 0; i < gridManyVariantQuestions.Count; i++)
            {
                List<CheckBox> checkBoxes = new List<CheckBox>();

                for (int s = gridManyVariantQuestions[i].gridAnswers.Children.Count - gridManyVariantQuestions[i].gridAnswers.RowDefinitions.Count + gridManyVariantQuestions[i].gridAnswers.ColumnDefinitions.Count; s < gridManyVariantQuestions[i].gridAnswers.Children.Count; s++)
                {
                    checkBoxes.Add((CheckBox)gridManyVariantQuestions[i].gridAnswers.Children[s]);
                }

                for (int j = 0; j < checkBoxes.Count; j++)
                {
                    if (checkBoxes[j].IsChecked == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }

            for (int i = 0; i < gridOneVariantQuestion.Count; i++)
            {
                List<RadioButton> radioButtons = new List<RadioButton>();

                for (int s = gridOneVariantQuestion[i].gridAnswers.Children.Count - gridOneVariantQuestion[i].gridAnswers.RowDefinitions.Count + gridOneVariantQuestion[i].gridAnswers.ColumnDefinitions.Count; s < gridOneVariantQuestion[i].gridAnswers.Children.Count; s++)
                {
                    radioButtons.Add((RadioButton)gridOneVariantQuestion[i].gridAnswers.Children[s]);
                }

                for (int j = 0; j < radioButtons.Count; j++)
                {
                    if (radioButtons[j].IsChecked == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }

            for (int i = 0; i < manyVariantQuestions.Count; i++)
            {
                flag = false;
                for (int j = 2; j < manyVariantQuestions[i].grid.Children.Count; j += 2)
                {
                    CheckBox checkBox = (CheckBox)manyVariantQuestions[i].grid.Children[j];

                    if (checkBox.IsChecked == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }

            for (int i = 0; i < oneVariantQuestions.Count; i++)
            {
                flag = false;
                for (int j = 2; j < oneVariantQuestions[i].grid.Children.Count; j += 2)
                {
                    RadioButton checkBox = (RadioButton)oneVariantQuestions[i].grid.Children[j];

                    if (checkBox.IsChecked == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }

            for (int i = 0; i < comboBoxQuestions.Count; i++)
            {
                if (comboBoxQuestions[i].comboBox.SelectedIndex == -1)
                {
                    flag = false;
                    break;
                }
            }

            for (int i = 0; i < longQuestions.Count; i++)
            {
                if (longQuestions[i].textBox.Text == "")
                {
                    flag = false;
                    break;
                }
            }

            for (int i = 0; i < shortQuestions.Count; i++)
            {
                if (shortQuestions[i].textBox.Text == "")
                {
                    flag = false;
                    break;
                }
            }

            for (int i = 0; i < timeQuestions.Count; i++)
            {
                if (timeQuestions[i].hours.Text == "" || timeQuestions[i].minutes.Text == "")
                {
                    flag = false;
                    break;
                }
            }

            for (int i = 0; i < calendarQuestions.Count; i++)
            {
                if (calendarQuestions[i].text.Text == "")
                {
                    flag = false;
                    break;
                }
            }

           
            if (flag)
            {
                MessageBox.Show("Спасибо, что прошли опрос!", "Опросник", MessageBoxButton.OK, MessageBoxImage.Information);

                Close();
            }
            else MessageBox.Show("Не на все вопросы даны ответы!", "Опросник", MessageBoxButton.OK, MessageBoxImage.Information);


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

            comboBoxQuestions.Add(question);

            AddBlock(question.border);
        }
        private void CreateShortQuestion()
        {
            ShortQuestion question = new ShortQuestion(quest.Question_Text);

            shortQuestions.Add(question);

            AddBlock(question.border);
        }
        private void CreateLongQuestion()
        {
            LongQuestion question = new LongQuestion(quest.Question_Text);

            longQuestions.Add(question);

            AddBlock(question.border);
        }
        private void CreateOneVariantQuestion()
        {
            OneVariantQuestion question = new OneVariantQuestion(quest.Question_Text);
            question.AddVariant(quest.LeftOptions.ToArray());

            oneVariantQuestions.Add(question);

            AddBlock(question.border);
        }
        private void CreateTimeQuestion()
        {
            TimeQuestion question = new TimeQuestion();
            question.hours.TextChanged += TimeTextBox_HoursChanged;
            question.minutes.TextChanged += TimeTextBox_MinutesChanged;

            timeQuestions.Add(question);

            AddBlock(question.border);
        }
        private void CreateCalendarQuestuion()
        {
            CalendarQuestion question = new CalendarQuestion();
            question.calendar.SelectedDatesChanged += Calendar_ChangeDate;

            calendarQuestions.Add(question);

            AddBlock(question.border);
        }
        private void CreateManyVariantQuestion()
        {
            ManyVariantQuestion question = new ManyVariantQuestion(quest.Question_Text);
            question.AddVariant(quest.LeftOptions.ToArray());

            manyVariantQuestions.Add(question); 

            AddBlock(question.border);
        }
        private void CreateGridManyVariantQuestion()
        {
            GridManyVariantQuestion question = new GridManyVariantQuestion(quest.Question_Text);
            question.AddVariant(quest.LeftOptions.ToArray(), quest.RightOptions.ToArray());

            gridManyVariantQuestions.Add(question);

            AddBlock(question.border);
        }
        private void CreateGridOneVariantQuestion()
        {
            GridOneVariantQuestion question = new GridOneVariantQuestion(quest.Question_Text);

            question.AddVariant(quest.LeftOptions.ToArray(), quest.RightOptions.ToArray());

            gridOneVariantQuestion.Add(question);

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
