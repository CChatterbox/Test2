using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIRaycast : MonoBehaviour
{
    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;
    public GameObject clearButton;
    private Slot selectedSlot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            PointerEventData pointerData = new PointerEventData(eventSystem);
            pointerData.position = Input.mousePosition;

           
            List<RaycastResult> hits = new List<RaycastResult>();
            graphicRaycaster.Raycast(pointerData, hits);

            
            foreach (RaycastResult hit in hits)
            {
                if (hit.gameObject.CompareTag("Slot"))
                {
                  
                  selectedSlot = hit.gameObject.GetComponent<Slot>();
                  clearButton.SetActive(true);
                    
                }
            }
        }
    }

    public void OnDeleteButtonClick()
    {
        if (selectedSlot != null)
        {
            selectedSlot.ClearSlot();
            clearButton.SetActive(false);
        }
    }
}