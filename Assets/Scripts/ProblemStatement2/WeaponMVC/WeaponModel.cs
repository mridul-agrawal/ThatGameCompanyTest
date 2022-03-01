using UnityEngine;

/// <summary>
/// This class loads weapon data from Scriptable Objects and is responsible for storing and handling the data.
/// </summary>
public class WeaponModel 
{
    public WeaponModel(WeaponSO weaponSO)
    {
        Type = weaponSO.type;
        Ammo = weaponSO.ammo;
        MagazineSize = weaponSO.magazineSize;
        FireRate = weaponSO.fireRate;
        Damage = weaponSO.damage;
        WeaponSprite = weaponSO.weaponSprite;
        AmmoInMag = MagazineSize;
        weaponSO.slotType = WeaponSlotType.None;
        SlotType = weaponSO.slotType;
    }

    public WeaponType Type { get; }
    public int Ammo { get; set; }
    public int MagazineSize { get; }
    public int FireRate { get; }
    public int Damage { get; }
    public Sprite WeaponSprite { get; }
    public int AmmoInMag { get; set; }
    public WeaponSlotType SlotType { get; set; }
}
