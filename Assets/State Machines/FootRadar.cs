using UnityEngine;

public class FootRadar : MonoBehaviour
{
    public Collider2D foot;
    BotIdle idlestate = new BotIdle();
    public BotStateManager bsm;
    BotChase chasestate = new BotChase();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bsm.SwitchState(chasestate);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bsm.ResetTimer();
        }
    }
}
