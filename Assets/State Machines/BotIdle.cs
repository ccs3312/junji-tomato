using UnityEngine;

public class BotIdle : BotBaseState
{
    public int dir = 1;
    //BotChase chasestate = new BotChase();

    public override void EnterState(BotStateManager bsm)
    {
        //bot.position = bsm.bot.position;
        bsm.spk.enabled = false;
        speed = 10f;
        //Debug.Log(bsm.coord[0]);
    }
    public override void UpdateState(BotStateManager bsm)
    {
        bsm.animator.SetFloat("dir", dir);
        bot.position = new Vector2 (bot.position.x+speed*dir*Time.deltaTime, bot.position.y);
    }

    public override void Collided(BotStateManager bsm, Collider2D other)
    {
        if (other.gameObject.CompareTag("Bound"))
        {
            dir *= -1;
        }
        //Debug.Log("shit my elf");
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("I a door u");
            doornot = Random.Range(0, 2);
            if (doornot == 1)
            {
                Door = other.gameObject.GetComponent<Door>();

                if (Random.Range(0, 1) == 0)
                {
                    Door.OpenDoor(0, "bot");
                }
                else
                {
                    Door.OpenDoor(1, "bot");
                }
                // trigger opendoor script
            }

        }
        if (other.gameObject.CompareTag("Player"))
        {
            bsm.SwitchState(bsm.chasestate);
        }
    }

}
