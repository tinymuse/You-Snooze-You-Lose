using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TVLight : MonoBehaviour
{
    public Light2D lt;
    public float duration;
    public float minValue;
    public float maxValue;
    //public float originalRange;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light2D>();
        minValue = lt.pointLightOuterRadius;
        maxValue = minValue + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        lt.pointLightOuterRadius = Mathf.Lerp(minValue, maxValue, Mathf.PingPong(Time.time / duration, 1));
        
        
        //StartCoroutine(changeAfterTime());
       // var amplitude = Mathf.PingPong(Time.time / duration, Random.Range(11f,11.5f));

        // Transform from 0..duration to 0.5..1 range.
        //amplitude = amplitude / duration * 1f;

        // Set light range.
        //lt.pointLightOuterRadius = amplitude;
    }

    IEnumerator changeAfterTime()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            lt.pointLightOuterRadius = Random.Range(11f, 11.5f);

        }

    }
}
