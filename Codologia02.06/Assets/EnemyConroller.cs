using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller : MonoBehaviour
{
    public GameObject leftBound;
    
    public GameObject RightBound;

    public float Speed = 0.5f;

    bool isGoingLeft;
    bool isGoingRight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float leftBoundDist = Mathf.Abs(this.transform.position.x - leftBound.transform.position.x);
        float rightBoundDist = Mathf.Abs(this.transform.position.x - RightBound.transform.position.x);

        if (isGoingLeft)
        {
            if (Mathf.Approximately(leftBoundDist, 0))
            {
                isGoingLeft = false;
            }
            this.transform.position = Vector2.MoveTowards(
                                            this.transform.position,
                                            leftBound.transform.position,
                                            Speed);
        }
        else
        {
            this.transform.position = Vector2.MoveTowards(
                                               this.transform.position,
                                               RightBound.transform.position,
                                               Speed);

        }

    }
}
