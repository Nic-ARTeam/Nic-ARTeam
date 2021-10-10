using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MainUIThread : MonoBehaviour
{
    [SerializeField]
    private ARSessionOrigin SessionOrigin;

    [SerializeField]
    private GameObject Interface_Panel;

    [SerializeField]
    private GameObject Credits_Panel;

    [SerializeField]
    private Canvas OriginCanvas;

    [SerializeField]
    private Button btn_Start;

    [SerializeField]
    private Button btn_Credits;

    [SerializeField]
    private Button btn_Quit;

    private void Awake()
    {
        SessionOrigin.enabled = false;
        OriginCanvas.enabled = false;
        Credits_Panel.gameObject.SetActive(false);
        // Fixing components
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void SwitchBehaviour(bool trigger)
    {
        if (trigger)
        {
            btn_Start.onClick.AddListener(StartSession);
            btn_Quit.onClick.AddListener(QuitInterface);
            btn_Credits.onClick.AddListener(ShowCredits);
        }else
        {
            btn_Start.onClick.RemoveListener(StartSession);
            btn_Quit.onClick.RemoveListener(QuitInterface);
            btn_Credits.onClick.RemoveListener(ShowCredits);
        }

    }

    private void StartSession()
    {
        SessionOrigin.enabled = true;
        Interface_Panel.SetActive(false);
        OriginCanvas.enabled = true;
    }

    private void OnEnable()
    {
        SwitchBehaviour(true);
    }

    private void OnDisable()
    {
        SwitchBehaviour(false);
    }

    private void ShowCredits()
    {
        Credits_Panel.SetActive(true);
        Interface_Panel.SetActive(false);
        OriginCanvas.enabled = false;
    }

    void QuitInterface()
    {
        Application.Quit();
    }
}
