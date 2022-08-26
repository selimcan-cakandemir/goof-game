using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] [Range(1, 10)] private float _gravityModifier = 1;

    [SerializeField] [Range(1, 20)] private float _jumpForce;

    [SerializeField] [Range(1, 2)] private float _jumpForceMagnifier;

    private float _gravity = -9.81f;
    private float _velocity;

    private float ground;
    private bool isGrounded = true;

    private float buttonHeldTime;

    private Animator _animator;

    void Start() {
        ground = transform.localPosition.y;
        _animator = GetComponent<Animator>();
    }
    
    void Update() {
        
        // Check if you hit an enemy
        
        var all = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach(var hit in all)
        {
            if (hit.transform.gameObject.CompareTag("Enemy")) {
                StartScript.Instance.GameOver();
            }
        }

        Vector3 pos = transform.localPosition;

        // Check if on ground

        if (pos.y == ground)
        {
            isGrounded = true;
            _animator.SetBool("isGrounded", true);
        }

        // If high above ground apply gravity

        if (pos.y > ground)
        {
            _velocity += _gravity * Time.deltaTime * _gravityModifier;
            isGrounded = false;
            _animator.SetBool("isGrounded", false);

        }
        else
        {

            // Make sure you are directly on the ground

            _velocity = 0;
            pos.y = ground;
            transform.localPosition = pos;
        }

        // Add jump velocity depending on how long you hold the button down

        if (Input.GetButton("Jump"))
        {

            buttonHeldTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            if (buttonHeldTime > 0.1f)
            {
                _velocity = _jumpForce * _jumpForceMagnifier;
            }
            else
            {
                _velocity = _jumpForce;
            }

            buttonHeldTime = 0;

            _animator.Play("Goof Jumping Animation");
        }


        // Apply velocity

        transform.Translate(new Vector3(0, _velocity, 0) * Time.deltaTime);

    }
}
