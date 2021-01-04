using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lidControl : MonoBehaviour
{
    public MeshRenderer topLid;
    public MeshRenderer bottomLid;

    private bool doOnce = false;

    public void OnTriggerEnter(Collider e)
    {
        if (!doOnce && e.tag.Equals("Player"))
        {
            topLid.enabled = true;
            bottomLid.enabled = true;
            doOnce = true;
        }
    }
}
