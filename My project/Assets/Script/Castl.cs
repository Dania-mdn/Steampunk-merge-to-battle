using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Castl : MonoBehaviour
{
    public GameObject Platforma;

    public PlatformPosition[] PositionPlatform;
    public GameObject SwordEnemy;
    public GameObject ArrowEnemy;

    private RaycastHit hit;
    private GameObject Mediate;
    private GameObject TargetUpgrade;
    private Ray ray;

    private void Start()
    {
        Platforma.SetActive(false);
    }
    public void StartGame()
    {
        Platforma.SetActive(true);
        EventManager.DoStartGame();
    }
    public void SpuwnSword()
    {
        for (int i = 0; i < PositionPlatform.Length; i++)
        {
            if (PositionPlatform[i].Child == null)
            {
                PositionPlatform[i].Child = Instantiate(SwordEnemy, PositionPlatform[i].transform.position, Quaternion.identity, PositionPlatform[i].transform);
                break;
            }
        }
    }
    public void SpuwnArrow()
    {
        for (int i = 0; i < PositionPlatform.Length; i++)
        {
            if (PositionPlatform[i].Child == null)
            {
                PositionPlatform[i].Child = Instantiate(ArrowEnemy, PositionPlatform[i].transform.position, Quaternion.identity, PositionPlatform[i].transform);
                break;
            }
        }
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (Mediate != null)
            Mediate.transform.position = hit.point + Mediate.transform.up / 5;
    }
    public void PointerDown()
    {
        if(hit.transform.gameObject.tag == "Enemy")
        {
            Mediate = hit.transform.gameObject; 
            Mediate.GetComponent<EnemyPosition>().Take();
        }
    }
    public void PointerUp()
    {
        Mediate.GetComponent<EnemyPosition>().Fixed();
        Mediate = null;
    }
}
