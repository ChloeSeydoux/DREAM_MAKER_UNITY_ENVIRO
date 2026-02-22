using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float _CamRotationSpeed = 200f;
    [SerializeField] private float _XRotaionMin = -80f;
    [SerializeField] private float _XRotationMax = 80f;
    [Header("Movement")]
    [SerializeField] private float _CamUpSpeed = 200f;
    [SerializeField] private float _MinUp = 10f;
    [SerializeField] private float _MaxUp = 20f;


    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        SetCamera();
    }

    private void Update()
    {
        UpdateCameraRotation();
        MoveUp();
    }

    private void SetCamera()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        _xRotation = transform.eulerAngles.x;
        _yRotation = transform.eulerAngles.y;

        if (_xRotation > 180f)
            _xRotation -= 360f;
    }
    private void UpdateCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * _CamRotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _CamRotationSpeed * Time.deltaTime;

        _xRotation -= mouseY;
        _yRotation += mouseX;

        _xRotation = Mathf.Clamp(_xRotation, _XRotaionMin, _XRotationMax);

        transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0f);
    }
    private void MoveUp()
    {
        if(Input.GetKey(KeyCode.Space) && transform.position.y <= _MaxUp) transform.position += Vector3.up * _CamUpSpeed * Time.deltaTime;
        else if(Input.GetKey(KeyCode.LeftControl) && transform.position.y >= _MinUp) transform.position += -Vector3.up * _CamUpSpeed * Time.deltaTime;
    }
}