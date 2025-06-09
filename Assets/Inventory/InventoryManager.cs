using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
[System.Serializable]
public class SlotData
{
    public string itemName;
    public int amount;
}

[System.Serializable]
public class InventoryData
{
    public List<SlotData> slots = new List<SlotData>();
}

public class InventoryManager : MonoBehaviour
{
    public GameObject uiPanel;
    public Transform inventoryPanel;
    public List <Slot> slots = new List<Slot>();
    public bool isOpened;

    public List<ItemScriptableObject> allItems;

    void Awake()
    {
        uiPanel.SetActive(true);
    }
    void Start()
    {   
        
        for(int i = 0; i < inventoryPanel.childCount; i++)
        {
            slots.Add(inventoryPanel.GetChild(i).GetComponent<Slot>());
        }
        LoadInventory();
         uiPanel.SetActive(false);
    }

   
    void Update()
    {
        
    }
    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach(Slot slot in slots)
        {
            if(slot.item == _item && (slot.amount + _amount) <= _item.maxAmount)
            {
                slot.amount += _amount;
                slot.itemAmountText.text = slot.amount.ToString();
                 SaveInventory();
                return;
            }
           
        }
        foreach(Slot slot in slots)
        {
            if(slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                
               
               if (slot.amount > 1)
                    {
                        slot.itemAmountText.text = slot.amount.ToString();
                    }
                    else
                    {
                        slot.itemAmountText.text = "";
                    }
                    SaveInventory();
                return;
            }
        }
    }
    public void InventoryOpen()
    {
         if(isOpened)
            {
              uiPanel.SetActive(false);  
            }
            else
            {
                uiPanel.SetActive(true);  
            }
            isOpened = !isOpened;
    }
    public void SaveInventory()
{
    InventoryData data = new InventoryData();

    foreach (Slot slot in slots)
    {
        if (!slot.isEmpty)
        {
            SlotData slotData = new SlotData();
            slotData.itemName = slot.item.itemName;
            slotData.amount = slot.amount;
            data.slots.Add(slotData);
        }
    }

    string json = JsonUtility.ToJson(data, true);
    string path = Path.Combine(Application.persistentDataPath, "inventory_save.json");
    File.WriteAllText(path, json);
    Debug.Log("Инвентарь сохранён в файл: " + path);
}
public ItemScriptableObject GetItemByName(string name)
    {
        foreach (ItemScriptableObject item in allItems)
        {
            if (item.itemName == name)
                return item;
        }

        Debug.LogWarning("Предмет с именем " + name + " не найден.");
        return null;
    }
public void LoadInventory()
{
    string path = Path.Combine(Application.persistentDataPath, "inventory_save.json");
    if (!File.Exists(path))
    {
        Debug.Log("Файл не найден. Инвентарь не загружен.");
        return;
    }

    string json = File.ReadAllText(path);
    InventoryData data = JsonUtility.FromJson<InventoryData>(json);

    ClearInventory();

    foreach (SlotData slotData in data.slots)
    {
        ItemScriptableObject item = GetItemByName(slotData.itemName);
        if (item != null)
        {
            AddItem(item, slotData.amount);
        }
    }

    Debug.Log("Инвентарь загружен.");
}
public void ClearInventory()
{
    foreach (Slot slot in slots)
    {
        slot.item = null;
        slot.amount = 0;
        slot.isEmpty = true;
        slot.iconGameObject.GetComponent<Image>().sprite = null;
        slot.iconGameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        slot.itemAmountText.text = "";
    }
}

}
