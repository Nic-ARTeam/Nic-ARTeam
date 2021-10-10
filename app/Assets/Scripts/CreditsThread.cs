using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsThread : MonoBehaviour
{
    [SerializeField]
    private GameObject Interface_Panel;

    [SerializeField]
    private GameObject Credits_Panel;

    [SerializeField]
    public Button btn_Back;

    private void OnEnable()
    {
        btn_Back.onClick.AddListener(Back);
    }

    private void OnDisable()
    {
        btn_Back.onClick.RemoveListener(Back);
    }

    private void Back()
    {
        Interface_Panel.SetActive(true);
        Credits_Panel.SetActive(false);
    }
}
