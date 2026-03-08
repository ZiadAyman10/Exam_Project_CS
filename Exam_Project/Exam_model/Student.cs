namespace Exam_Project.Exam_model
{
    public class Student
    {
        string  name;
        int id;
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public Student(string _name, int _id)
        {
            this.Name = _name;
            this.Id = _id;
        }
        public override bool Equals(object? obj)
        {
            if((obj is Student s)&&(obj is not null)&&(this.GetType()==obj.GetType()))
            {
                return s.name.Equals(this.Name)&& s.Id.Equals(this.id);
            }
            return false;
        }

        public override string ToString()
        {
            return $"id : {this.id}, Name: {this.name}";
        }

        public void HandleExamStart(object sender, EventArgs e)
        {
            if (sender is Exam exam)
            {
                Console.WriteLine($"{Name} entered the exam of {exam.Subject.Name}");
            }
        }
    }
}