using UnityEngine;

public class Door : MonoBehaviour
{
    public int[] coord = {0,0};
    public GameObject bot;
    public GameObject you;
    [SerializeField] Vector2[] dest = { new Vector2(1, 1), new Vector2(1, 1) }; // up and down arr
    public void OpenDoor(int dir, string name)
    {
        if(name == "bot")
        {
            bot.transform.position = dest[dir];
            bot.GetComponent<BotStateManager>().coord = coord;
        }
        else if (name == "you")
        {
            you.transform.position = dest[dir];
            you.GetComponent<playerController>().coord = coord;
        }
    }
}
