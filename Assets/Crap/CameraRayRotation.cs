using UnityEngine;

public class CameraRayRotation : MonoBehaviour
{
    public int MaxRayDistance = 10;
    public float RotationTime = 0.1f;
    RaycastHit Hit;
    Ray CameraRay;

    private void FixedUpdate()
    {
        // Если мышка находится в нужном диапазоне то камера двигается.
        Ray CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.mousePosition.x < Screen.width / 4 && Input.mousePosition.y > Screen.height / 4)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(CameraRay.direction), RotationTime);

        }
    }
}
/*
 * if (Physics.Raycast(CameraRay, out Hit, MaxRayDistance))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(CameraRay.direction), RotationTime);
        }
*/

/*
 *         // Если мышка находится в нужном диапазоне то камера двигается.
        Ray CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.mousePosition.x < Screen.width / 4 && Input.mousePosition.y > Screen.height / 4)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(CameraRay.direction), RotationTime);

        }
 * */