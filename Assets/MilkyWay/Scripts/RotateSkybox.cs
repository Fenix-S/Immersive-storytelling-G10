using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    [SerializeField] Material stars;
    float rotationValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationValue = rotationValue + 0.005f;
        if (rotationValue >= 360)
        {
            rotationValue = 1;
        }
        stars.SetFloat("_Rotation", rotationValue);
    }
}
