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

    // Initializes variables for Player.
    private void InitializePlayer()
    {
        primaryWeapon1 = null;
        primaryWeapon2 = null;
        secondaryWeapon = null;
        equippedWeapon = null;
    }

    // Subscribe to Input Events.
    private void SubscribeToEvents()
    {
        InputManager.OnPickWeaponInput += PickWeapon;
        InputManager.OnDropWeaponInput += DropWeapon;
        InputManager.OnSwitchWeaponInput += SwitchWweapon;
        InputManager.OnAttackInput += Attack;
        InputManager.OnReloadInput += ReloadEquippedWeapon;
    }

    // This method picks up a weapon and updates the playerweapon slot and UI accordingly.
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

    // Logic for picking up a primary weapon and updating weapon slots.
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

    // Logic for picking up a secondary weapon and updating weapon slots.
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

    // Method to drop a weapon from the inventory.
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

    // Method to equip another weapon from inventory.
    private void SwitchWweapon(WeaponController weaponToEquip)
    {
        equippedWeapon = weaponToEquip;
    }

    // This method attacks according to the weapon equipped.
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

    // This method  is called when no weapon is equipped.
    private void MeleeAttack()
    {

    }

    // This is used for reloading the equipped weapon.
    private void ReloadEquippedWeapon()
    {
        if (equippedWeapon != null) equippedWeapon.Reload();
    }

    // This method is called when our player takes damage.
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

    // Used to Unsubscribe from Input Events.
    private void DeSubscribeToEvents()
    {
        InputManager.OnPickWeaponInput -= PickWeapon;
        InputManager.OnDropWeaponInput -= DropWeapon;
        InputManager.OnSwitchWeaponInput -= SwitchWweapon;
        InputManager.OnAttackInput -= Attack;
        InputManager.OnReloadInput -= ReloadEquippedWeapon;
    }

}
