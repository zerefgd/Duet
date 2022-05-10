using System.Collections;
using UnityEngine;

public class BoxRotate : MonoBehaviour
{
    [SerializeField]
    private float _delay, _rotationSpeed, _playerSpeed, _startOffset;

    // Start is called before the first frame update
    void Start()
    {
        float offset = _delay + _startOffset;
        _delay = offset / _playerSpeed;
        _delay -= (630f / _rotationSpeed);
        _delay %= (360f / _rotationSpeed);

        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(_delay);

        while(true)
        {
            transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
