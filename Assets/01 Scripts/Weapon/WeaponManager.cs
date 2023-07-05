using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    MyWeapon myweapon;
    void Start()
    {
        myweapon = new MyWeapon();
    }
    public void ChangeSword()
    {
        myweapon.setWeapon(new Sword());
    }

    public void ChangeStaff()
    {
        myweapon.setWeapon(new Staff());
    }
    public void ChangeRifle()
    {
        myweapon.setWeapon(new Rifle());
    }
    public void Attack()
    {
        myweapon.Attack();
    }

}
