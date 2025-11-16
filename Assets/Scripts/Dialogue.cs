using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dbox;
    public string[] lines = { }; //{"character()expression()speech"}
    public string[] ln; //{"character","expression","speech"}
    public Image icon;
    public Sprite[] iconlist;
    public Image descpic;
    public Sprite[] dplist;
    public float txtspd;
    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dbox.text = string.Empty;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }*/
    }
    public void StartDialogue(string[] lines)
    {
        index = 0;
        dbox.text = string.Empty;
        StartCoroutine(TypeLine(lines));
    }
    public void NextLine(string[] lines)
    {
        //Debug.Log("well fuck me and my life");
        index++;
        if (index < lines.Length)
        {
            dbox.text = string.Empty;
            StartCoroutine(TypeLine(lines));
        }
        else
        {
            index = 0;
            gameObject.SetActive(false);
        }
    }
    IEnumerator TypeLine(string[] lines)
    {
        ln = lines[index].Split("()");
        if (int.Parse(ln[1]) >= iconlist.Length)
        {
            icon.sprite = null;
            icon.color = Color.clear;
        }
        else
        {
            icon.sprite = iconlist[int.Parse(ln[1])];
            icon.color = Color.white;
        }
        if (ln.Length > 3)
        {
            descpic.sprite = dplist[int.Parse(ln[3])];
            descpic.color = Color.white;
        }
        else
        {
            descpic.sprite = null;
            descpic.color = Color.clear;
        }
            foreach (char c in ln[2].ToCharArray())
            {
                dbox.text += c;
                yield return new WaitForSeconds(txtspd);
            }
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.E))
            {
                NextLine(lines);
                yield break;
            }
            yield return null;
        }

    }
}
