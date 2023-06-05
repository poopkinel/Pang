using Gameplay.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Views
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerView : MonoBehaviour
    {
        #region Events

        public Action CollideWithBall;

        public Action<GameObject> CollideWithLoot;

        #endregion

        #region Editor

        [SerializeField]
        private GameObject _projectilePrefabRef;

        [SerializeField]
        private Transform _projectileParent;

        [SerializeField]
        private float _playerMoveSpeed;

        [SerializeField]
        private Canvas _gameplayCanvas;

        private RectTransform _playerRectTrn;

        #endregion

        #region Private Fields

        private Rigidbody2D _rigidbody;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerRectTrn = GetComponent<RectTransform>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ball"))
            {
                CollideWithBall?.Invoke();
            }

            else if (collision.collider.CompareTag("Loot"))
            {
                Debug.Log($"collider with loot");
                CollideWithLoot?.Invoke(collision.gameObject);
            }
        }

        #endregion

        #region Methods

        public GameObject CreateProjectile(GameObject weaponPrefab)
        {
            return Instantiate(weaponPrefab, transform.position, Quaternion.identity, _projectileParent);
        }

        public void MoveHorizontal(float horizontalAxis)
        {
            var moveForce = horizontalAxis * _playerMoveSpeed * Time.deltaTime;

            var moveLeft = moveForce < 0;

            var padding = _playerRectTrn.sizeDelta.x;

            bool moveLeftLegal = transform.position.x > _gameplayCanvas.pixelRect.xMin + padding;
            bool moveRighLegal = transform.position.x < _gameplayCanvas.pixelRect.xMax - padding;

            if (moveLeft && moveLeftLegal)
            { 
                _playerRectTrn.Translate(new Vector2(moveForce, 0));
            }
            else if (!moveLeft && moveRighLegal)
            {
                _playerRectTrn.Translate(new Vector2(moveForce, 0));
            }
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
}