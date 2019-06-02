using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10f;
    public float speedcam = 10f;
    public float jump = 10f;
    public LayerMask GroundLayer;
    public bool IsGrounded;
    public GameObject Weapon;

    float horizontal = 0;
    float up = 0;

    private CircleCollider2D _lowerFootCollider;
    private Animator _animator;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _lowerFootCollider = this.GetComponent<CircleCollider2D>();
    }


    void FixedUpdate()
    {

        IsGrounded = Physics2D.OverlapCircle(_lowerFootCollider.transform.position, _lowerFootCollider.radius + 1f, GroundLayer);

        Debug.Log(IsGrounded);

        horizontal = Mathf.Lerp(horizontal, Input.GetAxis("Horizontal"), Time.deltaTime * 8);
        up = Mathf.Lerp(up, Input.GetAxis("Jump"), Time.deltaTime * 8);

        if (!IsGrounded)
        {
            up = 0;
        }

        Vector3 direction = new Vector3(horizontal, up, 0);
        direction = transform.TransformDirection(direction);
        direction *= speed * Time.deltaTime;

        GetComponent<Rigidbody2D>().MovePosition(transform.position + direction);

        bool isKeyDown1 = false;
        bool isKeyDown = false;
        if (Input.GetKey(KeyCode.D))
        {
            isKeyDown = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isKeyDown = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isKeyDown1 = true;
        }

        _animator.SetBool("IsKeyDown1", isKeyDown1);
        _animator.SetBool("IsKeyDown", isKeyDown);


        if(Input.GetKey(KeyCode.F))
        {
            Instantiate(this.Weapon, this.transform.position, new Quaternion());
        }
    }
}
