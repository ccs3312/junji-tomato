using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;
    public GameObject inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
        inventory.transform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("gfgojoiwrjw");
            if (paused)
            {
                paused = false;
                inventory.transform.localScale = Vector2.zero;
                Time.timeScale = 1f;
            }
            else
            {
                paused = true;
                inventory.transform.localScale = Vector2.one;
                Time.timeScale = 0f;
            }
        }
    }
}
