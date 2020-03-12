using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboChecker : MonoBehaviour
{
    [SerializeField] private GameObject ComboPic = null;
    [SerializeField] private GameObject PlaceToPut = null;
    [SerializeField] private Text ComboMultiple = null;

    private SpriteRenderer ChangeColor;
    private ParticleSystem particles;


    private int Combo;
    private GameObject ComboIcon;

    private void Start()
    {
        ChangeColor = GetComponent<SpriteRenderer>();
        //In the Start of game Text removes;
        ComboMultiple.text = " ";
        //And Combo the same;
        Combo = 0;
        particles = GetComponentInChildren<ParticleSystem>();
    }

    //Checking for enter a trigger of Raindrops or Stones; 
    [Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Raindrops>(out Raindrops raindrops))      //Try to get trigger from Raindrops;
        {
            Combo = Combo + 1;
            GainCombo();

        }
        if (collision.TryGetComponent<ColliderScript>(out ColliderScript Stones))       //Try to get trigger from Stones;
        {
            Combo = 0;
            ChangeColor.color = Color.white;
            particles.startColor = Color.Lerp(Color.white, Color.red, 0.1f);
        }
    }

    //Checking combo multiplier;
    [Obsolete]
    void GainCombo()
    {
        if (Combo == 5)
        {
            StartCoroutine(DelayForDelete());
            ComboMultiple.text = Combo.ToString();
        }
        if (Combo == 10)
        {
            StartCoroutine(DelayForDelete());
            ChangeColor.color = Color.Lerp(Color.red, Color.green, 0.1f);
            gameObject.GetComponentInChildren<ParticleSystem>().startColor = Color.Lerp(Color.red, Color.white, 0.1f);
        }
        if (Combo == 25)
        {
            StartCoroutine(DelayForDelete());
        }

    }

    
    //Some optimization;
    //Delete cache and clear out text field; 
    IEnumerator DelayForDelete()
    {
        ComboIcon = Instantiate(ComboPic, PlaceToPut.transform.position, Quaternion.identity);
        ComboMultiple.text = Combo.ToString();
        yield return new WaitForSeconds(3f);
        ComboMultiple.text = " ";
        Destroy(ComboIcon);
    }
}
