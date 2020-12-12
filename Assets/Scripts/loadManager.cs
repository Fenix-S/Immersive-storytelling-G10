using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadManager : MonoBehaviour
{
    private bool hasFallen = false;

    void OnTriggerEnter(Collider e)
    {   
        if (!hasFallen && e.tag.Equals("Player"))
        {
            StartCoroutine(LoadUniverseScene());
            hasFallen = true;
        }
    }

    IEnumerator LoadUniverseScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

}
