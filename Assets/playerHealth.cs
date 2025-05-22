using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Image healthbarSprite;
    public float reduceSpeed = 2;
    private float target = 1;

    public float maxHP = 100f;
    public float currentHP = 100f;

    //private Camera cam;
    private void Start()
    {
        //cam = Camera.main;
    }
    public void UpdateHPBar(float maxHP, float currentHP)
    {
        target = currentHP / maxHP;
    }

    private void Update()
    {
        //transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentHP -= 10f;
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);
            UpdateHPBar(maxHP, currentHP);
        }

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
