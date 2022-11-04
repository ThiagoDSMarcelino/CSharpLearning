using System;
using System.Collections.Generic;

var df = "Data/LAB_PR_COV.csv"
    .Open()
    .Skip(1);


List<string[]> allVac = new List<string[]>();
allVac.Add(new string[] { "CORONAVAC", "CAR", "CO", "CRO" });
allVac.Add(new string[] { "BUTANTAN", "BU", "BT", "BI", "TANTAN" });
allVac.Add(new string[] { "ASTRAZENECA", "AZ", "AS", "ATRA" });
allVac.Add(new string[] { "FIOCRUZ", "FI", "CRUZ" });
allVac.Add(new string[] { "PFIZER", "PHI", "PF", "FI", "PZ", "PI", "FAI", "FHI", "PLI", "PTI", "PHY", "FEI", "PAI", "PRI" });
allVac.Add(new string[] { "OXFORD", "OX", "0X", "ORF", "ORO", "OSF", "OKF", "EXF" });
allVac.Add(new string[] { "SINOVAC", "SIN", "SIN" });
allVac.Add(new string[] { "OSWALDO", "OSVALDO" });
allVac.Add(new string[] { "JANSSEN", "JANS", "JAN", "JENS", "JONS", "JHAN", "JONH", "JOHS", "JOHN", "JHON", "JAHN", "JAHS" });
allVac.Add(new string[] { "INDIA" });

df.FazTudo(allVac);