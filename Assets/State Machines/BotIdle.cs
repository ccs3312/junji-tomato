using UnityEngine;

public class BotIdle : BotBaseState
{
    private int dir = 1;
    

    public override void EnterState(BotStateManager bsm)
    {
        //bot.position = bsm.bot.position;
        speed *= 1f;
    }
    public override void UpdateState(BotStateManager bsm)
    {
        bot.position = new Vector2 (bot.position.x+speed*dir*Time.deltaTime, bot.position.y);
    }

    public override void Collided(Collider2D other)
    {
        //Debug.Log("shit my elf");
        if (other.gameObject.CompareTag("Door"))
        {
            doornot = Random.Range(0, 1);
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
    }

}
