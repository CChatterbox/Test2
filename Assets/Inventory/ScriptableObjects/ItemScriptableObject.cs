using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Default, Weapon
}
public class ItemScriptableObject : ScriptableObject
{
   public string itemName;
   public int maxAmount;
   public GameObject itemPrefab;
   public Sprite icon;
   public ItemType itemType;
}
