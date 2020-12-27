using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLoader : MonoBehaviour
{
    public GameObject dog;
    void Start()
    {
        if(PlayerPrefs.GetInt("enableDog", 0) == 1)
        {
            dog.SetActive(true);
        }
    }
}
