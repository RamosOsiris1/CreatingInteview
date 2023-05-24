using Creating_Inteview.questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для PassInterview.xaml
    /// </summary>
    public partial class PassInterview : Window
    {
        public PassInterview()
        {
            InitializeComponent();

            CreateMainBlock();
            CreateComboBoxQuestion();
            CreateShortQuestion();
            CreateLongQuestion();
            CreateOneVariantQuestion();
            CreateTimeQuestion();
            CreateCalendarQuestuion();
            CreateManyVariantQuestion();
        }


        private void CreateMainBlock()
        {
            MainBlock mainBlock = new MainBlock();

            AddBlock(mainBlock.border);
        }
        private void CreateComboBoxQuestion()
        {
            ComboBoxQuestion question = new ComboBoxQuestion();

            AddBlock(question.border);
        }
        private void CreateShortQuestion()
        {
            ShortQuestion question = new ShortQuestion();

            AddBlock(question.border);
        }
        private void CreateLongQuestion()
        {
            LongQuestion question = new LongQuestion();

            AddBlock(question.border);
        }
        private void CreateOneVariantQuestion()
        {
            OneVariantQuestion question = new OneVariantQuestion();
            question.AddVariant(5);

            AddBlock(question.border);
        }
        private void CreateTimeQuestion() // проверку тайма сделать
        {
            TimeQuestion question = new TimeQuestion();

            AddBlock(question.border);
        }
        private void CreateCalendarQuestuion()
        {
            CalendarQuestion question = new CalendarQuestion();

            AddBlock(question.border);
        }
        private void CreateManyVariantQuestion()
        {
            ManyVariantQuestion question = new ManyVariantQuestion();
            question.AddVariant(5);

            AddBlock(question.border);
        }
        private void CreateGridOneVariantQuestion()
        {
            
        }
        private void AddBlock(Border block)
        {
            InterviewBody.Children.Add(block);
            InterviewBody.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(block, InterviewBody.RowDefinitions.Count - 1);
        }
    }
}
