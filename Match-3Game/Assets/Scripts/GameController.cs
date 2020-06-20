using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private AudioController music;
    public Slider slider;
    public TextMeshProUGUI textPoints, textGoal;
    public GameObject panelWin, panelPause, panelLose;

    public float levelSeconds = 120;
    private float timer = 0;
    private bool count = false;
    private int points = 0;
    public int goal;
    public bool isOnlyMenu = false;
    private int acumulatePoints = 0;

    public string nameNextLevel = "";

    void Start()
    {
        music = FindObjectOfType<AudioController>();
        if (!isOnlyMenu)
        {
            panelLose.SetActive(false);
            panelWin.SetActive(false);
            panelPause.SetActive(false);
            Time.timeScale = 1.0f;
            textGoal.GetComponent<TextMeshProUGUI>().text = "Your Goal: " + goal;
            count = true;
        }
    }

    void Update()
    {
        

        if (!isOnlyMenu)
        {
            textPoints.GetComponent<TextMeshProUGUI>().text = "Your Points: " + points;

            if (count)
            {
                timer += Time.deltaTime;
                slider.value = timer;
                if (timer >= levelSeconds)
                {
                    count = false;
                    WinOrLose();
                }
            }
        }
        
    }

    private void WinOrLose()
    {
        Time.timeScale = 0.0f;
        if (points >= goal)
        {
            panelWin.SetActive(true);
        }
        else
        {
            panelLose.SetActive(true);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        panelPause.SetActive(true);
    }

    public void Run()
    {
        Time.timeScale = 1.0f;
        panelPause.SetActive(false);
    }

    public void AddPoint()
    {
        points++;
        acumulatePoints = points;
        if (acumulatePoints >= 3)
        {
            acumulatePoints = 0;
            PlayButton();
        }
    }

    public void LoadStartMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nameNextLevel);
    }

    public void LoadThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PlayShuffle()
    {
        music.PlayMatch();
    }

    public void PlayButton()
    {
        music.PlayButton();
    }


}
