using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] Timer _timer;
    [SerializeField, Range(0.1f, 1)] private float _size;
    [SerializeField, Min(0.1f)] private float _spawnPause;
    [SerializeField, Min(1)] private int _spawnCount;
    [SerializeField] private GameObject[] _prefabs;

    private Vector2 _spawnArea;

    private void Awake()
    {
        InitSpawnArea();
    }

    IEnumerator Start()
    {
        yield return new WaitUntil(() =>_timer.IsTimerEnded);
        WaitForSeconds wait = new WaitForSeconds(_spawnPause);
        for (int i = 0; i < _spawnCount; i++)
        {
            GameObject prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
            yield return wait;
        }
        Invoke(nameof(LoadMainMenu), 3);
    }

    void InitSpawnArea()
    {
        var cam = Camera.main;
        _spawnArea = new Vector2(cam.aspect * cam.orthographicSize, cam.orthographicSize) * 2 * _size;
    }

    Vector3 GetRandomPosition()
    {
        var pos = new Vector3(Random.Range(-_spawnArea.x / 2, _spawnArea.x / 2),
            Random.Range(-_spawnArea.y / 2, _spawnArea.y / 2));
        var camPos = Camera.main.transform.position;
        camPos.z = 0;
        return pos + camPos;
    }

    void LoadMainMenu() => SceneManager.LoadScene(0);

#if UNITY_EDITOR

    private void OnValidate()
    {
        InitSpawnArea();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        var pos = Camera.main.transform.position;
        pos.z = 0;
        Gizmos.DrawWireCube(pos, _spawnArea);
    }

#endif
}
