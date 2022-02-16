using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject CargoMenuUI;
    public float tweenTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(CargoMenuUI, new Vector3(0, 0, 0), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        LeanTween.scale(CargoMenuUI, new Vector3(1, 1, 1), 0.25f).setEaseInQuad().setIgnoreTimeScale(true);
        CargoMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
        CargoMenuUI.SetActive(false);
        GamePaused = false;
    }

    public void Resume()
    {
        LeanTween.scale(CargoMenuUI, new Vector3(0, 0, 0), 0.1f).setEaseOutQuad().setIgnoreTimeScale(true).setOnComplete(ResumeTime);
    }
}
