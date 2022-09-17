using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float Speed = 0.1f;
    float AxisX, AxisY;
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        AxisX = Input.GetAxis("Horizontal");
        AxisY = Input.GetAxis("Vertical");
        transform.position += AxisY * Speed * transform.forward + AxisX * Speed * transform.right;
    }
}
