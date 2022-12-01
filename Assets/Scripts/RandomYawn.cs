using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomYawn : MonoBehaviour
{

    public Animator joeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        joeAnimator.SetBool("Level2", true);
        joeAnimator = GameObject.Find("Joe").GetComponent<Animator>();
        StartCoroutine(yawnAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator yawnAfterTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6, 8));
            joeAnimator.SetTrigger("Yawn");
            SoundManager.PlaySound("yawn");
        }

    }

}
