using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public Light light;
    public int pauze = 5;
    private Flare flare;
    // Start is called before the first frame update
    void Start()
    {
        //light = FindObjectOfType<Light>();
        flare = light.flare;
        StartCoroutine(Flash(light));
    }

    // Update is called once per frame
    IEnumerator Flash(Light light)
    {
        light.enabled = false;
        yield return new WaitForSeconds(pauze);
        light.enabled = true;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Flash(light));
    }
}
