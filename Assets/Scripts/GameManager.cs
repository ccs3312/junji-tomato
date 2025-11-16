using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dialogue Dialogue;
    public string[] oplines = { }; //openingdialogue


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Cutscene1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Cutscene1()
    {
        //Time.timeScale = 0f;
        yield return new WaitForSeconds(1);
        Dialogue.gameObject.SetActive(true);
        Dialogue.StartDialogue(oplines);
    }
}
