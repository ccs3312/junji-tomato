using UnityEngine;

public class Interactables : MonoBehaviour
{
    public Dialogue Dialogue;
    public string[] lines = { }; //{"character()expression()speech"}
    private bool started = false;
    private int i = 0; //
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Dialogue = GameObject.Find(tag = "dbox").GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Dialogue.gameObject.SetActive(true);
                Dialogue.StartDialogue(lines);
                //started = true;
            }
            
        }
    }
}
