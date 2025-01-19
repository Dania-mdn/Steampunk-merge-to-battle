using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController2 : MonoBehaviour
{
    public Bot SFight;
    private Animation Anim;
    private void Start()
    {
        Anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (SFight == null)
        {
            Anim.Play("mixamo.com 3");
            Invoke("Death", 2);
        }
        else 
        {
            if(SFight.enabled == true)
            {
                if (SFight.speed > 0)
                {
                    Anim.Play("mixamo.com 5");
                }
                else
                {
                    Anim.Play("mixamo.com 4");
                }
            }
        } 
    }
    private void Death()
    {
        Destroy(transform.parent.gameObject);
    }
}
