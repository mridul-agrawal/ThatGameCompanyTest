using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSO : ScriptableObject
{
    public WeaponType type;
    public WeaponSlotType slotType;
    public Sprite weaponSprite;
    public int ammo;
    public int magazineSize;
    public int fireRate;
    public int damage;
}
