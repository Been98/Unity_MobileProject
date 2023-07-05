using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeapon : MonoBehaviour
{
    private IWeapon weapon;

    public void setWeapon(IWeapon weapon)
    {
        this.weapon = weapon;
    }
    public void Attack()
    {
        weapon.Attack();
    }

}
