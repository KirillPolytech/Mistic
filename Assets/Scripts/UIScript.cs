using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI FPS;

    public TextMeshProUGUI CollectablesCount;

    public Image StaminaImage;

    public GameObject WinScreenGameObject;
    public GameObject GameOverScreenGameObject;

    private Player _player;

    private float deltaTime;
    private void Start()
    {
        GameObject PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        _player = PlayerGameObject.GetComponent<Player>();

        // After Restart Settings.
        WinScreenGameObject.SetActive(false);
        GameOverScreenGameObject.SetActive(false);
        //

    }
    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        FPS.text = "FPS: " + (int)(1.0f / deltaTime);
    }
    private void FixedUpdate()
    {
        DeadScreen();
        WinScreen();
    }
    void DeadScreen()
    {
        if (_player.IsPlayerDead && !_player.IsPlayerWin)
        {
            // addForceOnClick.enabled = false;
            GameOverScreenGameObject.SetActive(true);
        }
    }
    void WinScreen()
    {
        if ( _player.IsPlayerWin && !_player.IsPlayerDead )
        {
            WinScreenGameObject.SetActive(true);
            // addForceOnClick.enabled = false;
        }
    }
}
// Camera.main.GetComponent<CameraTracking>().Line.enabled = false;