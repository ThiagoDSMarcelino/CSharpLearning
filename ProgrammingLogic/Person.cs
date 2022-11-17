using System;

public struct Person
{
    public Person(string name, string password)
    {
        this.Name = name;
        this.BirthDate = DateTime.Now;
        this.Balance = 0;
        this.Password = password;
        this.cpf = "000.000.000-00";
    }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal Balance { get; set; }
    public string Password { get; set; }
    private long cpf;
    private string CPF
    {
        get
        {
            return cpf.ToString("000.000.000-00");
        }
        set
        {
            cpf = long.Parse(
                value.Replace(".", "")
                    .Replace("-", "")
            );
        }
    }
}