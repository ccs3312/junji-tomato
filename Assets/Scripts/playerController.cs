using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //public Rigidbody2D rb;
    public float spd;
    public float spdmult;
    public int[] coord = { 1, 0 }; //floor,room : stairs and hallways are floor,0
    private bool doorcoll = false;
    public Animator animator;
    public Stamina Stamina;
    Door Door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb.bodyType = RigidbodyType2D.Kinematic;
        animator = GetComponent<Animator>();
        StartCoroutine(DoorStep());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Stamina.stamina >= 0f)
        {
            spdmult = 2f;
            animator.SetBool("running", true);
            Stamina.stamina -= 50f*Time.deltaTime;
        }
        else
        {
            spdmult = 1f;
            animator.SetBool("running", false);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + spd * spdmult * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - spd * spdmult * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - spd * spdmult * Time.deltaTime, transform.position.y);
            animator.SetInteger("dir", -1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + spd * spdmult * Time.deltaTime, transform.position.y);
            animator.SetInteger("dir", 1);
        }
        if (Input.anyKey)
        {
            animator.SetBool("stand",false);
        }
        else
        {
            animator.SetBool("stand", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Door")&&doorcoll == false)
        {
            Door = collision.gameObject.GetComponent<Door>();
            doorcoll = true;
            //StartCoroutine(DoorStep());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(doorcoll == true)
        {
            doorcoll = false;
            //StopCoroutine(DoorStep());
        }
        //doorcoll = false;
    }
    private IEnumerator DoorStep()
    {
        while (true)
        {
            //Debug.Log("AAAAAAAAA");
            while (doorcoll == true)
            {
                //Debug.Log("the fuck isnt working");

                /*if ()
                {*/
                if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E)))
                {
                    Door.OpenDoor(0, "you");
                    yield return new WaitForSeconds(0.2f);
                    //yield break;
                }
                else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.E))
                {
                    Door.OpenDoor(1, "you");
                    yield return new WaitForSeconds(0.2f);
                    //yield break;
                }
                //}
                yield return null;
            }
            yield return null;
        }
    }
}
