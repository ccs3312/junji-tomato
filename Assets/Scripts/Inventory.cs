using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory;
    public Image[] slots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItem(GameObject item)
    {
        inventory.Add(item);
        UpdateInventory();
    }
    public void RemoveItem(GameObject item)
    {
        inventory.Remove(item);
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        for(int i = 0; i<inventory.Count; i++)
        {
            slots[i].color = Color.white;
            slots[i].sprite = inventory[i].GetComponent<SpriteRenderer>().sprite; 
        }
        for (int i = inventory.Count; i<9 ; i++)
        {
            slots[i].color = Color.clear;
        }
    }

    public bool CheckExisting(GameObject item)
    {
        return inventory.Contains(item);
    }
}
