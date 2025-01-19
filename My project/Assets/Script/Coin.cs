using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 pos;
    private bool ismove = false;
    private void Start()
    {
        pos = new Vector3(5.73f, 5.08f, 1.23f);
        Invoke("move", 2);
        //Invoke("Destroy", 4);
    }
    private void move()
    {
        ismove = true;
    }
    private void Update()
    {
        if (ismove)
        {
            transform.position = Vector3.Lerp(transform.position, pos, 0.04f);
        }
    }

    private void Destroy()
    {
        Destroy(transform.parent);
    }
}
