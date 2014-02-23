namespace JConradOOPProject.GameObjects.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JConradOOPProject.GameObjects.Tools.Shields;
    using JConradOOPProject.GameObjects.Tools.Weapons;
    using JConradOOPProject.GameObjects.Tools.Skills;

    public class Shop
    {
        private List<Item> items;

        /// <summary>
        /// When the hero sells an item, it is added to the shop
        /// </summary>
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        /// <summary>
        /// When the hero buys an item from the shop, it is removed from the shop
        /// </summary>
        public void RemoveItem(string itemName)
        {
            Item itemToRemove = items.First(it => it.Name == itemName);
            items.Remove(itemToRemove);
        }

        /// <summary>
        /// The shop is populated with some predefined items at its initialization
        /// </summary>
        public Shop()
        {
            Console.WriteLine("Constructing shop");
            items = new List<Item>();

            //TODO: cenite na ajtymite da se syobrazqt s harakteristikite im!
            //TODO: write some valid descriptions!
            //TODO: remove the above comment !

            //stock shields
            items.Add(new ChainArmour("Chain Armour", 125));
            items.Last().Description = "TODO: add description";

            items.Add(new Shield("Shield", 95));
            items.Last().Description = "TODO: add description";

            items.Add(new Shield("Sweat Cloth", 85));
            items.Last().Description = "TODO: add description";

            //stock weapons
            items.Add(new Axe("Axe", 65));
            items.Last().Description = "TODO: add description";

            items.Add(new Chopper("Chopper", 100));
            items.Last().Description = "TODO: add description";

            items.Add(new Cutter("Cutter", 100));
            items.Last().Description = "TODO: add description";

            items.Add(new DoubleAxe("Double Axe", 100));
            items.Last().Description = "TODO: add description";

            items.Add(new Knife("Knifes", 100));
            items.Last().Description = "TODO: add description";

            //stock skills
            items.Add(new Attack("Attack", 100));
            items.Last().Description = "TODO: add description";

            items.Add(new Defence("Defence", 100));
            items.Last().Description = "TODO: add description";
        }

        //for debugging purposes
        public void PrintAllItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.Description);
            }
        }
    }
}
