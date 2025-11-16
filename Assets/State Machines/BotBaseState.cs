using UnityEngine;

public abstract class BotBaseState
{
    public GameObject player;
    public float speed;
    public int doornot;
    public Transform bot;
    public int[] coord;
    public Collider2D botHitbox;
    public Collider2D botEyesight;
    public Door Door;

    public abstract void EnterState(BotStateManager bsm);
    public abstract void UpdateState(BotStateManager bsm);
    public abstract void Collided(BotStateManager bsm,Collider2D other);
}
