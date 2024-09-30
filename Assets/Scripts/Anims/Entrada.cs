using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2;

    private void Start()
    {
        rigidbody2.AddForce(NovoVetor(1f, 5f), ForceMode2D.Impulse);
        rigidbody2.AddTorque(NovoVetor(-180f, 180f).x);
    }

    Vector2 NovoVetor(float x, float y)
    {
        return new Vector2(Random.Range(x, y), Random.Range(x, y));
    }
}
