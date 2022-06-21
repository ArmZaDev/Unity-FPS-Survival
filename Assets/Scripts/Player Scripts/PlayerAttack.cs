using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private WeaponManager weapon_Manager;

	public float fireRate = 15f;
	private float nextTimeToFire;
	public float damage = 20f;

	private Animator zoomCameraAnim;
	private bool zoomed;

	private Camera mainCam;

	private GameObject crosshair;

	private bool is_Aiming;

	void Awake ()
    {
		weapon_Manager = GetComponent<WeaponManager>();

		zoomCameraAnim = transform.Find(Tags.LOOK_ROOT)
			             .transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

		crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

		mainCam = Camera.main;



    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		WeaponShoot();
		ZoomInAndOut();
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

					if (is_Aiming)
                    {
						weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

						if (weapon_Manager.GetCurrentSelectedWeapon().bulletTpye 					== WeaponbulletTpye.ARROW)
                        {
							// throw arrow
                        }
						else if (weapon_Manager.GetCurrentSelectedWeapon().bulletTpye== WeaponbulletTpye.SPEAR)
                        {
							// throw sear
                        }
                    
					}


                }// else

           
			}// if input mouse button 0
        
		}// else

    }// weapon shoot

	void ZoomInAndOut()
    {
		// we are going to aim with our camera on the weapon
		if (weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.AIM)
        {
			// if we press and  hold right mouse button
			if (Input.GetMouseButtonDown(1))
            {
				zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);

				crosshair.SetActive(false);
            }

			// when we release the right button click
			if (Input.GetMouseButtonUp(1))
			{
				zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

				crosshair.SetActive(true);
			}


		}// if we need to zoom the weapon

		if (weapon_Manager.GetCurrentSelectedWeapon().weapon_Aim == WeaponAim.SELF_AIM)
        {
			if (Input.GetMouseButtonDown(1))
            {
				weapon_Manager.GetCurrentSelectedWeapon().Aim(true);
				is_Aiming = true;
            }

			if (Input.GetMouseButtonUp(1))
			{
				weapon_Manager.GetCurrentSelectedWeapon().Aim(false);
				is_Aiming = false;
			}
		}

    }// zoom in and out

}//class









