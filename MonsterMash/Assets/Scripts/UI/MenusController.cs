using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenusController : MonoBehaviour
{
    public GameObject titlePanel;
    public Animator titleAnimator;
    public GameObject titleButtonsPanel;
    private Animator titleButtonsAnimator;
    public List<Button> titleButtons = new List<Button>();
    public Button backBtn;

    public GameObject creditsPanel;

    private void Awake()
    {
        titleButtonsAnimator = titleButtonsPanel.GetComponent<Animator>();
    }

    public void GameStarted()
    {
        EventSystem.current.SetSelectedGameObject(null);
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
        EnableBackButton();
    }

    public void Back()
    {
        titleButtonsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        DisableBackButton();
        titleButtons[0].Select();
    }

    void EnableBackButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        backBtn.gameObject.SetActive(true);
        backBtn.Select();
    }

    void DisableBackButton()
    {
        backBtn.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
