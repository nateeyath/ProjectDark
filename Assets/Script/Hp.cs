using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour

{
    public float Health;
    public float maxHealth;
    public Image Hpbar;
    // Start is called before the first frame update
    void Start()

    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Hpbar.fillAmount = Mathf.Clamp(Health / maxHealth, 0, 1);
        if (Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Die");

        }
    }
}