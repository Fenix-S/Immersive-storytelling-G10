using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staireFall : MonoBehaviour
{
    private GameObject[] stairs;
    private Rigidbody[] r;
    private AudioSource[] audioSources;
    private bool hasFallen = false;

    void Start()
    {
        r = transform.GetComponentsInChildren<Rigidbody>();
        audioSources = transform.GetComponentsInChildren<AudioSource>();

        for (int i = 0; i < r.Length; i++)
        {
            r[i].useGravity = false;
            r[i].isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider e)
    {
        if(!hasFallen && e.tag == "Player")
        {
            for (int i = 0; i < r.Length; i++)
            {
                StartCoroutine(fall(i, r[i], audioSources[i]));
                StartCoroutine(destroyStair(i, transform.GetChild(i).gameObject));
            }
            hasFallen = true;
        }
    }

    IEnumerator fall(int index, Rigidbody rb, AudioSource audioSource)
    {
        yield return new WaitForSeconds(index * 1f);
        rb.useGravity = true;
        rb.isKinematic = false;
        audioSource.Play();
        rb.velocity = Vector3.down * 2f;
    }

    IEnumerator destroyStair(int i, GameObject obj)
    {
        yield return new WaitForSeconds((i + 1) * 8f);
        Destroy(obj);
    }
    
}
