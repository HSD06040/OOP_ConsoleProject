using OOPConsoleProject.Managers;
using OOPConsoleProject.Util;

public enum Type
{
    Normal, Fire, Water, Grass
}

namespace OOPConsoleProject.PokemonData
{
    public class Stat
    {
        private int hp;
        private int damage;
        private int defense;
        private int speed;
        private string name;
        public int level { get; private set; }
        public int curHP { get; private set; }
        public int curEXP { get; private set; }
        public Type type { get; private set; }

        public bool isAlive { get; private set; } = true;

        public Stat(string name,Type type ,int hp, int damage, int defense, int speed)
        {
            this.hp = hp;
            this.damage = damage;
            this.defense = defense;
            this.speed = speed;
            this.name = name;
            this.type = type;

            curHP = HP();
        }

        public void DoDamage(Stat enemyStat, Skill mySkill)
        {
            DamageCalculator.TotalDamageCalculator(this, mySkill, enemyStat);
        }

        public void DecreaseHealth(int amount, bool crit)
        {
            curHP -= amount;

            Console.WriteLine(StringUtil.KoreanParticle($"{name,6}은/는 {amount,3} 만큼의 데미지를 입었다!\n"));

            if(crit)
                Console.WriteLine("급소에 맞았다!");

            if (curHP <= 0)
            {
                Die();
            }
        }
        public void IncreaseHealth(int amount)
        {
            curHP += amount;

            Console.WriteLine(StringUtil.KoreanParticle($"{name,6}은/는 {amount,3} 만큼의 체력을 회복했다!\n"));

            if (curHP > HP())
            {
                curHP = HP();
            }
        }

        public void Die()
        {
            Console.WriteLine(StringUtil.KoreanParticle($"{name,3}은/는 쓰러졌다.\n"));
            isAlive = false;
        }

        public int DropEXP()
        {
            Random random = new Random();

            return random.Next(150, 250) * level / 5;
        }

        public void GetEXP(int amount)
        {
            curEXP += amount;
            
            Console.WriteLine(StringUtil.KoreanParticle($"{name}은/는 {amount}만큼의 경험치를 획득했다!\n"));

            while (curEXP >= PokeManager.Instance.exp[level])
            {
                curEXP -= PokeManager.Instance.exp[level];
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Console.WriteLine(StringUtil.KoreanParticle($"{name}은/는 {level}에서 {level+1}로 레벨업 하였다!\n"));
            level++;
        }

        public void SetLevel(int level)
        {
            this.level = level;
            curHP = HP();
        }
        #region Stat
        public int HP()
        {
            return (2 * hp + 31) * level / 100 + level + 10;
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
            return (2 * stat + 31) * level / 100 + 5;
        }

        public void PrintStat()
        {
            Console.WriteLine($"레벨 : {level}, 체력 : {hp}, 공격력 : {damage}, 방어력 : {defense}, 스피드 : {speed}");
        }
    }
}
