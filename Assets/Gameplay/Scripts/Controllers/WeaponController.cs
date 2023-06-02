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

    public void ApplyEffect(LevelModel levelModel, PlayerModel playerModel)
    {
        playerModel.SetCurrentWeapon(_model);
    }
}
