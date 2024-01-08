using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using static UnityEditor.Progress;


namespace Managers
{
    public class InventoryManager 
    {
        public Dictionary<string, Item> _inventory;
        public int _inventoryCount;
        public bool _inventoryOpend = false;

        private ItemSlotUI _slotUI;
        private InventoryUI _inventoryUI;

        public List<ItemSlotUI> itemSlots = new List<ItemSlotUI>();


        public InventoryManager()
        {
            _inventory = new Dictionary<string, Item>();
            _inventoryCount = 12;
        }


        public void AddItem(Item item)
        {
            string itemName = item.name;
            _inventory. TryAdd(itemName, item);

            if (_inventory.Count > _inventoryCount) _inventoryCount = _inventory.Count;
        }

        public void DelItem(Item item)
        {
            string itemName = item.name;
            _inventory.Remove(itemName);

            _inventoryCount = _inventory.Count < 12 ? 12 : _inventory.Count;
        }

        public void OpenInventory()
        {
            _inventoryUI = Main.UI.OpenPopup<InventoryUI>();
            _inventoryOpend = true;
        }

        public void CloseInventory()
        {
            _inventoryUI.CloseInventory();
        }
    }
}
