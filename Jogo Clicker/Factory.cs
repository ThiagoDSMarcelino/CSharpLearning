public static class Factory
{
    public static double Coins { get; set; } = 0;
    public static void Click(Machine[] machines)
    {
        int coinsPerClick = 0;
        foreach (Machine machine in machines)
            coinsPerClick += machine.Gerate;
        Factory.Coins += 1 + coinsPerClick;
    }
}