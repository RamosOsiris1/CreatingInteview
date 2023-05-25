using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using Image = System.Windows.Controls.Image;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections;


namespace Creating_Inteview
{
    public partial class CreateInterview : Window
    {
        private Question question;

        private List<Question> questions = new List<Question>();

        private bool isLoaded = true;

        public MainWindow main;

        public CreateInterview()
        {
            InitializeComponent();

            CreateMainBlock();
        }
        private Border CreateBorderAnswer(string[] left, string[] right, int i = 0, string questionText = "", int indexQuestion = -1)
        {
            if (questionText == "") question = new Question();
            else question = new Question(questionText, indexQuestion);

            Border border = question.GetBorder;
            ComboBox comboBox = question.GetComboBox;
            TextBox textBox = question.GetQuestion;

            Button addAnswerLeft = question.GetButton_addAnswerLeft;
            Button removeAnswerLeft = question.GetButton_removeAnswerLeft;

            Button addAnswerRight = question.GetButton_addAnswerRight;
            Button removeAnswerRight = question.GetButton_removeAnswerRight;

            Image addNewAnswear = question.GetButton_Image_addButtonNewAnswer;
            Image removeAnswear = question.GetButton_Image_removeButtonAnswer;
            Image addTitleBlock = question.GetButton_Image_addButtonTitleBlock;

            Grid bodyQuestion = question.GetGrid;

            addAnswerLeft.Click += AddOptionAnswer_Button_Click;
            removeAnswerLeft.Click += RemoveOptionAnswer_Button_Click;

            addAnswerRight.Click += AddOptionAnswer_Button_Click;
            removeAnswerRight.Click += RemoveOptionAnswer_Button_Click;

            addNewAnswear.MouseDown += AddNewAnswer_Button_Click;
            removeAnswear.MouseDown += RemoveAnswer_Button_Click;
            addTitleBlock.MouseDown += AddTitleBlock_Block_Click;

            if (questionText == "") comboBox.SelectedIndex = 0;

            comboBox.SelectionChanged += ComboBox_SelectionChanged;

            textBox.Tag = "Вопрос";
            
            questions.Insert(i, question);

            question.HideMainElement();

            if (left.Length != 0 || right.Length != 0)
            {
                for (int j = 0; j < left.Length; j++)
                {
                    question.AddOptionAnswer(question.Get_LeftList, left[j]);
                }

                for (int j = 0; j < right.Length; j++)
                {
                    question.AddOptionAnswer(question.Get_RightList, right[j]);
                }
            }

            return border;
        }

        private Border CreateMainBlock(string title = "", string desc = "")
        {
            if (title == "") question = new Question();
            else question = new Question(title, desc);

            TextBox titleTextBox = question.GetTitle;
            TextBox descTextBox = question.GetDescription;

            Border border = question.GetBorder;

            Grid bodyQuestion = question.GetGrid;

            titleTextBox.Tag = "Новый опрос";
            descTextBox.Tag = "Описание";

            titleTextBox.FontSize = 28;

            Image addNewAnswear = question.GetButton_Image_addButtonNewAnswer;
            Image removeAnswear = question.GetButton_Image_removeButtonAnswer;
            Image addTitleBlock = question.GetButton_Image_addButtonTitleBlock;

            addNewAnswear.MouseDown += AddNewAnswer_Button_Click;
            addTitleBlock.MouseDown += AddTitleBlock_Block_Click;

            removeAnswear.Visibility = Visibility.Collapsed;

            InterviewBody.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(border, 0);

            InterviewBody.Children.Add(border);

            questions.Add(question);

            bodyQuestion.Tag = "0";

            question.HideAllElement();

            return border;
        }

        private Border CreateTitleBlock(int i, string titleText = "", string descText = "")
        {
            question = new Question();

            TextBox title = question.GetTitle;
            TextBox description = question.GetDescription;

            Border border = question.GetBorder;

            Grid bodyQuestion = question.GetGrid;

            title.Text = titleText;
            description.Text = descText;

            title.Tag = "Заголовок";
            description.Tag = "Описание";

            Image addNewAnswear = question.GetButton_Image_addButtonNewAnswer;
            Image removeAnswear = question.GetButton_Image_removeButtonAnswer;
            Image addTitleBlock = question.GetButton_Image_addButtonTitleBlock;

            addNewAnswear.MouseDown += AddNewAnswer_Button_Click;
            removeAnswear.MouseDown += RemoveAnswer_Button_Click;
            addTitleBlock.MouseDown += AddTitleBlock_Block_Click;

            questions.Insert(i, question);

            question.HideAllElement();

            return border;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox list = (ComboBox)sender;
            Grid grid = (Grid)list.Parent;

            int index = int.Parse(grid.Tag.ToString());

            switch (list.SelectedIndex)
            {
                case 0:
                    questions[index].AddStringAnswer("Краткий ответ");
                    break;
                case 1:
                    questions[index].AddStringAnswer("Развернутый ответ");
                    break;
                case 2:
                    questions[index].AddListAnswerLeft(isLoaded);
                    break;
                case 3:
                    questions[index].AddListAnswerLeft(isLoaded);
                    break;
                case 4:
                    questions[index].AddListAnswerLeft(isLoaded);
                    break;
                case 5:
                    questions[index].AddListAnswerBoth(isLoaded);
                    break;
                case 6:
                    questions[index].AddListAnswerBoth(isLoaded);
                    break;
                case 7:
                    questions[index].AddStringAnswer("Дата, месяц, год");
                    break;
                case 8:
                    questions[index].AddStringAnswer("Время");
                    break;
            }
        }

        public void AddOptionAnswer_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Grid grid = (Grid)button.Parent;

            Grid answers;

            int index = int.Parse(grid.Tag.ToString());

            if (button.Tag.ToString() == "0") answers = (Grid)grid.Children[3];
            else answers = (Grid)grid.Children[4];

            questions[index].AddOptionAnswer(answers);
        }

        public void RemoveOptionAnswer_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Grid grid = (Grid)button.Parent;

            Grid answers;

            int index = int.Parse(grid.Tag.ToString());

            if (button.Tag.ToString() == "0") answers = (Grid)grid.Children[3];
            else answers = (Grid)grid.Children[4];

            questions[index].RemoveOptionAnswer(answers);
        }

        public void AddNewAnswer_Button_Click(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;

            AddNewBlock(true, img);
        }

        private void AddNewBlock(bool isAnswer, Image img)
        {
            Border brd = (Border)img.Parent;
            Grid grid = (Grid)brd.Parent;

            int index = int.Parse(grid.Tag.ToString());

            List<Border> borders = new List<Border>();

            int count = InterviewBody.Children.Count;

            for (int i = 0; i < count; i++)
            {
                Border border = (Border)InterviewBody.Children[i];

                borders.Add(border);

                if (i == index)
                {
                    Border newBorder;

                    string[] str1 = new string[0];
                    string[] str2 = new string[0];

                    if (isAnswer) newBorder = CreateBorderAnswer(str1, str2, index + 1);
                    else newBorder = CreateTitleBlock(index + 1);

                    borders.Add(newBorder);
                }
            }

            InterviewBody.Children.Clear();
            InterviewBody.RowDefinitions.Add(new RowDefinition());

            AddBorders(borders, 0);
        }

        private void AddBorders(List<Border> borders, int index)
        {
            for (int i = index; i < borders.Count; i++)
            {
                Grid gd = (Grid)borders[i].Child;

                gd.Tag = $"{i}";
                InterviewBody.Children.Add(borders[i]);

                Grid.SetRow(borders[i], i);
            }
            if (index == 1)
            {
                for (int i = index; i < borders.Count; i++)
                {
                    Grid gd = (Grid)borders[i].Child;
                    ComboBox cb = (ComboBox)gd.Children[1];

                    int d = cb.SelectedIndex;

                    cb.SelectedIndex = -1;
                    cb.SelectedIndex = d;
                }
            }
            isLoaded = true;
        }

        public void RemoveAnswer_Button_Click(object sender, RoutedEventArgs e)
        {
            Image button = (Image)sender;
            Border brd = (Border)button.Parent;
            Grid grid = (Grid)brd.Parent;

            int index = int.Parse(grid.Tag.ToString());

            int count = InterviewBody.Children.Count;

            List<Border> borders = new List<Border>();

            for (int i = 0; i < count; i++)
            {
                Border border;

                if (i != index)
                {
                    border = (Border)InterviewBody.Children[i];

                    borders.Add(border);
                }
            }

            InterviewBody.Children.Clear();
            InterviewBody.RowDefinitions.RemoveAt(index);
            questions.RemoveAt(index);

            for (int i = 0; i < borders.Count; i++)
            {
                Grid gd = (Grid)borders[i].Child;

                gd.Tag = $"{i}";
                InterviewBody.Children.Add(borders[i]);

                Grid.SetRow(borders[i], i);
            }
        }

        public void AddTitleBlock_Block_Click(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;

            AddNewBlock(false, img);
        }

        private async void SaveInterview_Button_Click(object sender, RoutedEventArgs e)
        {
            string name = questions[0].GetTitle.Text.Replace(" ", "");

            if (name != "")
            {
                JsonSerializerOptions options = new JsonSerializerOptions();

                List<Data> dataList = new List<Data>();

                List<List<Data>> bigJson = new List<List<Data>>();

                options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);

                string fileName = "user.json";

                bool flag = true;
                
                if (File.Exists(fileName) && File.ReadAllBytes(fileName).Length != 0) bigJson = JsonSerializer.Deserialize<List<List<Data>>>(File.ReadAllText(fileName, Encoding.Default), options);


                if (questions.Count <= 1) { flag = false; MessageBox.Show("Добавьте хотя бы один вопрос!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning); }
                else
                {
                    for (int i = 0; i < questions.Count; i++)
                    {
                        string quest = questions[i].Question_Text;
                        string title = questions[i].Title_Text;

                        if (quest == "" && title == "") { flag = false; MessageBox.Show("Не все поля заполнены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning); break; }
                    }
                    for (int i = 0; i < questions.Count; i++)
                    {
                        string quest = questions[i].Question_Text;
                        int index = questions[i].ComboBox_Index;

                        if (index == 5 || index == 6)
                        {
                            Grid LeftOptions = questions[i].Get_LeftList;
                            Grid RightOptions = questions[i].Get_RightList;

                            TextBox textBox1 = (TextBox)LeftOptions.Children[1];
                            TextBox textBox2 = (TextBox)RightOptions.Children[1];

                            if (textBox1.Text == "" || textBox2.Text == "") { flag = false; MessageBox.Show("Не все поля заполнены!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning); break; }
                        }
                    }
                    if (flag)
                    {
                        for (int i = 0; i < bigJson.Count; i++)
                        {
                            if (bigJson[i][0].Title_Text == name)
                            {
                                if (MessageBox.Show("Такой опрос уже существует. Заменить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                {
                                    bigJson.RemoveAt(i);

                                    string bigJSON = JsonSerializer.Serialize(bigJson, options);

                                    byte[] bt = Encoding.Default.GetBytes(bigJSON);

                                    File.WriteAllBytes(fileName, bt);
                                }
                                else { flag = false; break; }
                            }
                        }
                    }
                }

                if (flag)
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Create))
                    {
                        byte[] buffer;

                        List<string> optionsLeft = new List<string>();
                        List<string> optionsRight = new List<string>();

                        for (int i = 0; i < questions.Count; i++)
                        {
                            optionsLeft = new List<string>();
                            optionsRight = new List<string>();

                            int index = questions[i].ComboBox_Index;
                            string title = questions[i].Title_Text;
                            string desc = questions[i].Description_Text;
                            string quest = questions[i].Question_Text;

                            Grid LeftOptions = questions[i].Get_LeftList;
                            Grid RightOptions = questions[i].Get_RightList;

                            if (questions[i].Get_LeftList.Children.Count != 0 || questions[i].Get_RightList.Children.Count != 0)
                            {
                                for (int j = 1; j < questions[i].Get_LeftList.Children.Count; j += 2)
                                {
                                    TextBox text1 = (TextBox)LeftOptions.Children[j];
                                    if (text1.Text != "") optionsLeft.Add(text1.Text);
                                }
                                for (int j = 1; j < questions[i].Get_RightList.Children.Count; j += 2)
                                {
                                    TextBox text2 = (TextBox)RightOptions.Children[j];
                                    if (text2.Text != "") optionsRight.Add(text2.Text);
                                }
                            }

                            Data data = new Data(index, title, desc, quest, optionsLeft, optionsRight);

                            dataList.Add(data);
                        }

                        bigJson.Add(dataList);

                        string json = JsonSerializer.Serialize(bigJson, options);

                        buffer = Encoding.Default.GetBytes(json);

                        await fs.WriteAsync(buffer, 0, buffer.Length);

                    }
                }
            }
            else MessageBox.Show("Дайте название опроснику!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void ExitApp_Button_Click(object sender, RoutedEventArgs e)
        {
            main.IsEnabled = true;
            Close();
        }

        private void NewInterview_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearInterview();
            CreateMainBlock();
        }

        private void ClearInterview()
        {
            InterviewBody.Children.Clear();
            InterviewBody.RowDefinitions.Clear();

            questions = new List<Question>();
        }

        private void OpenInterview_Button_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;

            ListInterview listInterview = new ListInterview();
            listInterview.GetInterview(this);

            listInterview.ShowDialog();
        }

        public void GetNewInterview(List<Data> newInterview)
        {
            ClearInterview();

            Border mainBorder = CreateMainBlock(newInterview[0].Title_Text, newInterview[0].Description_Text);

            List<Border> borders = new List<Border>
            {
                mainBorder
            };

            for (int i = 1; i < newInterview.Count; i++)
            {
                string questionText = newInterview[i].Question_Text;
                int indexQuestion = newInterview[i].Question_Index;
                string desc = newInterview[i].Description_Text;
                string title = newInterview[i].Title_Text;

                string[] left = newInterview[i].LeftOptions.ToArray();
                string[] right = newInterview[i].RightOptions.ToArray();

                Border newBorder;

                InterviewBody.RowDefinitions.Add(new RowDefinition());

                if (indexQuestion != -1) newBorder = CreateBorderAnswer(left, right, i, questionText, indexQuestion);
                else newBorder = CreateTitleBlock(i, title, desc);

                borders.Add(newBorder);

            }
            isLoaded = false;

            AddBorders(borders, 1);
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            main.IsEnabled = true;
        }
    }
}
