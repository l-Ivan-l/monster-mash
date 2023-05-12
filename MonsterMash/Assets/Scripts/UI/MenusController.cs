using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusController : MonoBehaviour
{
    public GameObject titlePanel;
    public Animator titleAnimator;
    public GameObject titleButtonsPanel;
    private Animator titleButtonsAnimator;
    public List<Button> titleButtons = new List<Button>();

    public GameObject creditsPanel;

    private void Awake()
    {
        titleButtonsAnimator = titleButtonsPanel.GetComponent<Animator>();
    }

    public void GameStarted()
    {
        titleAnimator.SetBool("TitleOut", true);
        titleButtonsAnimator.SetBool("TitleOut", true);
        foreach(Button btn in titleButtons)
        {
            btn.enabled = false;
        }
    }

    public void SeeCredits()
    {
        titleButtonsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
