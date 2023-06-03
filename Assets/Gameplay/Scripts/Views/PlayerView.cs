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

    private Rigidbody2D _rigidbody;

    private float _playerMoveSpeed;

    public void Fire()
    {
        Instantiate(_projectilePrefabRef, transform.position, Quaternion.identity, _projectileParent);
    }

    public void MoveHorizontal(float horizontalAxis)
    {
        var moveForce = horizontalAxis * _playerMoveSpeed * Time.deltaTime;
        _rigidbody.AddForce(new Vector2(moveForce, 0));
    }

    [ContextMenu("Test/Shoot Projectile")]
    private void TestFire()
    {
        Instantiate(_projectilePrefabRef, transform.position, Quaternion.identity, _projectileParent);
    }
}
