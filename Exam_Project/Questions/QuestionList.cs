using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Project.Questions
{
    public  class QuestionList : List<Question>
    {

        public  string FileName { get; init; }
        public QuestionList(string fileName)
        {
            FileName = fileName;
        }

        public new void Add(Question q)
        {
            base.Add(q);
            //add 
            using (StreamWriter sw = new StreamWriter($"{this.FileName}.txt", append: true))
            {

                    sw.WriteLine(q);
                    sw.WriteLine("======================");
                
            }

            #region read
            //// Read and show each line from the file.
            //string line = "";
            //using (StreamReader sr = new StreamReader("CDriveDirs.txt"))
            //{
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //} 
            #endregion

        }

    }
}
