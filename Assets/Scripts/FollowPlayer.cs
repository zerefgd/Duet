using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Transform _playerTransform;

    private Vector3 startPos;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        offset = startPos.y - _playerTransform.position.y;
    }

    private void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.y = _playerTransform.position.y + offset;
        transform.position = temp;
    }

}
