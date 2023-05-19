using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] private Transform camera;
    void Update()
    {
        transform.position = new Vector3(camera.position.x + 3, camera.position.y + 1.6f, camera.position.z);

    }
}
