using UnityEngine;

public class GameSystem : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 60;
    }
}
