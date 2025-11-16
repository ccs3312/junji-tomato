using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BotChase : BotBaseState
{
    BotIdle idlestate = new BotIdle();
    private float dir=0;
    public override void EnterState(BotStateManager bsm)
    {
        speed = 4f;
        //bsm.ResetTimer();
        //Debug.Log("please run please run please run");
    }

    public override void UpdateState(BotStateManager bsm)
    {
        Debug.Log("where r u??");
        if (player.GetComponent<playerController>().coord == coord)
        {
            Debug.Log("found you.");
            dir = ((player.transform.position.x - bot.position.x) / math.abs(player.transform.position.x - bot.position.x));
        }
        bot.position = new Vector2(bot.position.x + dir * speed * Time.deltaTime, bot.position.y);
        /*if (bsm.timer >= 30)
        {
            Debug.Log("well shit");
            bsm.SwitchState(idlestate);
        }*/
        bsm.bot.position = bot.position;
    }
    public override void Collided(BotStateManager bsm, Collider2D other)
    {
        //Debug.Log("eat my shit");
        if (other.gameObject.CompareTag("Door"))
        {
            Door = other.gameObject.GetComponent<Door>();
            if (Door.coord[0] < player.GetComponent<playerController>().coord[0])
            {
                if (Door.coord[1] == 0)
                {
                    Door.OpenDoor(0, "bot");
                }
            }
            else if (Door.coord[0] > player.GetComponent<playerController>().coord[0])
            {
                if (Door.coord[1] == 0)
                {
                    Door.OpenDoor(1, "bot");
                }
            }
            else
            {
                if (Door.coord[1] == player.GetComponent<playerController>().coord[1])
                {
                    Door.OpenDoor(0, "bot");
                }
            }
                // trigger opendoor script
        }
    }
}
