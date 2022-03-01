using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private WeaponController primaryWeapon1;
    private WeaponController primaryWeapon2;
    private WeaponController secondaryWeapon;
    private WeaponController equippedWeapon;
    private int health;

    void Start()
    {
        InitializePlayer();
        SubscribeToEvents();
    }

    private void InitializePlayer()
    {
        primaryWeapon1 = null;
        primaryWeapon2 = null;
        secondaryWeapon = null;
        equippedWeapon = null;
    }

    private void SubscribeToEvents()
    {
        InputManager.OnPickWeaponInput += PickWeapon;
        InputManager.OnDropWeaponInput += DropWeapon;
        InputManager.OnSwitchWeaponInput += SwitchWweapon;
        InputManager.OnAttackInput += Attack;
        InputManager.OnReloadInput += ReloadEquippedWeapon;
    }

    private void PickWeapon(WeaponController weaponToBePicked)
    {
        if(weaponToBePicked.Model.Type == WeaponType.Primary)
        {
            PickUpSecondaryWeapon(weaponToBePicked);
        } 
        else if(weaponToBePicked.Model.Type == WeaponType.Secondary)
        {
            PickUpPrimaryWeapon(weaponToBePicked);
        }

        if(equippedWeapon == null)
        {
            equippedWeapon = weaponToBePicked;
        }

        UIHandler.Instance.UpdateWeaponUI(weaponToBePicked);
    }

    private void PickUpPrimaryWeapon(WeaponController weaponToBePicked)
    {
        if (primaryWeapon1 == null)
        {
            primaryWeapon1 = weaponToBePicked;
            weaponToBePicked.Model.SlotType = WeaponSlotType.PrimaryWeapon1;

        }
        else if (primaryWeapon2 == null)
        {
            primaryWeapon2 = weaponToBePicked;
            weaponToBePicked.Model.SlotType = WeaponSlotType.PrimaryWeapon2;
        }
        else
        {
            DropWeapon(primaryWeapon1);
            primaryWeapon1 = weaponToBePicked;
            weaponToBePicked.Model.SlotType = WeaponSlotType.PrimaryWeapon1;
        }
    }

    private void PickUpSecondaryWeapon(WeaponController weaponToBePicked)
    {
        if(secondaryWeapon == null)
        {
            secondaryWeapon = weaponToBePicked;
            weaponToBePicked.Model.SlotType = WeaponSlotType.SecondaryWeapon;
        } else
        {
            DropWeapon(secondaryWeapon);
            secondaryWeapon = weaponToBePicked;
            weaponToBePicked.Model.SlotType = WeaponSlotType.SecondaryWeapon;
        }
    }

    private void DropWeapon(WeaponController weaponToDrop)
    {
        if(equippedWeapon == weaponToDrop)
        {
            equippedWeapon = null;
        }

        if(primaryWeapon1 == weaponToDrop)
        {
            primaryWeapon1 = null;
        } else if(primaryWeapon2 == weaponToDrop)
        {
            primaryWeapon2 = null;
        } else if(secondaryWeapon == weaponToDrop)
        {
            secondaryWeapon = null;
        }
        UIHandler.Instance.DeleteUIReference(weaponToDrop);
        weaponToDrop.Model.SlotType = WeaponSlotType.None;
    }

    private void SwitchWweapon(WeaponController weaponToEquip)
    {
        equippedWeapon = weaponToEquip;
    }

    private void Attack()
    {
        if(equippedWeapon != null)
        {
            equippedWeapon.Fire();
        }
        else
        {
            MeleeAttack();
        }
    }

    private void MeleeAttack()
    {

    }

    private void ReloadEquippedWeapon()
    {
        if (equippedWeapon != null) equippedWeapon.Reload();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            // PlayerDeath. 
        }
    }

    private void OnDisable()
    {
        DeSubscribeToEvents();
    }

    private void DeSubscribeToEvents()
    {
        InputManager.OnPickWeaponInput -= PickWeapon;
        InputManager.OnDropWeaponInput -= DropWeapon;
        InputManager.OnSwitchWeaponInput -= SwitchWweapon;
        InputManager.OnAttackInput -= Attack;
        InputManager.OnReloadInput -= ReloadEquippedWeapon;
    }

}
