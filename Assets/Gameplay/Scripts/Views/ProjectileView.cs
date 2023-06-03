using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class ProjectileView : MonoBehaviour
{
    public Action<GameObject> ProjectileHit;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.otherCollider;
        if (other.CompareTag("Player"))
        {
            return;
        }

        ProjectileHit?.Invoke(other.gameObject);

        Destroy(gameObject);
    }
}
