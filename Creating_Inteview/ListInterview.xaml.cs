using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Creating_Inteview
{
    /// <summary>
    /// Логика взаимодействия для ListInterview.xaml
    /// </summary>
    public partial class ListInterview : Window
    {
        List<List<Data>> bigJson;

        List<List<Data>> CopybigJson;

        private CreateInterview createInterview;

        public ListInterview()
        {
            InitializeComponent();

            ShowAllInterview();
        }
        private void ShowAllInterview()
        {
            bigJson = new List<List<Data>>();

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);

            string fileName = "E:/Users/zxc/Desktop/Новая папка (2)/user.json";

            if (File.ReadAllBytes(fileName).Length != 0)
            {
                bigJson = JsonSerializer.Deserialize<List<List<Data>>>(File.ReadAllText(fileName, Encoding.Default), options);
                CopybigJson = JsonSerializer.Deserialize<List<List<Data>>>(File.ReadAllText(fileName, Encoding.Default), options);
            }

            ShowButtons();

        }

        private void ShowButtons()
        {
            List<Data> data;

            for (int i = 0; i < bigJson.Count; i++)
            {
                data = bigJson[i];
                CreateButton(data[0].Title_Text, i);
            }
        }

        private void HideButtons()
        {
            list.Children.Clear();
            list.RowDefinitions.Clear();
        }

        private void CreateButton(string title, int index)
        {
            Image image = new Image();

            Button btn = new Button();
            btn.Content = title;
            btn.Tag = index;

            image.Style = (Style)image.FindResource("DeleteInterview");
            btn.Style = (Style)btn.FindResource("InterviewButton");

            image.MouseDown += DeleteInterview_Click;
            btn.Click += OpenInterview_Button_Click;

            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.MinHeight = 40;
            rowDefinition.Height = GridLength.Auto;

            list.Children.Add(btn);
            list.Children.Add(image);

            list.RowDefinitions.Add(rowDefinition);

            Grid.SetRow(btn, list.RowDefinitions.Count - 1);
            Grid.SetRow(image, list.RowDefinitions.Count - 1);
        }

        private void FindInterview_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Data> data;

            List<List<Data>> copy = new List<List<Data>>();

            bigJson = CopybigJson;

            if (field.Text != "")
            {
                for (int i = 0; i < bigJson.Count; i++)
                {
                    data = bigJson[i];

                    if (data[0].Title_Text.Contains(field.Text)) copy.Add(bigJson[i]);
                }

                bigJson = copy;

                HideButtons();
                ShowButtons();
            }
            else
            {
                HideButtons();
                ShowButtons();
            }
        }

        private void OpenInterview_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.Tag.ToString());

            createInterview.GetNewInterview(bigJson[index]);

            createInterview.IsEnabled= true;
            createInterview.Show();

            Close();
        }

        public void GetInterview(CreateInterview create)
        {
            createInterview = create;
        }

        private void Closed_Click(object sender, EventArgs e)
        {
            createInterview.IsEnabled = true;
        }

        private void DeleteInterview_Click(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;

            int index = list.Children.IndexOf(image);

            bigJson.RemoveAt(index - 1);

            HideButtons();
            ShowButtons();

            SaveFile();
        }


        async private void SaveFile()
        {
            string fileName = "E:/Users/zxc/Desktop/Новая папка (2)/user.json";

            if (bigJson.Count != 0)
            {
                JsonSerializerOptions options = new JsonSerializerOptions();

                options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);

                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    byte[] buffer;

                    string json = JsonSerializer.Serialize(bigJson, options);

                    buffer = Encoding.Default.GetBytes(json);

                    await fs.WriteAsync(buffer, 0, buffer.Length);
                }
            }
            else File.Create(fileName);
        }
    }
}
