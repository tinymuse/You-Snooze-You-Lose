using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMasher : MonoBehaviour
{
    public KeyCode buttonOne;
    public KeyCode buttonTwo;
    public BarToggle barToggle;
    public int recoveryRate;
    public bool buttonOnePressed = false;

    // Start is called before the first frame update
    void Start()
    {
        barToggle = GameObject.Find("EnergyBar").GetComponent<BarToggle>();
        buttonOne = KeyCode.LeftArrow;
        buttonTwo = KeyCode.RightArrow;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonOne))
        {
            buttonOnePressed = true;
        }

        if (Input.GetKeyDown(buttonTwo) && buttonOnePressed == true)
        {
            buttonOnePressed = false;
            barToggle.currentEnergy += recoveryRate;

        }
    }
}

