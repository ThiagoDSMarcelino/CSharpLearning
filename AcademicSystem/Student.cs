public class Student
{
    public string Name { get; private set; }
    public int CourseCode { get; private set; }
    public int Registration { get; private set; }
    private float grade;
    public float Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            if (value >= 0 && value <= 10)
                this.grade = value;
        }
    }
    public Student(string name, int registration, int courseCode)
    {
        this.Name = name;
        this.Registration = registration;
        this.CourseCode = courseCode;
    }
}