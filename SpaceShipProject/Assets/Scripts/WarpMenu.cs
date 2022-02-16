using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpMenu : MonoBehaviour
{
    private Vector3 PlayerCoords;
    public static bool GamePaused = false;
    public float tweenTime = 1f;
    public LevelLoader script;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
    }

    void Start()
    {
        LeanTween.scale(PauseMenuUI, new Vector3(0, 0, 0), 0.5f);
    }

    public void Pause()
    {
        LeanTween.scale(PauseMenuUI, new Vector3(1, 1, 1), 0.25f).setEaseInQuad().setIgnoreTimeScale(true);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Resume()
    {
        LeanTween.scale(PauseMenuUI, new Vector3(0, 0, 0), 0.1f).setEaseOutQuad().setIgnoreTimeScale(true).setOnComplete(ResumeTime);
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        GamePaused = false;
    }

    public void warpMeteorite()
    {
        PlayerCoords = new Vector3(2f, 2f, 0f);
        LeanTween.scale(PauseMenuUI, new Vector3(0, 0, 0), 0.1f).setEaseOutQuad().setIgnoreTimeScale(true).setOnComplete(ResumeTime);


        Resume();
    }

    public void warpShipwreck()
    {
        LeanTween.scale(PauseMenuUI, new Vector3(0, 0, 0), 0.1f).setEaseOutQuad().setIgnoreTimeScale(true).setOnComplete(ResumeTime);
        //script.GetComponent<LevelLoader>().LoadNextLevel("ShipwreckCity");
    }

    void startHyperSpeed()
    {

    }
}
