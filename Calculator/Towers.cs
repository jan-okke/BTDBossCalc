namespace Calculator;

public abstract class Towers
{
    public static BtdTower FirstStrike = new BtdTower("Sub-040-FirstStrike", 10000, 60, 0.63m);
    public static BtdTower MAD = new BtdTower("Dartling-150-MAD", 533, 0.4m, 0);
    public static BtdTower MAD_OC = new BtdTower("Dartling-150-MAD+Overclock", 533, 0.4m * 0.67m, 0);
}