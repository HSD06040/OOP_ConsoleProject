public enum Type
{
    Normal, Fire, Water, Grass
}

namespace OOPConsoleProject
{
    public class Stat
    {
        private int Hp;
        private int damage;
        private int defense;
        private int speed;
        public int level { get; private set; }
        public int curHP { get; private set; }
        public int curEXP { get; private set; }
        public Type type { get; private set; }
        public Stat(int hp, int damage, int defense, int speed)
        {
            this.Hp = hp;
            this.damage = damage;
            this.defense = defense;
            this.speed = speed;

            curEXP = HP();
        }

        public void DoDamage(Stat enemyStat, Skill mySkill)
        {
            DamageCalculator.TotalDamageCalculator(this, mySkill, enemyStat);
        }

        public void DecreaseHealth(int amount)
        {
            curHP -= amount;

            if (curHP <= 0)
            {
                Die();
            }
        }
        public void IncreaseHealth(int amount)
        {
            curHP += amount;

            if (curHP > HP())
            {
                curHP = HP();
            }
        }

        public void Die()
        {

        }

        public int DropEXP()
        {
            Random random = new Random();

            return random.Next(150, 250) * level / 5;
        }

        public void GetEXP(int amount)
        {
            curEXP += amount;

            while (curEXP >= PokeManager.Instance.exp[level])
            {
                curEXP -= PokeManager.Instance.exp[level];
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
        }

        public void SetLevel(int level) => this.level = level;

        #region Stat
        public int HP()
        {
            return (((2 * Hp + 31) * level) / 100) + level + 10;
        }

        public int Damage()
        {
            return AnotherStat(damage);
        }
        public int Defense()
        {
            return AnotherStat(defense);
        }
        public int Speed()
        {
            return AnotherStat(speed);
        }
        #endregion

        public int AnotherStat(int stat)
        {
            return (((2 * stat + 31) * level) / 100) + 5;
        }
    }
}
