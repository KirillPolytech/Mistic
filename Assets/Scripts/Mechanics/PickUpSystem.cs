using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    float throwForce = 600;
    Vector3 objectPos;
    float distance;
    Ray CameraRay;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;


    void Update()
    {
        CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        MouseDown();
        MouseUp();
        if (distance >= 6f)
        {
            isHolding = false;
        }
        //Check if isholding
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void MouseDown()
    {
        if (Physics.Raycast(CameraRay, 5f) && Input.GetMouseButton(0) && distance <= 5f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }
    void MouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
        }
    }
}
