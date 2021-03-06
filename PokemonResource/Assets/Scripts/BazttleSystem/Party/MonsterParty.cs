using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MonsterParty : MonoBehaviour
{
    [SerializeField] List<Monster> pokemons;


    public event Action OnUpdated;

    public List<Monster> Monsters
    {
        get
        {
            return pokemons;
        }
        set
        {
            pokemons = value;

            OnUpdated?.Invoke();
        }
    }

    private void Start()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.Init();
        }
    }

    public Monster GetHealthyPokemon()
    {
        return pokemons.Where(x => x.HP > 0).FirstOrDefault();
    }

    public void AddMonster(Monster newMonster)
    {
        if(pokemons.Count < 6)
        {
            pokemons.Add(newMonster);
            OnUpdated?.Invoke();
        }

        else
        {
            //Add to pc / monster dex when it is completed 
        }
    }


    public static MonsterParty GetPlayerParty()
    {
        return FindObjectOfType<PlayerController>().GetComponent<MonsterParty>();
    }

}
