using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CustomButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private GameObject selector;
    private TextMeshProUGUI buttonText;

    private void Awake()
    {
        selector = transform.GetChild(0).gameObject;
        buttonText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        selector.SetActive(false);
        buttonText.color = Color.white;
    }

    public void OnSelect(BaseEventData eventData)
    {
        selector.SetActive(true);
        buttonText.color = Color.yellow;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selector.SetActive(false);
        buttonText.color = Color.white;
    }
}
