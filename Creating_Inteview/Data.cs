using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Creating_Inteview
{
    public class Data
    {
        public int Question_Index { get; set; }
        public string Title_Text { get; set; }
        public string Description_Text { get; set; }
        public string Question_Text { get; set; }

        public List<String> LeftOptions { get; set; }
        public List<String> RightOptions { get; set; }

        [JsonConstructor]
        public Data()
        { 
        }

        public Data(int index, string text, string desc, string question, List<string> leftoptions, List<string> rigthoptions)
        {
            Question_Index = index;
            Title_Text = text;
            Description_Text = desc;
            Question_Text = question;
            LeftOptions = leftoptions;
            RightOptions = rigthoptions;
        }
    }
}
