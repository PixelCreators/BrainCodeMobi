using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private new Animator animator;
    public ButtonScript left;
    public ButtonScript right;

    public float speed = 2.0f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        animator.SetBool("Left", left.isHoldDown);
        animator.SetBool("Right", right.isHoldDown);

        if (left.isHoldDown)
            rigidbody2D.position = new Vector2(rigidbody2D.position.x - speed * Time.deltaTime, rigidbody2D.position.y);

        if (right.isHoldDown)
            rigidbody2D.position = new Vector2(rigidbody2D.position.x + speed * Time.deltaTime, rigidbody2D.position.y);
    }
}