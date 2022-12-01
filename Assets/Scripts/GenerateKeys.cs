using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateKeys : MonoBehaviour
{
    public int noOfKeys;
    public int[] keysToPress;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upArrowSucceed;
    public GameObject downArrowSucceed;
    public GameObject leftArrowSucceed;
    public GameObject rightArrowSucceed;
    public GameObject upArrowFail;
    public GameObject downArrowFail;
    public GameObject leftArrowFail;
    public GameObject rightArrowFail;
    private GameObject arrowToPress;
    private int arrowInput;
    public float distanceBetweenKeys;
    public int noOfKeysPressed;
    public GameObject coffeeCup;
    public bool changeLevel = false;
    public Animator joeAnimator;



    // Start is called before the first frame update
    void OnEnable()
    {
        keysToPress = new int[noOfKeys];
        coffeeCup = GameObject.Find("CoffeeCup");
        joeAnimator = GameObject.Find("Joe").GetComponent<Animator>();
        noOfKeysPressed = 0;
        GenerateNewKeys();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Return))
        {
            GenerateNewKeys();
        }*/

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PressKeys();
        }

        if (noOfKeysPressed == noOfKeys)
        {
           // if (Input.GetKeyDown(KeyCode.Space))            {
                coffeeCup.GetComponent<CoffeeBreak>().currentCoffee += 1;
                SoundManager.Play("pourCoffee");
                noOfKeysPressed = 0;
                GenerateNewKeys();
            //}
        }
       


    }

    public void GenerateNewKeys()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Arrow");

        foreach (GameObject gameObject in gameObjects)
        {
            Destroy(gameObject);
        }

        Vector3 right = transform.right;

        for (int i = 0; i < keysToPress.Length; i++)
        {
            keysToPress[i] = Random.Range(2, 5);

            if (keysToPress[i] == 2)
            {
                arrowToPress = upArrow;
            }
            else if (keysToPress[i] == 3)
            {
                arrowToPress = downArrow;
            }
            else if (keysToPress[i] == 4)
            {
                arrowToPress = leftArrow;
            }
            else if (keysToPress[i] == 5)
            {
                arrowToPress = rightArrow;
            }
            float offset = i * distanceBetweenKeys;
            Vector3 position = transform.position + right * offset;
            Instantiate(arrowToPress, position, transform.rotation);

        }
    }

    public void ChangeLevel(int i)
    {
        if (noOfKeysPressed == 0 && changeLevel == false)
        {
            if (i == 2)
            {
                noOfKeys = 6;
                changeLevel = true;
            }    
            if (i == 3)
            {
                noOfKeys = 8;
                changeLevel = false;
            }         
            
            keysToPress = new int[noOfKeys];
            GenerateNewKeys();

            

        }
        
    }



    public void PressKeys()
    {
        Vector3 right = transform.right;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrowInput = 2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrowInput = 3;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrowInput = 4;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrowInput = 5;
        }
        else { arrowInput = 0; }


        if (keysToPress[noOfKeysPressed] == arrowInput)
        {
            noOfKeysPressed++;

            if (arrowInput == 2)
            {

                float offset = (noOfKeysPressed-1) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(upArrowSucceed, position, transform.rotation);
            }
            else if (arrowInput == 3)
            {

                float offset = (noOfKeysPressed - 1) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(downArrowSucceed, position, transform.rotation);
            }
            else if (arrowInput == 4)
            {

                float offset = (noOfKeysPressed - 1) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(leftArrowSucceed, position, transform.rotation);
            }
            else if (arrowInput == 5)
            {

                float offset = (noOfKeysPressed - 1) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(rightArrowSucceed, position, transform.rotation);
            }
        }
            else
        {
            if (keysToPress[noOfKeysPressed] == 2)
            {
                float offset = (noOfKeysPressed) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(upArrowFail, position, transform.rotation);
            }
            else if (keysToPress[noOfKeysPressed] == 3)
            {
                float offset = (noOfKeysPressed) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(downArrowFail, position, transform.rotation);
            }
            else if (keysToPress[noOfKeysPressed] == 4)
            {
                float offset = (noOfKeysPressed) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(leftArrowFail, position, transform.rotation);
            }
            else if (keysToPress[noOfKeysPressed] == 5)
            {
                float offset = (noOfKeysPressed) * distanceBetweenKeys;
                Vector3 position = transform.position + right * offset;
                Instantiate(rightArrowFail, position, transform.rotation);
            }

            return;
        }
            

       

        }
    }

        
