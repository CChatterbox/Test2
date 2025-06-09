using UnityEngine;


public class ItemPickUp : MonoBehaviour
{
    private Item item;
    public InventoryManager inv;
    void Start()
    {
        item = GetComponent<Item>();
         inv = FindObjectOfType<InventoryManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player")) 

        { 
            Debug.Log("dfgdf");
          
            
                inv.AddItem(item.item, item.amount);
                Destroy(gameObject); 
            
        }
    }
}