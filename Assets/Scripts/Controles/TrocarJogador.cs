using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocarJogador : MonoBehaviour
{
    [SerializeField]
    GameObject[] jogadores;

    PlayerActions playerActions;
    GameObject jogador;
    int index = 0;

    private void Awake()
    {
        playerActions = new PlayerActions();    
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        playerActions.MovesMap.Trocar.started += _ => Trocar();
    }

    public void Trocar()
    {
        if(index >= jogadores.Length) return;
        Transform pos = jogador.transform;
        Instantiate(jogadores[index], pos.position, Quaternion.identity);
        Destroy(jogador);
        index++;
    }
}
