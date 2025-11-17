using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float stamina = 100;
    public float regenspd = 20;
    public Slider staminaSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staminaSlider.value = stamina/100;
        if(staminaSlider.value < 1)
        {
            stamina += regenspd*Time.deltaTime;
        }
    }
}
