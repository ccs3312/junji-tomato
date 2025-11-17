using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotStateManager : MonoBehaviour
{
    BotBaseState currentstate;
    public BotIdle idlestate = new BotIdle();
    public BotChase chasestate = new BotChase();
    public int timer = 0;
    public GameObject player;
    public float speed;
    public int doornot;
    public Transform bot;
    public int[] coord = {1,0};
    public Collider2D botHitbox;
    public Collider2D botEyesight;
    public Door Door;
    public AudioSource spk;
    public Animator animator;
    //public AudioClip alert;


    private void Start()
    {
        //animator = GetComponent<Animator>();
        spk.PlayDelayed(3);
        spk.enabled = false;
        currentstate = idlestate;
        currentstate.EnterState(this);
        currentstate.player = player;
        currentstate.speed = speed;
        currentstate.doornot = doornot;
        currentstate.bot = bot;
        currentstate.coord = coord;
        currentstate.botHitbox = botHitbox;
        currentstate.botEyesight = botEyesight;
        currentstate.Door = Door;
        bot.position = new Vector2(210, 140);
        StartCoroutine(Timer());

    }
    private void Update()
    {
        currentstate.UpdateState(this);
        //animator.SetFloat("dir",currentstate.dir);
        //Debug.Log(currentstate.dir);
    }
    public void SwitchState(BotBaseState state)
    {
        currentstate=state;
        state.EnterState(this);
        currentstate.player = player;
        currentstate.speed = speed;
        currentstate.doornot = doornot;
        currentstate.bot = bot;
        currentstate.botHitbox = botHitbox;
        currentstate.botEyesight = botEyesight;
        currentstate.Door = Door;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("well shit");
        currentstate.Collided(this, other);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResetTimer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }

    /*private void FixedUpdate()
    {
        timer += 1;
    }*/
    public void ResetTimer()
    {
        timer = 0;
        Debug.Log("can somebody please fucking kill me");
    }
    public IEnumerator Timer()
    {
            yield return new WaitForSeconds(1);
            timer += 1;
    }
}
