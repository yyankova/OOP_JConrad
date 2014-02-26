namespace JConradOOPProject.GameObjects.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using JConradOOPProject;
    using JConradOOPProject.GameObjects.Tools;
    using JConradOOPProject.GameObjects.Tools.Shields;
    using JConradOOPProject.GameObjects.Tools.Skills;
    using JConradOOPProject.GameObjects.Tools.Weapons;

    public partial class Lumberjack
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
