using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour {

    float t1;
    float t2;
    int clickCount = 0;

    float a1;
    float a2;
    int clickCount1 = 0;
    public Transform transforms1;
    public Transform transforms2;
    bool isupdown=false;
    bool isindex = true;
    bool Isworing = false;
    void Start ()
    {
		
	}
	

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        a2 += Time.deltaTime;
        t2 += Time.deltaTime;
        Debug.Log("Isworing:"+ Isworing);
        if (Isworing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isupdown = !isupdown;
        
        }

    }
    void Right()
    {
     
            clickCount1=0;
        print("RighCLickCount"+clickCount);
 
        bool isContain = Input.GetKeyDown(KeyCode.RightArrow);
        if (isContain)
        {
            if (t2 - t1 < 0.5)
            {
                clickCount += 1;
            }
            else
            {
                clickCount = 0;
                t1 = t2;
                return;
            }
            if (clickCount == 6)
            {
                if (isupdown)
                {
                    UpMove();
                    isindex = !isindex;
                }
                else
                {
                    RightMove();
                }
              
                print("右三击");
                clickCount = 0;
            }
            t1 = t2;


        }
    }
    void Left()
    {
      
            clickCount = 0;
        print("LeftCLickCount" + clickCount1);
 
        bool isContain = Input.GetKeyDown(KeyCode.LeftArrow);
        if (isContain)
        {
            if (a2 - a1 < 0.5)
            {
                clickCount1 += 1;
            }
            else
            {
                clickCount1 = 0;
                a1 = a2;
                return;
            }
            if (clickCount1 == 6)
            {
              
                if (isupdown)
                {
                    isindex = !isindex;
                    DowmMove();
                }
                else
                {
                    LeftMove();
                }
                print("左三击");
                clickCount1 = 0;
            }
            a1 = a2;


        }
    }
    void RightMove()
    {
        if (isindex)
        {
            transforms1.DOLocalMove(new Vector3(1920, transforms1.localPosition.y, 0), 1);
        }
        else
        {
            transforms2.DOLocalMove(new Vector3(1920, transforms2.localPosition.y, 0), 1);
        }
      
      
    }
    void LeftMove()
    {
       
        if (isindex)
        {
            transforms1.DOLocalMove(new Vector3(0, transforms1.localPosition.y, 0), 1);
        }
        else
        {
            transforms2.DOLocalMove(new Vector3(0, transforms2.localPosition.y, 0), 1);
        }

    }
    void UpMove()
    {
        Isworing = true;
        transforms1.DOLocalMove(new Vector3(transforms1.localPosition.x, 372, 0), 1).OnComplete(AA);
        transforms2.DOLocalMove(new Vector3(transforms2.localPosition.x, 372, 0), 1);
    }
    void DowmMove()
    {
        Isworing = true;
        transforms1.DOLocalMove(new Vector3(transforms1.localPosition.x, 0, 0), 1);
        transforms2.DOLocalMove(new Vector3(transforms2.localPosition.x, -0, 0), 1).OnComplete(BB);
    }
    void AA()
    {
        Isworing = false;
        transforms1.DOLocalMove(new Vector3(0, transforms1.localPosition.y, 0), 1);
    }
    void BB()
    {
        Isworing = false;
        transforms2.DOLocalMove(new Vector3(0, transforms2.localPosition.y, 0), 1);
    }
}
