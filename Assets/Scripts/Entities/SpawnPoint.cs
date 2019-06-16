using SpaceMarine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{ 
    void Start()
    {
        SpawnPlayer();
    }

    [Button]
    private void SpawnPlayer()
    {
        Player.Instance.MonoBehavior.transform.position = transform.position;
    }
}
