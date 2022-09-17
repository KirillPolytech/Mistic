using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float Sensivity = 5f;
    public GameObject PlayerBody;

    float MouseX, MouseY;
    float XRotation = 0f;
    void FixedUpdate()
    {
        MouseX = Input.GetAxis("Mouse X") * Sensivity;
        MouseY = Input.GetAxis("Mouse Y") * Sensivity;

        XRotation -= MouseY;
        // XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        PlayerBody.transform.Rotate(Vector3.up * MouseX);
    }
}
//             hit.collider.gameObject.transform.position = CameraRay.GetPoint(MaxRayLenght);

/*
if (SavedGameObject != null && InputLeftMouseButton)
{
    Vector3 Direction = (CameraRay.GetPoint(MaxRayLenght) - SavedGameObject.transform.position) * Force;
    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(Direction);
}
else
{
    SavedGameObject = null;
}
*/

/*
 *     RaycastHit hit, hit2;
    Ray CameraRay;
    bool InputLeftMouseButton = false;
    RaycastHit Savedhit;
    public float MaxRayLenght = 100f;
    public float Force = 10f;


        CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(CameraRay, out hit, MaxRayLenght) && hit.collider.gameObject.CompareTag("MoveAble") && InputLeftMouseButton && Savedhit.point == Vector3.zero)
        {
            Savedhit = hit;
        }

        if (Physics.Raycast(CameraRay, out hit2, MaxRayLenght))
        {

        }
        else
        {
            //hit2.collider.gameObject = gameObject;
            hit2.point = CameraRay.GetPoint(MaxRayLenght);
        }

        if (Savedhit.point != Vector3.zero && InputLeftMouseButton && Savedhit.collider.gameObject != hit2.collider.gameObject)
        {
            Vector3 Direction = (CameraRay.GetPoint(MaxRayLenght) - Savedhit.point) * Force;
            Savedhit.collider.gameObject.GetComponent<Rigidbody>().AddForce(Direction);
            PlayerMovement.Speed /= Direction.magnitude * 100;
        }
        else
        {
            PlayerMovement.Speed = 0.1f;
        }
        Debug.DrawLine(CameraRay.origin, CameraRay.GetPoint(MaxRayLenght), Color.red);
        */

/*
if (Input.GetMouseButton(0))
{
    InputLeftMouseButton = true;
}
else
{
    InputLeftMouseButton = false;
}

    private void Start()
    {
        Savedhit.point = Vector3.zero;
    }
*/