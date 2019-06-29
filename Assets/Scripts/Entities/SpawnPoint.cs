using SpaceMarine;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Start()
    {
        SpawnPlayer();
    }

    [Button]
    private void SpawnPlayer()
    {
        Player.Instance.MonoBehavior.transform.position = transform.position;
    }
}