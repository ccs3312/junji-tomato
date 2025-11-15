using System.Collections;
using UnityEngine;

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


    private void Start()
    {
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
        bot.position = new Vector2(0, -4);

    }
    private void Update()
    {
        currentstate.UpdateState(this);
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
        currentstate.Collided(other);
    }

    /*private void FixedUpdate()
    {
        timer += 1;
    }*/
    public void ResetTimer()
    {
        StopCoroutine(Timer());
        timer = 0;
        StartCoroutine(Timer());
    }
    public IEnumerator Timer()
    {
        while (timer < 30)
        {
            yield return new WaitForSeconds(1);
            timer += 1;
        }
    }
}
