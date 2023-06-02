using Gameplay.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _model;

    [SerializeField]
    private LevelController _levelController;

    //[SerializeField]
    //private WeaponView weaponView;

    [SerializeField]
    private WeaponModel _testWeaponModel;

    private void Start()
    {
    }

    [ContextMenu("Test/On Player Collision With Weapon Loot")]
    public void OnPlayerCollideWithWeaponLoot(ILoot loot)
    {
        loot.ApplyEffect(_levelController.Model, _model);
    }

    //private void CollectLoot(WeaponLootModel weaponLoot)
    //{
    //    weaponLoot.ApplyEffect();
    //}
}
