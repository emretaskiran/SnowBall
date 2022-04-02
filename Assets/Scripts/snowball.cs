using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snowball : MonoBehaviour
{
    public float ileriGitmeHizi;
    public float sagaSolaGitmeHizi;
    public float rotationSpeed;
    int count;
    public Text skor_txt;
    public GameObject bitis_cizgisi;
    public GameObject bitti_pnl;

    

    float scalesize;
    float xPos;
    float zPos;

    public GameObject[] engeller;
    void Start()
    {
        count = 0;
        scalesize = 0.1f;
        InvokeRepeating("SpawnEngel", 0, 1.8f);

    }

    void Update()
    {
        zPos += ileriGitmeHizi * Time.deltaTime;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                xPos += touch.deltaPosition.x * Time.deltaTime * sagaSolaGitmeHizi;
            }
        }

        transform.position = new Vector3(xPos, transform.position.y, zPos);

        if (xPos > 12f)
        {
            xPos = 12f;
        }
        else if (xPos < -10f)
        {
            xPos = -10f;
        }

        skor_txt.text = "SKOR: " + count * 100;


        this.transform.localScale = this.transform.localScale + new Vector3(scalesize, scalesize, scalesize)*Time.deltaTime;
        this.transform.Rotate(1*rotationSpeed, 0, 0);
        //transform.RotateAroundLocal(Vector3.right, rotationSpeed * Time.deltaTime);


        //Vector3 pos = new Vector3(Random.Range(-24, -10), 10, 20);
        //Instantiate(EngelPrefabs, pos,transform.rotation);

        //GameObject Engel = Instantiate(EngelPrefabs,);
        //EngelPrefabs.transform.position = new Vector3(Random.Range(-24f, -10f), 10.33999f, zPos+60f);

    }

    void SpawnEngel()
    {
        GameObject Engel = Instantiate(engeller[Random.Range(0,3)]);
        Engel.transform.position = new Vector3(Random.Range(-4f, 6f), 0f, zPos + 100f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Engel")
        {
            this.transform.localScale = this.transform.localScale - new Vector3(1f, 1f, 1f);
            other.tag = "Untagged";
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "KarTopu")
        {
            count++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            ileriGitmeHizi = 0;
            sagaSolaGitmeHizi = 0;
            scalesize = 0;
            rotationSpeed = 0;
            bitti_pnl.SetActive(true);
        }
    }






}
