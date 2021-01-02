using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadManager : MonoBehaviour
{
    public Animator animator;
    private bool hasFallen = false;
    public bool isLoading { get; private set; }
    public enum scenes {Bedroom=0,Stairs=1,Universe=2,ColorRoom=3,UnderWater=4}
    public scenes GoToScenes;
    public float wait = 4f;

    void OnTriggerEnter(Collider e)
    {   
        if (!hasFallen && e.tag.Equals("Player"))
        {
            if(animator != null)
                animator.SetBool("blink", true);
            isLoading = true;
            StartCoroutine(LoadScene());
            hasFallen = true;
        }
    }

    public void LoadSceneOnClick()
    {
        if (!hasFallen)
        {
            if (animator != null)
                animator.SetBool("blink", true);
            isLoading = true;
            StartCoroutine(LoadScene());
            hasFallen = true;
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene((int)GoToScenes);
    }

}
