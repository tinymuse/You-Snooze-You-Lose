using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomDialogue : MonoBehaviour
{
    public Dialogue[] tvDialogues;
    public Dialogue[] thoughtDialogues;
    // private TMP_Text titleLabel;
    public GameObject thoughtBubble;
    public GameObject tvBubble;
    public TMP_Text hersThoughtTextLabel;
    public TMP_Text tvTextLabel;
    public Animator tvAnimator;
    public BarToggle energyBar;

    // Start is called before the first frame update
    void Start()
    {

        tvBubble.SetActive(false);
        thoughtBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (energyBar.gameEnd == true)
        {
            StopAllCoroutines();
            if (tvBubble.activeSelf == true)
            {
                tvAnimator.SetTrigger("TVDialogueEnd");
            }
            tvBubble.SetActive(false);
            thoughtBubble.SetActive(false);
            energyBar.gameEnd = false;
        }
    }

    public void StartRandomDialogue()
    {
        StartCoroutine(tvDialogueAfterTime());
        StartCoroutine(thoughtDialogueAfterTime());
    }

    IEnumerator tvDialogueAfterTime()
    {
        yield return new WaitForSeconds(10);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6, 8));

            if (thoughtBubble.activeSelf == true)
            {
                yield return new WaitUntil(()=> thoughtBubble.activeSelf == false);
            }

            Dialogue tvDialogue = tvDialogues[Random.Range(0, 5)];

            tvBubble.SetActive(true);
            for (int i = 0; i < tvDialogue.sentences.Length; i++)
            {
                string sentence = tvDialogue.sentences[i];
                tvTextLabel.text = sentence;
            }
            yield return new WaitForSeconds(5);

            tvAnimator.SetTrigger("TVDialogueEnd");
            yield return new WaitForSeconds(0.5f);
            tvBubble.SetActive(false);

        }
    }

    IEnumerator thoughtDialogueAfterTime()
    {
        yield return new WaitForSeconds(6);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 8));

            if (tvBubble.activeSelf == true)
            {
                yield return new WaitUntil(() => tvBubble.activeSelf == false);
            }

            thoughtBubble.SetActive(true);
            if (energyBar.level1 == true)
            {

                Dialogue thoughtDialogue = thoughtDialogues[Random.Range(0,3)];


                for (int i = 0; i < thoughtDialogue.sentences.Length; i++)
                {
                    string sentence = thoughtDialogue.sentences[i];
                    hersThoughtTextLabel.text = sentence;
                }
            }
            else if (energyBar.level2 == true)
            {
                Dialogue thoughtDialogue = thoughtDialogues[Random.Range(2, 4)];


                for (int i = 0; i < thoughtDialogue.sentences.Length; i++)
                {
                    string sentence = thoughtDialogue.sentences[i];
                    hersThoughtTextLabel.text = sentence;
                }
            }
            else if (energyBar.level3 == true)
            {
                Dialogue thoughtDialogue = thoughtDialogues[Random.Range(3, 5)];


                for (int i = 0; i < thoughtDialogue.sentences.Length; i++)
                {
                    string sentence = thoughtDialogue.sentences[i];
                    hersThoughtTextLabel.text = sentence;
                }
            }
            else
            {
                Dialogue thoughtDialogue = thoughtDialogues[Random.Range(1, 3)];
                for (int i = 0; i < thoughtDialogue.sentences.Length; i++)
                {
                    string sentence = thoughtDialogue.sentences[i];
                    hersThoughtTextLabel.text = sentence;
                }
            }
            

            /*Dialogue thoughtDialogue = thoughtDialogues[Random.Range(0, 5)];

            
            for (int i = 0; i < thoughtDialogue.sentences.Length; i++)
            {
                string sentence = thoughtDialogue.sentences[i];
                hersThoughtTextLabel.text = sentence;
            }*/
                    
            yield return new WaitForSeconds(5);
            thoughtBubble.SetActive(false);

        }
    }
}

