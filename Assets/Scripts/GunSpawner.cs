using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reminder: null = nothing
public class GunSpawner : MonoBehaviour
{
    public Transform weaponSocket;
    public Transform gunHolder;

    private int current = -1;
    private GameObject currentGunClone; 

    public GameObject gun1Prefab;
    public GameObject gun2Prefab;
    public GameObject gun3Prefab;
    public GameObject gun4Prefab;

    private List<GameObject> guns;

    private bool hasSpawnedGun = false;

    public Vector3 SmallgunLocalPosition = Vector3.zero;
    public Vector3 gunLocalPosition = Vector3.zero;
    public Vector3 gunLocalEulerRotation = Vector3.zero;

    private void Start()
    {
        guns = new List<GameObject>();

        guns.Add(gun1Prefab);
        guns.Add(gun2Prefab);
        guns.Add(gun3Prefab);
        guns.Add(gun4Prefab);
    }
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                string slotTag = FindObjectOfType<Hotbar>().slots[i].tag;

                SpawnByTag(slotTag);
            }
        }
    }


            //if (Input.GetKey(KeyCode.Q))
            //{
            //    guns[i].AddComponent<Rigidbody>();
            //}

            //else
            //{
            //    Destroy(guns[i].AddComponent<Rigidbody>());
            //}

            
        
    
  //  void OnCollisionEnter(Collision other)
    //{
      //  if (other.gameObject.CompareTag("Railgun1"))
        //    SpawnGun(gun1Prefab, gunLocalPosition);

//        else if (other.gameObject.CompareTag("Railgun2"))
  //          SpawnGun(gun2Prefab, gunLocalPosition);

    //    else if (other.gameObject.CompareTag("Pistol"))
      //      SpawnGun(gun3Prefab, SmallgunLocalPosition);

        //else if (other.gameObject.CompareTag("SMG"))
          //  SpawnGun(gun4Prefab, SmallgunLocalPosition);

   // }

    GameObject SpawnGun(GameObject gunPrefab, Vector3 localPos)
    {
        GameObject gunInstance = Instantiate(gunPrefab, gunHolder);

        gunInstance.transform.localPosition = localPos;
        gunInstance.transform.localRotation = Quaternion.identity;

        hasSpawnedGun = true;
        return gunInstance;
    }

    void SpawnByTag(string tag)
    {
        if (currentGunClone != null)
            Destroy(currentGunClone);

        foreach (GameObject gun in guns)
        {
            if (gun.CompareTag(tag))
            {
                Vector3 pos = (tag == "Pistol" || tag == "SMG")
                    ? SmallgunLocalPosition
                    : gunLocalPosition;

                currentGunClone = SpawnGun(gun, pos);
                return;
            }
        }
    }

}



