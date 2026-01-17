using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public Animator animator;
    public Image[] slots;          
    public Image[] icons;          
    public TMPro.TextMeshProUGUI[] counts;
    public static int selectedIndex = 0;
    public Color NormalColor = Color.grey;
    public Color SelectedColor = Color.white;

    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
            }
        }
    }

    void SelectSlot(int index)
    {
        selectedIndex = index;

        for (int i = 0; i < 5; i++)
        { 
            slots[i].color = (i == index) ? SelectedColor : NormalColor;
        }

        if (gameObject.CompareTag("Railgun1"))
        {
            animator.Play("Railgun");
            animator.SetBool("Nothing", true);
        }

        if (gameObject.CompareTag("Railgun2"))
        {           
            animator.Play("Railgun");
            animator.SetBool("Nothing", true);
        }

        if (gameObject.CompareTag("Pistol"))
        {
            animator.Play("SmallGun");
            animator.SetBool("Nothing", true);
        }

        if (gameObject.CompareTag("SMG"))
        {
            animator.Play("SmallGun");
            animator.SetBool("Nothing", true);
        }
    }
}
