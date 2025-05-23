using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Character
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; } = new();
        public List<string> Deeds { get; set; } = new();
        public List<string> MagicalAbilities { get; set; } = new();

        public override string ToString()
        {
            return $"Name: {Name}\nHeight: {Height}\nBuild: {Build}\nHair Color: {HairColor}\nEye Color: {EyeColor}\nClothing: {Clothing}\nInventory: {string.Join(", ", Inventory)}\nDeeds: {string.Join(", ", Deeds)}\nMagical Abilities: {string.Join(", ", MagicalAbilities)}\n";
        }
    }

    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetHeight(string height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder AddToInventory(string item);
        ICharacterBuilder AddDeed(string deed);
        ICharacterBuilder AddMagicalAbility(string ability);
        Character Build();
    }

    public class HeroBuilder : ICharacterBuilder
    {
        private Character _hero = new();

        public ICharacterBuilder SetName(string name) { _hero.Name = name; return this; }
        public ICharacterBuilder SetHeight(string height) { _hero.Height = height; return this; }
        public ICharacterBuilder SetBuild(string build) { _hero.Build = build; return this; }
        public ICharacterBuilder SetHairColor(string color) { _hero.HairColor = color; return this; }
        public ICharacterBuilder SetEyeColor(string color) { _hero.EyeColor = color; return this; }
        public ICharacterBuilder SetClothing(string clothing) { _hero.Clothing = clothing; return this; }
        public ICharacterBuilder AddToInventory(string item) { _hero.Inventory.Add(item); return this; }
        public ICharacterBuilder AddDeed(string deed) { _hero.Deeds.Add("Good: " + deed); return this; }
        public ICharacterBuilder AddMagicalAbility(string ability) { _hero.MagicalAbilities.Add(ability); return this; }

        public Character Build() => _hero;
    }

    public class EnemyBuilder : ICharacterBuilder
    {
        private Character _enemy = new();

        public ICharacterBuilder SetName(string name) { _enemy.Name = name; return this; }
        public ICharacterBuilder SetHeight(string height) { _enemy.Height = height; return this; }
        public ICharacterBuilder SetBuild(string build) { _enemy.Build = build; return this; }
        public ICharacterBuilder SetHairColor(string color) { _enemy.HairColor = color; return this; }
        public ICharacterBuilder SetEyeColor(string color) { _enemy.EyeColor = color; return this; }
        public ICharacterBuilder SetClothing(string clothing) { _enemy.Clothing = clothing; return this; }
        public ICharacterBuilder AddToInventory(string item) { _enemy.Inventory.Add(item); return this; }
        public ICharacterBuilder AddDeed(string deed) { _enemy.Deeds.Add("Evil: " + deed); return this; }
        public ICharacterBuilder AddMagicalAbility(string ability) { _enemy.MagicalAbilities.Add(ability); return this; }

        public Character Build() => _enemy;
    }

    public class CharacterDirector
    {
        public Character ConstructHero(ICharacterBuilder builder)
        {
            return builder
                .SetName("Avalon")
                .SetHeight("170 cm")
                .SetBuild("Athletic")
                .SetHairColor("Blonde")
                .SetEyeColor("Blue")
                .SetClothing("Armor of Light")
                .AddToInventory("Sword of Justice")
                .AddToInventory("Healing Potion")
                .AddMagicalAbility("Lightning attack")
                .AddMagicalAbility("Healing Light")
                .AddDeed("Saved the village")
                .AddDeed("Defeated the dragon")
                .AddDeed("Defeated the wizard")
                .Build();
        }

        public Character ConstructEnemy(ICharacterBuilder builder)
        {
            return builder
                .SetName("Dark wizard")
                .SetHeight("195 cm")
                .SetBuild("Muscular")
                .SetHairColor("Black")
                .SetEyeColor("Blood red")
                .SetClothing("Armor of death")
                .AddToInventory("Cursed Amulet")
                .AddToInventory("Grimoire of the force")
                .AddMagicalAbility("Breath of hellfire")
                .AddMagicalAbility("Creating shadows")
                .AddDeed("Burned the village")
                .AddDeed("Destroyed a unit of royal wizards")
                .Build();
        }
    }

    class Program
    {
        static void Main()
        {
            static void WriteLineCharacter(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            var director = new CharacterDirector();

            ICharacterBuilder heroBuilder = new HeroBuilder();
            Character hero = director.ConstructHero(heroBuilder);
            WriteLineCharacter("Hero:");
            Console.WriteLine(hero);

            ICharacterBuilder enemyBuilder = new EnemyBuilder();
            Character enemy = director.ConstructEnemy(enemyBuilder);
            WriteLineCharacter("Enemy:");
            Console.WriteLine(enemy);
        }
    }

}
