using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // follows object
    [SerializeField] private GameObject _objectToFollow;

    private void LateUpdate()
    {
        transform.position = new Vector3(_objectToFollow.transform.position.x, _objectToFollow.transform.position.y, -10f);
    }
}
