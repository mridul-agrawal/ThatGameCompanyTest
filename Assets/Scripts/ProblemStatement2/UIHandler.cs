using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class is responsible for updating the weapon Slots UI and display weapon ammo accurately.
/// </summary>
public class UIHandler : SingletonGeneric<UIHandler>
{
    public Sprite PrimaryWeapon1Sprite;
    public TextMeshProUGUI AmmoTextPW1;
    public Sprite PrimaryWeapon2Sprite;
    public TextMeshProUGUI AmmoTextPW2;
    public Sprite SecondaryWeaponSprite;
    public TextMeshProUGUI AmmoTextSW;

    // This method takes a weapon as an input and updates the weapon slot UI accordinglly.
    public void UpdateWeaponUI(WeaponController weapon)
    {
        if(weapon.Model.SlotType == WeaponSlotType.PrimaryWeapon1)
        {
            PrimaryWeapon1Sprite = weapon.Model.WeaponSprite;
        }
        else if (weapon.Model.SlotType == WeaponSlotType.PrimaryWeapon2)
        {
            PrimaryWeapon2Sprite = weapon.Model.WeaponSprite;
        }
        else if (weapon.Model.SlotType == WeaponSlotType.SecondaryWeapon)
        {
            SecondaryWeaponSprite = weapon.Model.WeaponSprite;
        } 
        else if(weapon.Model.SlotType == WeaponSlotType.None)
        {

        }
    }

    // Deletes a weapon reference from the weapon slots UI.
    public void DeleteUIReference(WeaponController weapon)
    {
        if (weapon.Model.SlotType == WeaponSlotType.PrimaryWeapon1)
        {
            PrimaryWeapon1Sprite = null;
            AmmoTextPW1.text = "";
        }
        else if (weapon.Model.SlotType == WeaponSlotType.PrimaryWeapon2)
        {
            PrimaryWeapon2Sprite = null;
            AmmoTextPW2.text = "";
        }
        else if (weapon.Model.SlotType == WeaponSlotType.SecondaryWeapon)
        {
            SecondaryWeaponSprite = null;
            AmmoTextSW.text = "";
        }
    }

    // Updates Ammo UI for a given weapon.
    public void UpdateAmmoUI(WeaponController weapon)
    {
        if(weapon.Model.SlotType == WeaponSlotType.PrimaryWeapon1)
        {
            AmmoTextPW1.text = weapon.Model.AmmoInMag.ToString() + "/" + weapon.Model.Ammo.ToString();
        } 
        else if(weapon.Model.SlotType == WeaponSlotType.PrimaryWeapon2)
        {
            AmmoTextPW2.text = weapon.Model.AmmoInMag.ToString() + "/" + weapon.Model.Ammo.ToString();
        } 
        else if(weapon.Model.SlotType == WeaponSlotType.SecondaryWeapon)
        {
            AmmoTextSW.text = weapon.Model.AmmoInMag.ToString() + "/" + weapon.Model.Ammo.ToString();
        }
    }

}
