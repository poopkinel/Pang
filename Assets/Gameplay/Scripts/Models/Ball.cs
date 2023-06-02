using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ball
{
    public static int lastId = 0;

    #region Editor

    [SerializeField]
    private int _id;

    [SerializeField]
    private int _hitsLeft;

    [SerializeField]
    private Vector2 _spawnPosition;

    #endregion

    #region Constructor

    public Ball(int id, int hitsLeft, Vector2 SpawnPoint)
    {
        _id = id;
        _hitsLeft = hitsLeft;
        _spawnPosition = SpawnPoint;
    }

    #endregion

    #region Methods

    public void Hit()
    {
        _hitsLeft--;
    }

    #endregion

    #region Properties

    public int Id => _id;

    public int HitsLeft => _hitsLeft;

    public bool IsSmallest => _hitsLeft <= 0;

    #endregion
}
