using UnityEngine;

public class IncreaseDecreaseObject : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float change = 0.001f;
    void Update()
    {
        if (Input.GetMouseButton(0))  // left click increase
        {
            transform.localScale += new Vector3(change, change, change) * speed;
        }
        else if (Input.GetMouseButton(1))  // right click decrease
        {
            transform.localScale -= new Vector3(change, change, change) * speed ;
        }
        
        // как выставить ограничения ???
    }
}
