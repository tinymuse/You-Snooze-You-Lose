using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmBar : MonoBehaviour
{
    public GameObject perfectZone;
    public GameObject greatZone;
    public GameObject badZone;
    public GameObject rhythmBar;
    public GameObject circleCollider;
    private GameObject keyPositions;
    private BarToggle barToggle;
    public GenerateKeys generateKeys;
    public float moveSpeed;
    private Vector3 startPos;
    public float range;
    private float timer = 0.0f;
    public bool perfectBool = false;
    public bool greatBool = false;
    public bool badBool = false;
    public bool missBool = false;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        keyPositions = GameObject.Find("KeyPositions");
        generateKeys = keyPositions.GetComponent<GenerateKeys>();
        barToggle = GameObject.Find("EnergyBar").GetComponent<BarToggle>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(startPos.x + Mathf.PingPong(timer * moveSpeed, range), transform.position.y, transform.position.z);

       
                if (generateKeys.noOfKeys == generateKeys.noOfKeysPressed)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (perfectBool)
                        {
                            print("perfect");
                            barToggle.currentEnergy += 5;
                            generateKeys.noOfKeysPressed = 0;
                            generateKeys.GenerateNewKeys();

                        }
                        if (greatBool)
                        {
                            print("great");
                            barToggle.currentEnergy += 3;
                            generateKeys.noOfKeysPressed = 0;
                            generateKeys.GenerateNewKeys();

                        }
                        if (badBool)
                        {
                            print("bad");
                            barToggle.currentEnergy += 2;
                            generateKeys.noOfKeysPressed = 0;
                            generateKeys.GenerateNewKeys();

                        }
                        else if (missBool)
                        {
                            print("miss");
                            barToggle.currentEnergy += 0;
                            generateKeys.noOfKeysPressed = 0;
                            generateKeys.GenerateNewKeys();

                        }
                    }
                }
            }

        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.x <= badZoneEnd && transform.position.x >= badZoneStart /*&& transform.position.x < greatZoneStart && transform.position.x > greatZoneEnd) 
            {
                print("bad");
            }
            else if (transform.position.x <= greatZoneEnd && transform.position.x >= greatZoneStart && transform.position.x < perfectZoneStart && transform.position.x > perfectZoneEnd)
            {
                print("great");
            }
            else if (transform.position.x <= perfectZoneEnd && transform.position.x >= perfectZoneStart)
            {
                print("perfect");
            }
            else
            {
                print("miss");
            }
        } */

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "PerfectZone")
            {
                perfectBool = true;
            }
            if (other.tag == "GreatZone")
            {
                greatBool = true;
            }
            if (other.tag == "BadZone")
            {
                badBool = true;
            }
            if (other.tag == "Bar")
            {
                missBool = true;
            }
        }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PerfectZone")
        {
            perfectBool = false;
        }
        if (other.tag == "GreatZone")
        {
            greatBool = false;
        }
        if (other.tag == "BadZone")
        {
            badBool = false;
        }
        if (other.tag == "Bar")
        {
            missBool = false;
        }


    }


}
