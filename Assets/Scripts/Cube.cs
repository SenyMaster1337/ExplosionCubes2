using System;
using UnityEditor;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    public GameObject Prefab { get; private set; }

    public void Init(GameObject prefab)
    {
        Prefab = prefab;
    }

    public void SpawnCube()
    {
        int number = 2;

        var cloneCube = Instantiate(Prefab, Prefab.transform.position, Quaternion.identity);

        cloneCube.transform.localScale = Prefab.transform.localScale / number;

        _colorChanger.SetMaterial(cloneCube.GetComponent<Renderer>());
    }
}
