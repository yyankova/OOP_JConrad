namespace JConradOOPProject.GameObjects.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            items = new List<Item>();

            //stock skills
            //TODO: provide some meaningful names and descriptions
            Items.Add(new Skill(8, "Some skill...", 100));
            Items.Last().Description = "TODO: add description";

            Items.Add(new Skill(9, "Another skill...", 100));
            Items.Last().Description = "TODO: add description";
        }


    }
}
