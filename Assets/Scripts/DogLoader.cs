using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLoader : MonoBehaviour
{
    public GameObject dog;
    void Start()
    {
        if(PlayerPrefs.GetInt("enableDog", 1) % 2 == 0)
        {
            dog.SetActive(true);
            //advance clock
            ClockTimer klok = GameObject.FindGameObjectWithTag("klok").GetComponent<ClockTimer>();
            klok.initialHoursValue = 5;
            klok.initialMinutesValue = 13;
        }
    }
}
