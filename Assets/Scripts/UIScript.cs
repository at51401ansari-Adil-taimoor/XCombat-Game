using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{


    public GameObject mainmenu;
    public GameObject howtoplay;
    public GameObject credits;
    public GameObject settings;
    public GameObject FadePanel;


    Color c;
    public Image fade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadePanel.SetActive(false);
        mainmenu.SetActive(true);
        howtoplay.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openSettings()
    {
        mainmenu.SetActive(false);
        howtoplay.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(true);

    }
    public void openCredits()
    {
        mainmenu.SetActive(false);
        howtoplay.SetActive(false);
        credits.SetActive(true);
        settings.SetActive(false);
    }
    public void openHowtoPlay()
    {
        mainmenu.SetActive(false);
        howtoplay.SetActive(true);
        credits.SetActive(false);
        settings.SetActive(false);
    }
    public void backtoMain()
    {
        mainmenu.SetActive(true);
        howtoplay.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(false);
    }

    public void PlayGame()
    {
        StartCoroutine(fadeandLoad());
    }
    IEnumerator fadeandLoad()
    {
        FadePanel.SetActive(true);
        c = fade.color;

        for (int i = 0; i < 10; i++)
        {
            c.a = c.a + 0.10f;
            fade.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        SceneManager.LoadScene(1);
    }
    public void BackFromSettings()
    {
        StartCoroutine(CloseSettings());
    }

    IEnumerator CloseSettings()
    {
        Animator animator = settings.GetComponent<Animator>();

        animator.SetTrigger("SlideOut");

        // Wait for the animation to finish
        yield return new WaitForSecondsRealtime(0.35f);

        settings.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void BackFromHowToPlay()
    {
        StartCoroutine(CloseHowToPlay());
    }

    IEnumerator CloseHowToPlay()
    {
        Animator animator = howtoplay.GetComponent<Animator>();

        animator.SetTrigger("SlideOut");

        yield return new WaitForSecondsRealtime(0.35f);

        howtoplay.SetActive(false);
        mainmenu.SetActive(true);
    }


    public void BackFromCredits()
    {
        StartCoroutine(CloseCredits());
    }

    IEnumerator CloseCredits()
    {
        Animator animator = credits.GetComponent<Animator>();

        animator.SetTrigger("SlideOut");

        // Wait for slide-out animation to finish
        yield return new WaitForSecondsRealtime(0.7f);

        credits.SetActive(false);
        mainmenu.SetActive(true);
    }

}
