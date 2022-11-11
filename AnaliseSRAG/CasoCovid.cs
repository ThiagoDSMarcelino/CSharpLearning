public class CasoCovid
{
    public int Age { get; set; }
    public bool IsDead { get; set; }
    public bool IsCovid { get; set; }
    public Vaccines Vaccine { get; set; } = Vaccines.Desconhecido;
    public byte NumberVacs { get; set; } = 0;
}

public enum Vaccines
{
    Coronavac,
    Astrazeneca,
    Pfizer,
    Sinovac,
    Janssen,
    India,
    Desconhecido
}