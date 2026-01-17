using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem muzzleflash;
    public AudioSource gunfire;
    public float fireRate;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.CompareTag("Pistol"))
            {
                animator.Play("PistolFiring");
            }

            else if (gameObject.CompareTag("Railgun 1"))
            {
                animator.Play("RailgunFiring");
            }
            StartCoroutine(FireFlash(fireRate));
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Enemy")
                {
                    // hit.collider.gameobject.GetComponent<Enemyhealth>().Takedamage(1);
                }
            }
        }
    }

    private IEnumerator FireFlash(float duration)
    {
        muzzleflash.Play();
       // gunfire.PlayOneShot(gunfire.clip);
        yield return new WaitForSeconds(duration);
        muzzleflash.Stop();
    }
}
