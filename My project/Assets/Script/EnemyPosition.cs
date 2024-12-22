using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    public SpuwnEnemy spuwnEnemy;
    public GameObject Enviroment;
    private Enemy enemy;
    private Fight fight;
    public PlatformPosition ParentlatformPosition;
    public int SwordOrArrow;

    private void OnEnable()
    {
        EventManager.offRaycastColission += ChangeLayer;
    }
    private void OnDisable()
    {
        EventManager.offRaycastColission -= ChangeLayer;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        fight = GetComponent<Fight>();
    }
    public void ChangeLayer(int layer)
    {
        gameObject.layer = layer;
    }
    public void Take()
    {

    }
    public void Fixed()
    {
        RaycastHit hitDown;
        Physics.Raycast(transform.position, Vector3.down, out hitDown, 5);

        if (hitDown.transform.gameObject.tag == "Arena")
        {
            transform.position = hitDown.point;
            transform.parent = Enviroment.transform;
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            spuwnEnemy.AddPlayerEnemy(gameObject);

            fight.enabled = true;
        }
        else if (hitDown.transform.gameObject.tag == "Platforma")
        {
            if (hitDown.transform.gameObject.GetComponent<PlatformPosition>().Child == null || hitDown.transform.gameObject.GetComponent<PlatformPosition>().Child == transform.gameObject)
            {
                ParentlatformPosition.Child = null;
                transform.position = hitDown.transform.position;
                transform.parent = hitDown.transform;
                hitDown.transform.gameObject.GetComponent<PlatformPosition>().Child = transform.gameObject;
                ParentlatformPosition = hitDown.transform.gameObject.GetComponent<PlatformPosition>();
            }
            else
            {
                if (hitDown.transform.gameObject.GetComponent<PlatformPosition>().Child.GetComponent<EnemyPosition>().SwordOrArrow == SwordOrArrow)
                {
                    if(hitDown.transform.gameObject.GetComponent<PlatformPosition>().Child.GetComponent<Enemy>().lvl == enemy.lvl)
                    {
                        enemy.SetNewLvL();
                        Destroy(hitDown.transform.gameObject.GetComponent<PlatformPosition>().Child);

                        ParentlatformPosition.Child = null;
                        transform.position = hitDown.transform.position;
                        transform.parent = hitDown.transform;
                        hitDown.transform.gameObject.GetComponent<PlatformPosition>().Child = transform.gameObject;
                        ParentlatformPosition = hitDown.transform.gameObject.GetComponent<PlatformPosition>();
                    }
                    else
                    {
                        transform.localPosition = Vector3.zero;
                    }
                }
                else
                {
                    transform.localPosition = Vector3.zero;
                }
            }
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
