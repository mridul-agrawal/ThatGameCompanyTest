using UnityEngine;

/// <summary>
/// This class is responsible for handling the logic for a weapon. It uses weapon data from WeaponModel and handles the logic for Input recieved.
/// </summary>
public class WeaponController
{
    public WeaponModel Model { get; }
    public WeaponView View { get; }

    public WeaponController(WeaponView weaponPrefab, WeaponModel weaponModel)
    {
        Model = weaponModel;
        View = GameObject.Instantiate<WeaponView>(weaponPrefab);
    }

    // This method will update weapon ammo data & UI and will also communicate with Bullet Service to Fire a Bullet.
    public void Fire()
    {
        if(Model.AmmoInMag > 0)
        {
            Model.AmmoInMag--;
            UIHandler.Instance.UpdateAmmoUI(this);
            // Will order the BulletService to Fire a bullet with respect to this weapon's position.
        }
    }

    // This method will reload this weapon and update ammo data & UI.
    public void Reload()
    {
        if(Model.Ammo >= Model.MagazineSize - Model.AmmoInMag)
        {
            Model.Ammo = Model.MagazineSize - Model.AmmoInMag;
            Model.AmmoInMag = Model.MagazineSize;
        } else
        {
            Model.AmmoInMag = Model.Ammo;
            Model.Ammo = 0;
        }
        UIHandler.Instance.UpdateAmmoUI(this);
    }
}
