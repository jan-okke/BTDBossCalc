namespace Calculator;

public abstract class Program
{
    public static void Main(string[] args)
    {
        CalcFrames(5, 11, new Boss("Phayze-Normal-T1", 5000, 6, 4.216m, 3), 100, 2, 0);
    }

    static void CalcFrames(int dmg, int pierce, Boss boss, decimal percentageHit, int towers=1, int debuffs=0)
    {
        var tower = new BtdTower("SpikeStorm", dmg + debuffs, 1000, 0);
        var damagePerAbility = tower.CalculateDamageInTime(0.1m) * 200 * (percentageHit / 100);
        const decimal frameTime = 0.0166M;
        var frames = 0;
        decimal dmgDealt = 0;
        var pierceUsed = 0;
        while (true)
        {
            dmgDealt += damagePerAbility;
            if (dmgDealt >= boss.SkullHp)
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
        
        Console.WriteLine($"Kill time: {boss.CalculateMinTime() + time * (boss.Skulls + 1)} [MinTime: {boss.CalculateMinTime()}]");
    }
}