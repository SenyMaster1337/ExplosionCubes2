using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject Prefab { get; private set; }

    private int _number = 2;

    public void Init(GameObject prefab)
    {
        Prefab = prefab;

        Prefab.transform.localScale /= _number;
    }
}
