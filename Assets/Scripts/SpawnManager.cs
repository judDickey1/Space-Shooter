using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _enemy1;

    private bool _dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn gameobjects every five seconds
    IEnumerator SpawnRoutine()
    {
        
        while (_dead == false)
        {
            Vector3 spawnPos = new(Random.Range(-9, 9), 8f, 0);
            GameObject newEnemy = Instantiate(_enemy1, spawnPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    public void OnPlayerDeath()
    {
        _dead = true;
    }
}
