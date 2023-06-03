using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class ProjectileView : MonoBehaviour
{
    #region Events

    public Action<GameObject> ProjectileHit;

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
        _rigidbody.AddForce(transform.up * _speed * Time.deltaTime);
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

    #endregion

    #region Methods

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    #endregion
}
