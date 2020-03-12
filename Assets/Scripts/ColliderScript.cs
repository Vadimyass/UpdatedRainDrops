using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    [SerializeField] private GameObject DropLoss = null;
    public GameObject droploss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Engine>(out Engine Score))
        {
            droploss = Instantiate(DropLoss);
            droploss.transform.position = collision.transform.position;
            Destroy(droploss,2f);
        }
    }
}
