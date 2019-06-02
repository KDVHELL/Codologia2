using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float Speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.right * Time.deltaTime * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
