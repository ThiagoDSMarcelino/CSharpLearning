using System;

public class CasoCovid
{
    public int CLASSI_FIN { get; private set; }
    public int VACINA_COV { get; private set; }
    public int EVOLUCAO { get; private set; }
    public string FAB_COV_1 { get; private set; }
    public string FAB_COV_2 { get; private set; }
    public string FAB_COVREF { get; private set; }
    public void SetValues(string propTarget, string value)
    {
        switch (propTarget)
        {
            case nameof(this.CLASSI_FIN):
                if (int.TryParse(value, out int _))
                    this.CLASSI_FIN = int.Parse(value);
                break;

            case nameof(this.VACINA_COV):
                if (int.TryParse(value, out int _))
                    this.VACINA_COV = int.Parse(value);
                break;

            case nameof(this.EVOLUCAO):
                if (int.TryParse(value, out int _))
                    this.EVOLUCAO = int.Parse(value);
                break;

            case nameof(this.FAB_COV_1):
                if (value != "")
                    this.FAB_COV_1 = value;
                break;

            case nameof(this.FAB_COV_2):
                if (value != "")
                    this.FAB_COV_2 = value;
                break;

            case nameof(this.FAB_COVREF):
                if (value != "")
                    this.FAB_COVREF = value;
                break;
        }
    }
}