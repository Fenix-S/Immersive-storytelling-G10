using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
    public float waitSeconds = 15f;
    public enum scenes { Bedroom = 0, Stairs = 1, Universe = 2, ColorRoom = 3, UnderWater = 4 }
    public scenes GoToScenes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene((int)GoToScenes);
    }
}
