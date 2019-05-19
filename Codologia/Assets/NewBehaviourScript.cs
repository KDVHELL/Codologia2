using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private Animator _animator;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }


    void Update()
    {
        bool isKeyDown1 = false;
        bool isKeyDown = false;
        if (Input.GetKey(KeyCode.D))
        {
            isKeyDown = true;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            isKeyDown1 = true;
        }

        _animator.SetBool("IsKeyDown1", isKeyDown1);
        _animator.SetBool("IsKeyDown", isKeyDown);
    }
}
