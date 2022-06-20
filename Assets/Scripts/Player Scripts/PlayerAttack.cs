using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private WeaponManager weapon_Manager;

	public float fireRate = 15f;
	private float nextTimeToFire;
	public float damage = 20f;

	void Awake ()
    {
		weapon_Manager = GetComponent<WeaponManager>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		WeaponShoot();
	}

	void WeaponShoot()
    {
		// if we have assult riffle
		if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MUTIPLE)
        {
			// if we press and hold left mouse click AND
			// if Time is greater than the nextTimeToFire
			if (Input.GetMouseButton(0)&& Time.time > nextTimeToFire)
            {
				nextTimeToFire = Time.time + 1f / fireRate;

				weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

				//BulletFired();
            
			}
        }
		else // if we have a regular weapon the shoots once
        {
			if (Input.GetMouseButtonDown(0))
            {
				// handle axe
				if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
					weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }

				// handle shoot
				if (weapon_Manager.GetCurrentSelectedWeapon().bulletTpye == WeaponbulletTpye.BULLET)
                {
					weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

					// BulletFired();
				}
				else
                {
					// we have arrow or spear


                }// else

           
			}// if input mouse button 0
        
		}// else
    }

}//class









