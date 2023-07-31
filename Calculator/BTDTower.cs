namespace Calculator;

public class BtdTower
{
    public string Name { get; set; }
    private int Damage { get; set; }
    private decimal AttackCooldown { get; set; }
    private decimal InitialTimeBeforeAttack { get; set; }

    public int CalculateDamageInTime(decimal seconds)
    {
        decimal time = 0;
        var damage = 0;
        while (time <= seconds)
        {
            if (time < InitialTimeBeforeAttack)
            {
                time += InitialTimeBeforeAttack;
                if (time > seconds)
                {
                    return 0;
                }
            }
            damage += Damage;
            time += AttackCooldown;
        }

        return damage;
    }

    public decimal CalculateTimeForDamage(decimal damageToDeal)
    {
        var time = InitialTimeBeforeAttack;
        var damage = 0;

        while (damage < damageToDeal)
        {
            damage += Damage;
            if (damage < damageToDeal)
            {
                time += AttackCooldown;
            }
        }
        
        return time;
    }

    public BtdTower(string name, int damage, decimal cooldown, decimal initialTimeBeforeAttack)
    {
        Name = name;
        Damage = damage;
        AttackCooldown = cooldown;
        InitialTimeBeforeAttack = initialTimeBeforeAttack;
    }
}