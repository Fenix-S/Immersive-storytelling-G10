using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadManager : MonoBehaviour
{
    private bool hasFallen = false;
    public enum scenes {Bedroom=0,Stairs=1,Universe=2,ColorRoom=3,UnderWater=4}
    public scenes GoToScenes;

    void OnTriggerEnter(Collider e)
    {   
        if (!hasFallen && e.tag.Equals("Player"))
        {
            StartCoroutine(LoadScene());
            hasFallen = true;
        }
    }

    public void LoadSceneOnClick()
    {
        if (!hasFallen)
        {
            StartCoroutine(LoadScene());
            hasFallen = true;
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene((int)GoToScenes);
    }

}
