using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
   public ItemScriptableObject item;
   public int amount;
   public bool isEmpty = true;
   public GameObject iconGameObject;
   public TMP_Text itemAmountText;
   private InventoryManager inventoryManager;
    void Awake()
    {
        iconGameObject = transform.GetChild(0).gameObject;
        itemAmountText = transform.GetChild(1).GetComponent<TMP_Text>();
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

   
    public void SetIcon(Sprite icon)
    {
       iconGameObject.GetComponent<Image>().color = new Color(1,1,1,1);
       iconGameObject.GetComponent<Image>().sprite = icon;
    }
    
public void ClearSlot()
{
    if (!isEmpty)
    {
        if (amount > 1)
        {
            amount--;
            itemAmountText.text = amount.ToString();
        }
        else
        {
            item = null;
            amount = 0;
            isEmpty = true;
            iconGameObject.GetComponent<Image>().sprite = null;
            iconGameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            itemAmountText.text = "";
        }
    }
     inventoryManager.SaveInventory();
}
  

}
