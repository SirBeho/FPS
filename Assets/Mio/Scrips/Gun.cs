using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int damageAmount = 20;

    public int fireRate = 10;
    private float nextTimeToFire = 0;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public int currentAmmo;
    public int maxAmmo = 10;
    public int magazineAmmo = 30;

    public float reloadTime = 2f;
    public bool isReloading;

    public Animator animator;

    InputAction shoot;

    public TextMeshProUGUI puntuacion;
    private int punto = 0;

    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.Enable();
        
        currentAmmo = maxAmmo;
    }
    private void OnEnable()
    {
        isReloading = false;
       animator.SetBool("Recargando", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo ==0 && magazineAmmo == 0)
        {
            animator.SetBool("Disparando", false);
            return;
        }

        if (isReloading)
            return;

      // bool isShooting = CrossPlatformInputManager.GetButton("Shoot");
        bool isShooting = shoot.ReadValue<float>() == 1;
       animator.SetBool("Disparando", isShooting);

        if (isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }

        if(currentAmmo == 0 && magazineAmmo >0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    private void Fire()
    {
        AudioManager.instance.Play("Shoot");

        muzzleFlash.Play();
        currentAmmo--;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.position + fpsCam.forward, fpsCam.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Enemy e = hit.transform.GetComponent<Enemy>();
            if(e != null)
            {
                    
                punto += e.punto(hit.collider.name, damageAmount);

                puntuacion.text = "Puntos:" + punto.ToString();
                return;
            }

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            impact.transform.parent = hit.transform;
            Destroy(impact, 5);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
	    //AudioManager.instance.Play("Reload");
        animator.SetBool("Recargando", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Recargando", false);
        if (magazineAmmo >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineAmmo -= maxAmmo;
        }
        else
        {
            currentAmmo = magazineAmmo;
            magazineAmmo = 0;
        }
        isReloading = false;
    }
}
