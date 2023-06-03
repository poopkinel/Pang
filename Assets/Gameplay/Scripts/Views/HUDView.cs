using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _lives;
       
    [SerializeField]
    private TMP_Text _score;
           
    [SerializeField]
    private TMP_Text _weapon;

    public void SetLivesText(int lives)
    {
        _lives.text = lives.ToString();
    }

    public void SetScoreText(int score)
    {
        _score.text = score.ToString();
    }

    public void SetWeaponText(string weaponName)
    {
        _weapon.text = weaponName;
    }
}
