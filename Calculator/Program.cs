namespace Calculator;

public abstract class Program
{
    public static void Main(string[] args)
    {
        const int players = 3;
        const int spikeStormsPerSkull = 15;
        const int damage = 12;
        const int debuffs = 5;
        const decimal coopLag = 0.3m;
        var boss = Bosses.PhayzeNormalT3;
        //var tower = Towers.MAD_OC;
        
        //var splitT1 = coopLag + Towers.FirstStrike.CalculateTimeForDamage(boss.GetSkullHp(players)) + boss.AnimationTime / 2;
        //var splitT2 = splitT1 + 1 + CalcFrames(10, 12, boss, 25, 1, 0) + Bosses.PhayzeNormalT1.ImmunityPerSkull;
        //var splitT3 = splitT2 + 1 + CalcFrames(10, 12, boss, 25, 1, 0) + Bosses.PhayzeNormalT1.ImmunityPerSkull;
        //var splitT4 = splitT3 + 1 + CalcFrames(10, 12, boss, 25, 1, 0) + Bosses.PhayzeNormalT1.ImmunityPerSkull + Bosses.PhayzeNormalT1.AnimationTime / 2;
        
        /*
        var splitT1 = tower.CalculateTimeForDamage(boss.GetSkullHp(players)) +
                      boss.AnimationTime / 2;
        var splitT2 = splitT1 + tower.CalculateTimeForDamage(boss.GetSkullHp(players)) +
                      boss.ImmunityPerSkull;
        var splitT3 = splitT2 + tower.CalculateTimeForDamage(boss.GetSkullHp(players)) +
                      boss.ImmunityPerSkull;
        var splitT4 = splitT3 + tower.CalculateTimeForDamage(boss.GetSkullHp(players)) +
                      boss.ImmunityPerSkull + boss.AnimationTime / 2;
        */

        var splitT1 = CalcFrames(damage, 24, boss, 15, spikeStormsPerSkull, debuffs, players: players) + boss.AnimationTime / 2;
        var splitT2 = splitT1 + CalcFrames(damage, 24, boss, 10, spikeStormsPerSkull, debuffs, players: players) + boss.ImmunityPerSkull;
        var splitT3 = splitT2 + CalcFrames(damage, 24, boss, 25, spikeStormsPerSkull, debuffs, players: players) + boss.ImmunityPerSkull;
        var splitT4 = splitT3 + CalcFrames(damage, 24, boss, 25, spikeStormsPerSkull, debuffs, players: players) + boss.ImmunityPerSkull + boss.AnimationTime / 2;
        
        Console.WriteLine(splitT1);
        Console.WriteLine(splitT2);
        Console.WriteLine(splitT3);
        Console.WriteLine(splitT4);
        //CalcFrames(5, 11, new Boss("Phayze-Normal-T1", 5000, 6, 4.216m, 3), 100, 2, 0);
    }

    static decimal CalcFrames(int dmg, int pierce, Boss boss, decimal percentageHit, int towers=1, int debuffs=0, int players=1)
    {
        var tower = new BtdTower("SpikeStorm", dmg + debuffs, 1000, 0);
        var damagePerAbility = tower.CalculateDamageInTime(0.1m) * 200 * (percentageHit / 100) * towers;
        const decimal frameTime = 0.0166M;
        var frames = 0;
        decimal dmgDealt = 0;
        var pierceUsed = 0;
        while (true)
        {
            dmgDealt += damagePerAbility;
            if (dmgDealt >= boss.GetSkullHp(players))
            {
                Console.WriteLine($"Required pierce: {pierceUsed + 1}");
                break;
            }

            frames++;
            pierceUsed++;
            if (pierceUsed == pierce)
            {
                Console.WriteLine("Not enough pierce!");
            }
        }

        var time = frames * frameTime;
        return time;
        //Console.WriteLine($"Kill time: {boss.CalculateMinTime() + time * (boss.Skulls + 1)} [MinTime: {boss.CalculateMinTime()}]");
    }
}