using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MainUIThread : MonoBehaviour
{
    [SerializeField]
    private ARSession Session;

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

    private void SwitchSession(bool trigger)
    {
        OriginCanvas.enabled =  trigger;
        Session.enabled = trigger;
    }

    private void StartSession()
    {
        SwitchSession(true);
        Interface_Panel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SwitchBehaviour(true);
        SwitchSession(false);
    }

    private void OnDisable()
    {
        SwitchBehaviour(false);
    }

    private void ShowCredits()
    {
        Credits_Panel.gameObject.SetActive(true);
        Interface_Panel.gameObject.SetActive(false);
    }

    void QuitInterface()
    {
        Application.Quit();
    }

        /// <summary>
    /// Show an Android toast message.
    /// </summary>
    /// <param name="message">Message string to show in the toast.</param>
    private static void ShowAndroidToastMessage(string message)
    {
#if UNITY_ANDROID
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            if (unityActivity == null) return;
            var toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                // Last parameter = length. Toast.LENGTH_LONG = 1
                using (var toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText",
                    unityActivity, message, 1))
                {
                    toastObject.Call("show");
                }
            }));
        }
#endif
    }
}
