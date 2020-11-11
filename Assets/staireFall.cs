using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staireFall : MonoBehaviour
{
    private GameObject[] stairs;

    void Start()
    {
        Rigidbody[] r = transform.GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < r.Length; i++)
        {
            r[i].useGravity = false;
            StartCoroutine(fall(i, r[i]));
            StartCoroutine(destroyStair(i, transform.GetChild(i).gameObject));
        }

    }

    IEnumerator fall(int index, Rigidbody rb)
    {
        yield return new WaitForSeconds(index * 1f);
        rb.useGravity = true;
        rb.velocity = Vector3.down * 2f;
    }

    IEnumerator destroyStair(int i, GameObject obj)
    {
        yield return new WaitForSeconds((i + 1) * 8f);
        Destroy(obj);
    }
    
}
