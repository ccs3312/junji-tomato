using Unity.VisualScripting;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public GameObject item;
    public Dialogue Dialogue;
    public Inventory Inventory;
    public string[] lines = { }; //{"character()expression()speech"}
    private bool started = false;
    private int i = 0; //
    public bool cancollect = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Dialogue = GameObject.Find(tag = "dbox").GetComponent<Dialogue>();
        if(item == null)
        {
            item = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Dialogue.gameObject.SetActive(true);
                Dialogue.StartDialogue(lines);
                if(cancollect == true)
                {
                    Inventory.AddItem(item);
                    Destroy(gameObject);
                }
                //started = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
