using Gameplay.Controllers;
using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ILoot
{
    private WeaponModel _model;

    public WeaponController(WeaponModel model)
    {
        _model = model;
    }

    public void ApplyEffect(LevelController levelController, PlayerController playerController)
    {
        playerController.SetCurrentWeapon(_model);
    }

    #region Proprties

    public WeaponModel Model => _model;

    public LootType LootType => LootType.Weapon;

    #endregion
}
