var df = "Data/LAB_PR_COV.csv"
    .Open()
    .Skip(1);


var coronavac = df.Find("CORONAVAC");

coronavac.Split();