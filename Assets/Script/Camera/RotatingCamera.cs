using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    private Vector3 deltaPosition;
    
    public GameObject player;

    private void Start()
    {
        deltaPosition = this.transform.position - player.transform.position;
    }

    void Update()
    {
        this.transform.position = player.transform.position + deltaPosition;
    }
}
