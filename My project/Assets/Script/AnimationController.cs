using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public AFight AFight;
    private Animation Anim;
    private void Start()
    {
        Anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (AFight == null)
        {
            Anim.Play("mixamo.com 3");
            Invoke("Death", 2);
        }
        else 
        {
            if(AFight.enabled == true)
            {
                if (AFight.speed > 0)
                {
                    Anim.Play("mixamo.com 1");
                }
                else
                {
                    Anim.Play("mixamo.com 2");
                }
            }
        } 
    }
    private void Death()
    {
        Destroy(transform.parent.gameObject);
    }
}
