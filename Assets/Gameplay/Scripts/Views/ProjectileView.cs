using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class ProjectileView : MonoBehaviour
{
    #region Events

    public Action<ProjectileView, GameObject, Vector2> ProjectileHit;

    #endregion

    #region Private Fields

    private Rigidbody2D _rigidbody;

    private float _speed;

    #endregion

    #region Unity callbacks

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rigidbody.AddForce(new Vector2(0f, _speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.collider;
        if (other.CompareTag("Player") || other.CompareTag("Projectile"))
        {
            return;
        }

        var xHit = collision.contacts[0].point.x;
        var yHiy = collision.contacts[0].point.y;

        ProjectileHit?.Invoke(this, other.gameObject, new Vector2(xHit, yHiy));
    }

    #endregion

    #region Methods

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    #endregion
}
