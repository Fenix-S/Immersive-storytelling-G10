﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject, 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
