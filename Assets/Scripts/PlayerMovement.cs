using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed, _moveSpeed;

    private float horizontalInput;

    private void Update()
    {
        Vector3 mousePos = Input.GetMouseButton(0) ? Camera.main.ScreenToWorldPoint(Input.mousePosition) : Vector3.zero;
        horizontalInput = mousePos.x > 0.05f ? 1 : mousePos.x < -0.05f  ? -1f : 0f;
    }

    private void FixedUpdate()
    {
        Vector3 angles = transform.rotation.eulerAngles;
        angles.z -= _rotationSpeed * horizontalInput * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(angles);
        transform.position += _moveSpeed * Time.fixedDeltaTime * Vector3.up;
    }
}
