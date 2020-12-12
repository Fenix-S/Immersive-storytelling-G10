using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bedroomToStairs : MonoBehaviour
{

    void OnTriggerEnter(Collider e)
    {
        if (e.tag.Equals("Player"))
        {
            StartCoroutine(LoadStairsScene());
        }
    }

    IEnumerator LoadStairsScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

}
