using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactables1 : MonoBehaviour
{
    public GameObject item;
    //public Dialogue Dialogue;
    public Inventory Inventory;
    public string[] lines = { }; //{"character()expression()speech"}
    public string[] altlines = { }; //open attempt unsuccessful.txt
    public Vector2[] spawnpts;
    private bool started = false;
    private int i = 0; //
    public bool cancollect = false;
    public bool locked = true;
    public GameObject key = null;
    public float cursemeter = 0;
    public float bubbing = 0.3f;
    private float prayspd = 1f;
    public int phase = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        item.transform.position = new Vector2(85, -35);
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.CheckExisting(key) && started == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                item.transform.localScale = new Vector3(1-bubbing,1-bubbing, 1);
                cursemeter += prayspd;
                bubbing *= -1;
            }
        }
        if (cursemeter >= 100)
        {
            Debug.Log("burn baby burn");
            if (phase < 3)
            {
                cursemeter = 0;
                phase += 1;
                prayspd -= 0.3f;
                item.transform.position = spawnpts[Random.Range(0, spawnpts.Length)];
            }
            else
            {
                SceneManager.LoadScene(3);
                //Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cursemeter = 0;
            started = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        started = false;
    }
}
