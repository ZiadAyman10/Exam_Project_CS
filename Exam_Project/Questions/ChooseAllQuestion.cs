
using Exam_Project.Answer_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Project.Questions
{
    public class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string _header, string _body, int _marks, AnswerList ls, Answer _correctAnswer)
            : base(_header, _body, _marks, ls, _correctAnswer)   // pass original ls (not mutated)
        {
            AddAnswer(new Answer(-1, EAnswers.All.ToString()));
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return (studentAnswer.Equals(CorrectAnswer));
        }

        public override void Display()
        {
            ToString();
        }
    }
}
