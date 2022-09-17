using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayFromCamera : MonoBehaviour
{
    public Vector3 OffSet;
    private Ray _ray;
    private LineRenderer _lineFromCamera;
    private void Start()
    {
        _lineFromCamera = GetComponent<LineRenderer>();
        _lineFromCamera.material = new Material(Shader.Find("Diffuse"));
    }
    private void FixedUpdate()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _lineFromCamera.SetPosition(0, Camera.main.transform.position + OffSet);
        _lineFromCamera.SetPosition(1, _ray.GetPoint(100));
        Debug.DrawRay(_ray.origin, _ray.direction * 100, Color.blue);
    }
}
