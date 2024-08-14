using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] int startHp;
    [SerializeField] Slider hpBar;
    int currentHp;

    void Start()
    {
        hpBar.maxValue = startHp;
        hpBar.value = startHp;
        currentHp = startHp;
    }

    void Update()
    {
        if(currentHp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ChangeHp(int hp)
    {
        currentHp += hp;
        hpBar.value = currentHp;

    }
}
