using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
public class GameMechanics : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] audioClip = new AudioClip[3];
    
    int random;
    public int counter;
    public GameplayUI gameplayUI;
    public float defaultTimer;
    public float currentTime;
    bool pauseFlag = false;
    public int target_counter;
    bool timerExpired;
    public static int highScore;

    public float countdowntimer;
    public Text countDownText;
    bool countDownInProgress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject audioManager = GameObject.Find("AudioManager");

        if (audioManager != null)
        {
            AudioSource backgroundMusic = audioManager.GetComponent<AudioSource>();
            GameSettings.ApplyMusicSettings(backgroundMusic);
        }

        countDownInProgress = true;
        highScore = PlayerPrefs.GetInt("HighScore");
        timerExpired = false;
        gameplayUI.UpdatehighscoreText();
        currentTime = defaultTimer;
        StartCoroutine(countDownTimerRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (timerExpired == false && countDownInProgress ==false)
        {
            if (currentTime > 0)
            {
                currentTime = currentTime - Time.deltaTime;
                gameplayUI.updatetime();
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    counter++;
                    playSound();
                    gameplayUI.updateCounter();
                }
            }
            else
            {
                timerExpired = true; 
                currentTime = 0;
                gameplayUI.updatetime();
                if(highScore < counter)
                {
                    highScore = counter;
                    PlayerPrefs.SetInt("HighScore",highScore);
                    PlayerPrefs.Save();
                    gameplayUI.UpdatehighscoreText();


                }
                Debug.Log(PlayerPrefs.GetInt("HighScore"));
                if (counter >= target_counter)
                {
                    gameplayUI.ShowWinPanel();
                }
                else
                {
                    gameplayUI.ShowLosePanel();
                }
            }
        }
    }

    public void pauseUnpause()
    {
        if (pauseFlag == false) 
        {
            pauseFlag = true;
            gameplayUI.showPauseMenu();
            Time.timeScale = 0f;
        }
        else
        {
            pauseFlag = false;
            gameplayUI.hidePauseMenu();
            Time.timeScale = 1f;
        }
    }

    public void playSound()
    {
        random = Random.Range(0, 2);
        audiosource.PlayOneShot(audioClip[random]);
       
    }
  
    
    IEnumerator countDownTimerRoutine()
    {
        countDownText.text = countdowntimer.ToString();
        yield return new WaitForSeconds(1f);
        countdowntimer = countdowntimer - 1;
        countDownText.text = countdowntimer.ToString();
        yield return new WaitForSeconds(1f);
        countdowntimer = countdowntimer - 1;
        countDownText.text = countdowntimer.ToString();
        yield return new WaitForSeconds(1f);
        countDownText.text = "Start";
        yield return new WaitForSeconds(0.5f);
        countdowntimer = 0;
        countDownInProgress = false;
        countDownText.text = "";

    }
}
