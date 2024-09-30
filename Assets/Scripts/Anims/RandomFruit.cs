using UnityEngine;

public class RandomFruit : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public enum Frutas
    {
        Abacaxi,
        Apple,
        Bananas,
        Kiwi,
        Cerejas,
        Laranja,
        Melancia,
        Morango
    }

    private void Start()
    {
        Frutas fruta = ((Frutas)Random.Range(0, 8));
        animator.SetTrigger(fruta.ToString());
    }
}
