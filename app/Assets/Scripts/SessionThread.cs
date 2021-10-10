using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SessionThread : MonoBehaviour
{
    [SerializeField]
    private ARSessionOrigin Session;

    [SerializeField]
    private GameObject Interface_Panel;

    [SerializeField]
    public Canvas OriginCanvas;

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
        Session.enabled = false;
        OriginCanvas.enabled = false;
    }
}
