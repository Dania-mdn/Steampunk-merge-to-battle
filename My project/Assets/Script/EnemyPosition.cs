using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    private Vector3 StartPosition;
    private void Start()
    {
        StartPosition = this.transform.position;
    }
    public void Take()
    {

    }
    public void Fixed()
    {
        RaycastHit hitDown;
        Physics.Raycast(transform.position, Vector3.down, out hitDown, 5);

        if(hitDown.transform.gameObject.tag == "Arena")
        {
            transform.position = hitDown.point;
            transform.parent = hitDown.transform;
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if(hitDown.transform.gameObject.tag == "Platforma")
        {
            transform.position = hitDown.transform.position;
            transform.parent = hitDown.transform;
        }
        else
        {
            transform.position = StartPosition;
        }
    }
}
