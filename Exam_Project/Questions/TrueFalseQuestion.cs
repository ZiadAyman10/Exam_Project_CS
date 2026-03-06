using Exam_Project.Answer_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Project.Questions
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string _header, string _body, int _marks, Answer _correctAnswer) 
            : base( _header,  _body,  _marks, new AnswerList(new List<Answer> { new(1, "True"), new(2, "False") }),  _correctAnswer)
        {
            
        }
        public override bool CheckAnswer(Answer studentAnswer)
        {
            return studentAnswer.Text.Equals(CorrectAnswer.Text);
        }

        public override void Display()
        {
            ToString();
        }
    }
}
