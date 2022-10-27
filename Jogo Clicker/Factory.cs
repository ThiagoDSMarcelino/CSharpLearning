public static class Factory
{
    public static double Coins { get; set; } = 0;
    public static double CoinsPerClick { get; private set; } = 1;
    public static void Click() => Factory.Coins += Factory.CoinsPerClick;
    public static void Update(Machine[] machines)
    {
        int coinsPerClick = 1;
        foreach (Machine machine in machines)
            coinsPerClick += machine.Gerate;
        Factory.CoinsPerClick = coinsPerClick;
    }
}