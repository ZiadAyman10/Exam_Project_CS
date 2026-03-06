using System;
using System.Collections.Generic;
using System.Text;

using Exam_Project.Answer_Model;

namespace Exam_Project.Questions
{
    
    public class ChooseOneQuestion(string _header, string _body, int _marks, AnswerList ls, Answer _correctAnswer) 
        : Question(_header, _body, _marks,ls , _correctAnswer)
    {
        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Equals(studentAnswer);
        }

        public override void Display()
        {
            ToString();
        }
    }
}
