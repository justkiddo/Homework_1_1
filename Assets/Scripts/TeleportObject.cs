using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    [SerializeField] private float secondsToTp;
    [SerializeField] private Vector3 positionToTp;
    void Update()
    {
        var a = Vector3.Lerp(transform.position, positionToTp, secondsToTp * Time.deltaTime);
        transform.Translate(a);
    }
}
