using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingHealth : MonoBehaviour
{
    //public Image healthbarSprite;
    public float reduceSpeed = 2;
    private float target = 1;

    public float maxHP = 300f;
    public float currentHP = 300f;

    //private Camera cam;
    private void Start()
    {
        //cam = Camera.main;
    }

    public void Hacking()
    {
        currentHP -= 5;
    }

    public void UpdateHPBar(float maxHP, float currentHP)
    {
        target = currentHP / maxHP;
    }

    private void Update()
    {
        //transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        //healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);

        if (currentHP <= 0)
        {
            StartCoroutine(die(0.10f));
        }
    }

    private IEnumerator die(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }


}
