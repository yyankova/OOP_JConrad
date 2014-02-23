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

        public List<Item> Items
        {
            get
            {
                return items;
            }
            private set
            {
                Items = value;
            }
        }

        /// <summary>
        /// When the hero sells an item, it is added to the shop
        /// </summary>
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// When the hero buys an item from the shop, it is removed from the shop
        /// </summary>
        public void RemoveItemByName (string itemName)
        {
            Item itemToRemove = Items.First(it => it.Name == itemName);
            RemoveItem(itemToRemove);
        }

        public void RemoveItem (Item item)
        {
            Items.Remove(item);
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
            Items.Add(new ChainArmour("Chain Armour", 125));
            Items.Last().Description = "TODO: add description";

            Items.Add(new Shield("Shield", 95));
            Items.Last().Description = "TODO: add description";

            Items.Add(new Shield("Sweat Cloth", 85));
            Items.Last().Description = "TODO: add description";

            //stock weapons
            Items.Add(new Axe("Axe", 65));
            Items.Last().Description = "TODO: add description";

            Items.Add(new Chopper("Chopper", 100));
            Items.Last().Description = "TODO: add description";

            Items.Add(new Cutter("Cutter", 100));
            Items.Last().Description = "TODO: add description";

            Items.Add(new DoubleAxe("Double Axe", 100));
            Items.Last().Description = "TODO: add description";

            Items.Add(new Knife("Knifes", 100));
            Items.Last().Description = "TODO: add description";

            //stock skills
            Items.Add(new Attack("Attack", 100));
            Items.Last().Description = "TODO: add description";

            Items.Add(new Defence("Defense", 100));
            Items.Last().Description = "TODO: add description";
        }

        //for debugging purposes
        public void PrintAllItems()
        {
            Console.WriteLine("\nAll items in shop:");
            int cnt = 1;
            foreach (var item in Items)
            {
                Console.WriteLine("{0}: {1} - {2}", cnt++, item.Name, item.Description);
            }
        }
    }
}
