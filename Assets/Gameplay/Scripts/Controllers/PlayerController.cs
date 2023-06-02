using Gameplay.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerModel _model;

    //[SerializeField]
    //private WeaponView weaponView;

    [SerializeField]
    private WeaponModel _testWeaponModel;

    private void Start()
    {
    }

    [ContextMenu("Test/On Player Collision With Weapon Loot")]
    public void OnPlayerCollideWithWeaponLoot() //WeaponLootView weaponLootView)
    {
        //_model.CollectWeaponLoot(weaponLootView.Model);
        _model.SetCurrentWeapon(_testWeaponModel);
    }

    //private void CollectLoot(WeaponLootModel weaponLoot)
    //{
    //    weaponLoot.ApplyEffect();
    //}
}
