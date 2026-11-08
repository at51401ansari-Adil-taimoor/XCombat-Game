using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class GameplayUI : MonoBehaviour
{
    
    public GameMechanics gameMechanics;
    public GameObject counterUI;
    public Text timerText;
    public Text highscoreText;
    public GameObject pauseMenu;
    public GameObject WinMenu;
    public GameObject LoseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterUI.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    public void updateCounter()
    {
        
        counterUI.GetComponent<Text>().text = gameMechanics.counter.ToString();
    }
    public void updatetime()
    {
        
        timerText.text = Mathf.Round(gameMechanics.currentTime).ToString();
    }
    public void showPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void hidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
    public void replay()
    {
        StartCoroutine(ReplayWithSound());
    }

    IEnumerator ReplayWithSound()
    {
        Time.timeScale = 1f;

        yield return new WaitForSecondsRealtime(0.25f);

        SceneManager.LoadScene("Gameplay");
    }
    public void ShowWinPanel()
    {
        WinMenu.SetActive(true);

    }
    public void ShowLosePanel()
    {
        LoseMenu.SetActive(true);

    }
    public void UpdatehighscoreText()
    {
        highscoreText.text = "High Score: " + GameMechanics.highScore;
    }

    public void GoToMainMenu()
    {
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        Time.timeScale = 1f;

        // Wait briefly so the button click sound can play
        yield return new WaitForSecondsRealtime(0.25f);

        SceneManager.LoadScene("SampleScene");
    }
}
