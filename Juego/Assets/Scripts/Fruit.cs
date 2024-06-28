using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private float amountScore;
    [SerializeField] private Score totalScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            totalScore.addingUpScore(amountScore);
            Instantiate(effect,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
