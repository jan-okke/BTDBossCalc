namespace Calculator;

public class Boss
{
    public string Name { get; set; }
    public decimal SkullHp { get; set; }
    public decimal AnimationTime { get; set; }
    public decimal ImmunityPerSkull { get; set; }
    public int Skulls { get; set; }

    public decimal CalculateMinTime()
    {
        return AnimationTime + ImmunityPerSkull * Skulls;
    }

    public decimal CalculateTotalHp()
    {
        return SkullHp * (Skulls + 1);
    }

    public decimal CalculateKillTime(BtdTower tower, int numTowers = 1)
    {
        var timePerSkull = tower.CalculateTimeForDamage(SkullHp / numTowers);
        return CalculateMinTime() + timePerSkull * (Skulls + 1);
    }

    public int GetSkullHp(int players, decimal mod = 1)
    {
        return (int)(SkullHp * (0.8m + (0.2m * players)) * mod);
    }

    public Boss(string name, decimal skullHp, decimal animationTime, decimal immunityPerSkull, int skulls)
    {
        Name = name;
        SkullHp = skullHp;
        AnimationTime = animationTime;
        ImmunityPerSkull = immunityPerSkull;
        Skulls = skulls;
    }
}