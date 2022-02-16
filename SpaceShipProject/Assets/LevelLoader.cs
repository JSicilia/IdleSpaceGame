using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private Rigidbody2D rb;

    public void LoadNextLevel(string sceneName)
    {

        StartCoroutine(LoadLevel(sceneName));
        Debug.Log("Trigger animation");
    }

    public float GetCurrentPos()
    {
        rb = GetComponent<Rigidbody2D>();
        return rb.position.x;
    }

    IEnumerator LoadLevel(string levelName)
    {
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(levelName);
    }
}
