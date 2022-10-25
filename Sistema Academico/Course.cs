public class Course
{
    public int Code { get; private set; }
    public string Name { get; private set; }
    public int Workload { get; private set; }
    public Course(string name, int code, int workload)
    {
        this.Name = name;
        this.Code = code;
        this.Workload = workload;
    }
}