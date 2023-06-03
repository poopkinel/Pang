using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefabRef;

    [SerializeField]
    private Transform _projectileParent;

    [ContextMenu("Test/Shoot Projectile")]
    private void TestShoot()
    {
        Instantiate(_projectilePrefabRef, transform.position, Quaternion.identity, _projectileParent);
    }
}
