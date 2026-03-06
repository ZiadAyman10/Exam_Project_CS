using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Project.Answer_Model
{
   public enum EAnswers
    {
        True , False ,All
    }
    public class Answer : IComparable<Answer>
    {
        #region prop
        int id;
        string text;
        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; } 
        #endregion

        public Answer(int id, string text)
        {
            this.id = id;
            this.text = text;
        }
        public Answer( Answer ans)
        {
            this.id=ans.id;
            this.text = ans.text;
        }
        public static bool operator ==(Answer rs, Answer ls)
        {
            return rs.Equals(ls);
        }
        public static bool  operator !=( Answer rs,Answer ls)
        {
            return rs.Equals(ls);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Answer) return false; 
            if (object.ReferenceEquals(this, (Answer)obj)) return true;
            return ((Answer)obj).id == id && ((Answer)obj).text == text;
        }
        public override string ToString()
        {
            return $"Id:{this.Id} , Text:{this.Text}";
        }

        public int CompareTo(Answer? other)
        {
            if (other is null) return 1;
            if (this.id > other.id) return 1;
            if (id < other.id) return -1;
            else return 0;
        }
    }
}
