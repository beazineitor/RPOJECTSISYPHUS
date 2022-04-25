using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenrifle : MonoBehaviour
{
    private Animator anim;
    private AudioSource _AudioSource;
    private AudioSource _AudioSource1;
    public float range = 100f;
    public int bulletsPerMag = 30;
    public int bulletsLeft = 200;
    public float fireRate = 0.1f;
    public Transform shootPoint;
    public int currentBullets;
    float fireTimer;
    public ParticleSystem muzzleflahs;
    public AudioClip shootSound;
    public AudioClip reloadingSound;
    private bool isReloading;
    public GameObject hitParticles;
    public GameObject bulletImpact;
    public GameObject bulletTrail;
    public GameObject aimDisapear;
    public GameObject holographicAim;
    public int contador = 0;



    public enum shootMode { Auto, Burst, Semi }
    public shootMode shootingMode;
    private bool shootInput;
    public float damage = 20;
    public float spreadFactor = 0.1f;
    private Vector3 originalPosition;
    public Vector3 aimPosition;
    public float adsSpeed = 8f;
    private bool isAiming;
    private bool inBurst = false;



    // Start is called before the first frame update
    void Start()
    {
        currentBullets = bulletsPerMag;
        anim = GetComponent<Animator>();
        _AudioSource = GetComponent<AudioSource>();
        _AudioSource1 = GetComponent<AudioSource>();
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        switch (shootingMode)
        {
            case shootMode.Auto:
                shootInput = Input.GetButton("Fire1");
                break;
            case shootMode.Burst:
                //shootInput = Input.GetButton("Fire1");
                shootInput = Input.GetButtonDown("Fire1");
                break;
            case shootMode.Semi:
                shootInput = Input.GetButtonDown("Fire1");
                break;
        }
        if (shootInput || inBurst)// he ùesto in burssttt
        {
            if (currentBullets > 0)
                fire();
            else if (bulletsLeft > 0)
                doReload();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentBullets < bulletsPerMag && bulletsLeft > 0)
                doReload();
        }
        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;


        AimDownSights();

    }
    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        isReloading = info.IsName("Reload");
        anim.SetBool("Aim", isAiming);

    }
    private void AimDownSights()
    {
        if (Input.GetButton("Fire2")) //&& !isReloading)
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * adsSpeed);
            print("Aiming");
            isAiming = true;
            aimDisapear.SetActive(false);
            spreadFactor = 0;
            if (holographicAim != null)
            {
                holographicAim.SetActive(true);
            }
            contador++;



        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * adsSpeed);
            isAiming = false;
            aimDisapear.SetActive(true);
            spreadFactor = 0.01f;

            contador = 0;
            if (holographicAim != null)
            {
                holographicAim.SetActive(false);
            }

        }

    }

    private void fire()
    {

        if (fireTimer < fireRate || currentBullets < 0 || isReloading) return;



        RaycastHit hit;

        Vector3 shootDirection = shootPoint.transform.forward;
        shootDirection = shootDirection + shootPoint.TransformDirection
            (new Vector3(Random.Range(-spreadFactor, spreadFactor), Random.Range(-spreadFactor, spreadFactor)));
        //shootDirection.x += Random.Range(-spreadFactor, spreadFactor);
        //shootDirection.y += Random.Range(-spreadFactor, spreadFactor);

        if (Physics.Raycast(shootPoint.position, shootDirection, out hit, range))
        {
            Debug.Log(hit.transform.name + "Found");
            GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            hitParticleEffect.transform.SetParent(hit.transform);
            //GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)); solo para la pistola

            Destroy(hitParticleEffect, 1f);
            //Destroy(bulletHole, 7f);
            if (hit.transform.GetComponent<aliencontrol>())
            {
                hit.transform.GetComponent<aliencontrol>().applyDamage(damage);
            }
            SPAWNbULLETtRAIL(hit.point);
        }
        anim.CrossFadeInFixedTime("Fire", 0.01f);
        muzzleflahs.Play();
        PlayShootSoundEffect();
        currentBullets--;
        fireTimer = 0.0f;

    }
    private void SPAWNbULLETtRAIL(Vector3 hitPoint)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, shootPoint.position, Quaternion.identity);
        LineRenderer lineR = bulletTrailEffect.GetComponent<LineRenderer>();
        lineR.SetPosition(0, shootPoint.position);
        lineR.SetPosition(1, hitPoint);
        Destroy(bulletTrailEffect, 1f);
    }
    public void RELOAD()
    {
        if (bulletsLeft <= 0) return;
        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;
        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;
        print("Reloadingblue" + gameObject);
    }
    private void doReload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Reload")) return;
        anim.CrossFadeInFixedTime("Reload", 0.01f);
        PlaySoundEffectReload();
    }
    private void PlayShootSoundEffect()
    {
        _AudioSource.PlayOneShot(shootSound);
    }
    private void PlaySoundEffectReload()
    {
        _AudioSource1.PlayOneShot(reloadingSound);
    }
}
