﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private new Animator animator;
    private LevelManager levelManager;
    public ButtonScript left;
    public ButtonScript right;
    public GameObject firePrefab;
    public AudioClip getSound;
    public AudioClip boomDieSound;
    public GameObject plusOneParticle; 

    private bool notPlayedMusicYet = true;
    public float speed = 2.0f;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
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


        if (levelManager.GameOver)
        {
            animator.SetBool("Die", true);
            if (notPlayedMusicYet)
            {
                AudioSource.PlayClipAtPoint(boomDieSound, Vector3.zero);
                notPlayedMusicYet = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Target")
        {
            AudioSource.PlayClipAtPoint(getSound, Vector3.zero);
            other.gameObject.GetComponentInParent<HouseController>().isTarget = false;
            levelManager.AddPoints(1);
            Instantiate(plusOneParticle, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject); 
        }
        if(other.gameObject.tag == "Rocket")
        {
            levelManager.Lives = 0;
        }
    }

    public IEnumerator InverseAxis(float time)
    {
        ButtonScript tmp = left;
        left = right;
        right = tmp;

        yield return new WaitForSeconds(time);

        tmp = left;
        left = right;
        right = tmp;
    }
}