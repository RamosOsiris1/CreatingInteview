﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

namespace Creating_Inteview
{
    public partial class SelectInterview : Window
    {
        private List<List<Data>> bigJson;
        private PassInterview passInterview;

        public MainWindow main;
        public SelectInterview()
        {
            InitializeComponent();
            LoadInterviews();
            ShowInterviews();
        }

        private void LoadInterviews()
        {
            string fileName = "user.json";

            if (File.ReadAllBytes(fileName).Length == 0) return;

            bigJson = new List<List<Data>>();

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);

            bigJson = JsonSerializer.Deserialize<List<List<Data>>>(File.ReadAllText(fileName, Encoding.Default), options);
        }

        private void ShowInterviews()
        {
            if (bigJson == null) return;

            List<Data> data;

            for (int i = 0; i < bigJson.Count; i++)
            {
                data = bigJson[i];
                SpawnInterviews(data[0].Title_Text, i);
            }
        }

        private void SpawnInterviews(string title, int index)
        {
            Button btn = new Button();

            btn.Content = title;
            btn.Tag = index;
            btn.Style = (Style)btn.FindResource("InterviewButton");
            btn.Click += OpenInterview_Button_Click;

            RowDefinition rowDefinition = new RowDefinition();
            rowDefinition.MinHeight = 40;
            rowDefinition.Height = GridLength.Auto;

            list.Children.Add(btn);

            list.RowDefinitions.Add(rowDefinition);

            Grid.SetRow(btn, list.RowDefinitions.Count - 1);
        }

        private void OpenInterview_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.Tag.ToString());

            passInterview = new PassInterview();
            passInterview.LoadInterview(bigJson[index]);

            passInterview.Show();
            passInterview.main = main;

            Close();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            main.IsEnabled= true;
        }
    }
}
