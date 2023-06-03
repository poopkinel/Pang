using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefabRef;

    [SerializeField]
    private Transform _projectileParent;

    [SerializeField]
    private float _playerMoveSpeed;

    private Rigidbody2D _rigidbody;


    #region Unity Callbacks

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    #endregion

    #region Methods

    public void Fire()
    {
        Instantiate(_projectilePrefabRef, transform.position, Quaternion.identity, _projectileParent);
    }

    public void MoveHorizontal(float horizontalAxis)
    {
        var moveForce = horizontalAxis * _playerMoveSpeed * Time.deltaTime;
        //_rigidbody.AddForce(new Vector2(moveForce, 0));
        transform.Translate(new Vector2(moveForce, 0));
    }

    [ContextMenu("Test/Move left")]
    public void MoveHorizontalLeft()
    {
        var moveForce = -1f * _playerMoveSpeed * Time.deltaTime;
        _rigidbody.AddForce(new Vector2(moveForce, 0));
    }
    
    [ContextMenu("Test/Move left")]
    public void MoveHorizontalRight()
    {
        var moveForce = 1f * _playerMoveSpeed * Time.deltaTime;
        _rigidbody.AddForce(new Vector2(moveForce, 0));
    }

    [ContextMenu("Test/Shoot Projectile")]
    private void TestFire()
    {
        Instantiate(_projectilePrefabRef, transform.position, Quaternion.identity, _projectileParent);
    }

    #endregion
}
