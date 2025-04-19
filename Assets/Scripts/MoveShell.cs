using UnityEngine;

public class MoveShell : MonoBehaviour
{
    float speed = 1.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0,Time.deltaTime* (speed/2), Time.deltaTime* speed);
    }
}
