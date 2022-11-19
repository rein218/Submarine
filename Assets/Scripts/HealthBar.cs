using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthBare;
    public Image HealthBarEffect;
    float MaxHealth = 60f;
    public static float Health;
    public float HealthSpeed;
    void Start()
    {
        HealthBare = GetComponent<Image>();
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBare.fillAmount = Health / MaxHealth;
        if(HealthBarEffect.fillAmount > HealthBare.fillAmount) {
            HealthBarEffect.fillAmount -= HealthSpeed;
        }
        else{
            HealthBarEffect.fillAmount = HealthBare.fillAmount;
        }
        
    }
}
