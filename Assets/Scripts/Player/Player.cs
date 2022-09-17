using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isDead = false;
    private bool _isWin = false;
    public bool IsPlayerDead { get { return _isDead; } }
    public bool IsPlayerWin { get { return _isWin; } }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Rigidbody>().velocity.magnitude > 5)
        {
            _isDead = true;
        }
    }
}
