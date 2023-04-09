using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform positionToMove;
    //[SerializeField] private Transform positionToMoveAfter;
    [SerializeField] private float speed = 0;
    private Vector3 _transformPosition;
    private float _deltaTime;
    
    void Awake()
    {
        _deltaTime = 0;
        _transformPosition = transform.position;
    }

    void Update()
    {
        _deltaTime += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(_transformPosition, positionToMove.position, _deltaTime);
        if (_deltaTime>=1)
        {
            _deltaTime = 0;
        }
        /*if (transform.position == positionToMove.position)
          {
          transform.position = Vector3.Lerp(_transformPosition, positionToMoveAfter.position, _deltaTime);
          }*/
        
        
    }
}
