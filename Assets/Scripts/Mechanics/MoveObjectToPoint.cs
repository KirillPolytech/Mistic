using UnityEngine;

public class MoveObjectToPoint : MonoBehaviour
{
    public int MaxRayDistance = 150;
    public int Force = 150;
    public LineRenderer Line;
    public Material ActiveMaterial;

    private RaycastHit _hit;
    private Ray _cameraRay;
    private Vector3 _saveTargetHit = Vector3.zero;
    private bool _isLeftMouseDown, _isRightMouseDown;
    private GameObject _savedMoveAbleGameObject;
    private Material _savedObjectMaterial;
    private void Start()
    {
        Line.useWorldSpace = true;

        Line.startWidth = 0.5f;
        Line.endWidth = 0.1f;

        Line.SetPosition(0, Vector3.zero);
        Line.SetPosition(1, Vector3.zero);
    }
    private void Update()
    {
        _isLeftMouseDown = Input.GetButton("Fire1");
        _isRightMouseDown = Input.GetButton("Fire2");
        ResetPoints();
    }
    private void FixedUpdate()
    {
        _cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_cameraRay, out _hit, MaxRayDistance))
        {
            if (_isLeftMouseDown && _savedMoveAbleGameObject == null && _hit.collider.CompareTag("MoveAble"))
            {
                _savedMoveAbleGameObject = _hit.collider.gameObject;

                _savedObjectMaterial = _savedMoveAbleGameObject.GetComponent<Renderer>().material;
                _savedMoveAbleGameObject.GetComponent<Renderer>().material = ActiveMaterial;
                Debug.Log("savedObject");
            }
            if (_isRightMouseDown) // && _savedMoveAbleGameObject != null
            {
                _saveTargetHit = _hit.point;
                Debug.Log("savedTarget");
            }
        }
        if (_savedMoveAbleGameObject != null && _saveTargetHit != Vector3.zero)
        {
            _savedMoveAbleGameObject.GetComponent<Rigidbody>().AddForce((_saveTargetHit - _savedMoveAbleGameObject.transform.position) * Force, ForceMode.Force);

            SetLinePosition(_savedMoveAbleGameObject.transform.position, _saveTargetHit);
        }

        DynamicGI.UpdateEnvironment();

        if (_savedMoveAbleGameObject != null)
            Debug.DrawLine(_cameraRay.origin, _savedMoveAbleGameObject.transform.position, Color.red);
        Debug.DrawLine(_cameraRay.origin, _saveTargetHit, Color.green);

        Debug.DrawRay(_cameraRay.origin, _cameraRay.direction * MaxRayDistance, Color.white);
    }
    void ResetPoints()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _savedMoveAbleGameObject.GetComponent<Renderer>().material = _savedObjectMaterial;

            _savedMoveAbleGameObject = null;
            ResetLinePosition();
            _saveTargetHit = Vector3.zero;
        }

    }
    void SetLinePosition(Vector3 Start, Vector3 End)
    {
        Line.SetPosition(0, Start);
        Line.SetPosition(1, End);
    }
    void ResetLinePosition()
    {
        Line.SetPosition(0, Vector3.zero);
        Line.SetPosition(1, Vector3.zero);
    }
}
// 1 - сохраняем точку столкновения луча с перемещаемым объектом и сам объект.
// 2 - сохраняем вторую точку.
// 3 - перемещаем сохранённый объект в нужную нам точку.

/*
 * RaycastHit _hit2;
 * Vector3 _savedObjectHit
 * 
if (Physics.Raycast(_cameraRay, out _hit, MaxRayDistance) && _isLeftMouseDown && _savedMoveAbleGameObject == null && _hit.collider.CompareTag("MoveAble") )
{
    _savedMoveAbleGameObject = _hit.collider.gameObject;

    Debug.Log("savedObject");
}

if (Physics.Raycast(_cameraRay, out _hit2, MaxRayDistance) && _isRightMouseDown && _savedMoveAbleGameObject != null)
{
    _saveTargetHit = _hit2.point;
    Debug.Log("savedTarget");
}

if (_savedMoveAbleGameObject != null && _saveTargetHit != Vector3.zero)
{
    _savedMoveAbleGameObject.GetComponent<Rigidbody>().AddForce( (_saveTargetHit - _savedMoveAbleGameObject.transform.position) * Force, ForceMode.Force);
}
*/
