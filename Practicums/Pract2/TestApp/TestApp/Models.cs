using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
        public class Question
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string[] Options { get; set; } = new string[4];
            public int CorrectOption { get; set; }
        }

        public class UserResult
        {
            public string FullName { get; set; }
            public DateTime TestDate { get; set; }
            public int Score { get; set; }
            public int TimeSpentSeconds { get; set; }
        }

}
