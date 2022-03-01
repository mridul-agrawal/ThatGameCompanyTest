using UnityEngine;

public class WeaponController
{
    public WeaponModel Model { get; }
    public WeaponView View { get; }

    public WeaponController(WeaponView weaponPrefab, WeaponModel weaponModel)
    {
        Model = weaponModel;
        View = GameObject.Instantiate<WeaponView>(weaponPrefab);
    }

    public void Fire()
    {
        if(Model.AmmoInMag > 0)
        {
            Model.AmmoInMag--;
            UIHandler.Instance.UpdateAmmoUI(this);
            // Fire a Bullet.
        }
    }

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
