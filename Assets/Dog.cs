using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = .5f;

    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("Z", Input.GetAxisRaw("Vertical"));
        transform.Rotate(Vector3.up, Input.GetAxisRaw("Horizontal") * rotationSpeed);
        transform.Translate(((Vector3.forward * Input.GetAxisRaw("Vertical")) * speed) * Time.deltaTime, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Attack");
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
        }
        if (Input.GetMouseButton(1))
        {
            _animator.SetBool("Defend", true);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.right * Time.deltaTime, Space.Self);
        }
        
        
    }
}
