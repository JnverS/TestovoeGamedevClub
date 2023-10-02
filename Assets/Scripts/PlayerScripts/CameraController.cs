using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 dampOffset;
    public float smooth;
    public Transform target;
    private Vector3 _vel = Vector3.zero;
    private Transform _camera;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float botLimit;
    [SerializeField]
    float upLimit;
    void Start()
    {
        _camera = GetComponent<Transform>();
        _camera.position = target.position + dampOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        _camera.position = Vector3.SmoothDamp(_camera.position,
            new Vector3(target.position.x, target.position.y,
            0) + dampOffset, ref _vel, smooth);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
           Mathf.Clamp(transform.position.y, botLimit, upLimit), transform.position.z);
    }
}
