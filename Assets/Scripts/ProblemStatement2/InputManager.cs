using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This Class will trigger various events according to the input recieved.
/// </summary>
public class InputManager : SingletonGeneric<InputManager>
{
    public static event Action<WeaponController> OnPickWeaponInput;
    public static event Action<WeaponController> OnDropWeaponInput;
    public static event Action<WeaponController> OnSwitchWeaponInput;
    public static event Action OnAttackInput;
    public static event Action OnReloadInput;
    public static event Action<int> OnHit;


    private void GetWeaponToPick(WeaponController weaponToPick)
    {
        OnPickWeaponInput?.Invoke(weaponToPick);
    }

    private void GetWeaponToDrop(WeaponController weaponToDrop)
    {
        OnDropWeaponInput?.Invoke(weaponToDrop);
    }

    private void GetWeaponToSwitch(WeaponController weaponToSwitch)
    {
        OnSwitchWeaponInput?.Invoke(weaponToSwitch);
    }

    private void Attack()
    {
        OnAttackInput?.Invoke();
    }

    private void Reload()
    {
        OnReloadInput?.Invoke();
    }

    private void TakeDamage(int damage)
    {
        OnHit?.Invoke(damage);
    }

}
