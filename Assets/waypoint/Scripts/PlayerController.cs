using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _playerRigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float _moveHorizontal;
    private float _moveVertical;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");
    }


    void FixedUpdate()
    {
        Vector2 movement = new Vector2(_moveHorizontal, _moveVertical);

        _playerRigidbody.AddForce(movement * speed);

        //Animations
        bool isWalking = _playerRigidbody.linearVelocity.magnitude > 0.5f;
        animator.SetBool("isWalking", isWalking);

        if (!Mathf.Approximately(0f, _playerRigidbody.linearVelocity.x))
        {
            bool isRight = _playerRigidbody.linearVelocity.x > 0f;
            spriteRenderer.flipX = !isRight;
        }
    }
}
