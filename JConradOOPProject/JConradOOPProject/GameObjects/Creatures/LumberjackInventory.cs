namespace JConradOOPProject.GameObjects.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JConradOOPProject;
    using JConradOOPProject.GameObjects.Tools;
    using JConradOOPProject.GameObjects.Tools.Shields;
    using JConradOOPProject.GameObjects.Tools.Skills;
    using JConradOOPProject.GameObjects.Tools.Weapons;

    partial class Lumberjack
    {
        private List<Item> Inventory
        {
            get
            {
                return Shields.Concat<Item>(Weapons).Concat(Skills).ToList();
            }
        }
        /// <summary>
        /// Equip with weapon/shield/skill from the inventory
        /// </summary>
        public void EquipByNameAndType(string equipmentName, EquipmentType equipmentType, int slot = 0)
        {
            if (slot < 0 || slot > 2)
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid slot {0}", slot));
            }
            //find this equipment in the inventory
            try
            {
                Item itemToEquip = Inventory.First(it => it.Name == equipmentName);
                CheckItemType(itemToEquip, equipmentType);
                Equip(itemToEquip, slot);
            }
            catch
            {
                throw new ArgumentOutOfRangeException(string.Format("Item {0} not found in inventory", equipmentName));
            }
        }

        public void Equip(Item item, int slot)
        {
            if (item is Weapon)
            {
                if (CurrentWeapon != null)
                {
                    Weapons.Add(CurrentWeapon);
                }
                CurrentWeapon = (Weapon)item;
                Weapons.Remove((Weapon)item);
            }
            else if (item is Shield)
            {
                if (CurrentShield != null)
                {
                    Shields.Add(CurrentShield);
                }
                CurrentShield = (Shield)item;
                Shields.Remove((Shield)item);
            }
            else if (item is Skill)
            {
                if (CurrentSkills[slot] != null)
                {
                    Skills.Add(CurrentSkills[slot]);
                }
                CurrentSkills[slot] = (Skill)item;
                Skills.Remove((Skill)item);
            }
        }

        /// <summary>
        /// Buy a weapon/shield/skill from the shop
        /// </summary>
        public void BuyByNameAndType(Shop shop, string equipmentName, EquipmentType equipmentType)
        {
            //find this equipment in the shop
            try
            {
                Item itemToBuy = shop.Items.First(it => it.Name == equipmentName);
                CheckItemType(itemToBuy, equipmentType);

                if (itemToBuy.Price > GoldAmount)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Not enough gold to buy {0}", equipmentName));
                }
                BuyItem(shop, itemToBuy);
            }
            catch (System.InvalidOperationException)
            {
                throw new ArgumentOutOfRangeException(string.Format("Item {0} not found in inventory", equipmentName));
            }
        }

        public void BuyItem(Shop shop, Item item)
        {
            if (item is Weapon)
            {
                Weapons.Add((Weapon)item);
            }
            else if (item is Shield)
            {
                Shields.Add((Shield)item);
            }
            else if (item is Skill)
            {
                Skills.Add((Skill)item);
            }

            GoldAmount -= (int)item.Price;
            shop.RemoveItem(item);
        }

        /// <summary>
        /// Sell a weapon or shiled for 1/2 of its price
        /// </summary>
        public void Sell()
        {

        }

        /// <summary>
        /// This is the default equipment which is available 
        /// to our hero at the start of the game
        /// </summary>
        public void SetDefaultEquipment()
        {
            this.Weapons = new List<Weapon>();
            this.Shields = new List<Shield>();
            this.Skills = new List<Skill>();
            this.CurrentSkills = new List<Skill>();
            this.CurrentSkills.Add(null);
            this.CurrentSkills.Add(null);
            this.CurrentSkills.Add(null);
        }

        //for debugging purposes
        public void PrintInventory()
        {
            Console.WriteLine("\nAvailable items in inventory: ");
            foreach (var item in Inventory)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.Description);
            }
        }

        //for debugging purposes
        public void PrintEquipment()
        {
            Console.WriteLine("\nCurrent Equipment: ");
            if (CurrentWeapon != null) Console.WriteLine("Weapon: {0}", CurrentWeapon.Name);
            if (CurrentShield != null) Console.WriteLine("Shield: {0}", CurrentShield.Name);
            for (int i = 0; i < CurrentSkills.Count; i++)
            {
                if (CurrentSkills[i] != null) Console.WriteLine("Skill{0}: {1}", i + 1, CurrentSkills[i].Name);
            }
        }

        private void CheckItemType(Item item, EquipmentType type)
        {
            if ((item is Weapon && type != EquipmentType.Weapon) ||
                (item is Shield && type != EquipmentType.Shield) ||
                (item is Skill && type != EquipmentType.Skill))
            {
                //item found by name but type does not match
                throw new ArgumentOutOfRangeException(string.Format("Item {0} not found in inventory", item.Name));
            }
        }
    }
}
