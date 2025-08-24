using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private RayReader _rayReader;

    private void OnEnable()
    {
        _rayReader.CubeClicked += Handle;
    }

    private void OnDisable()
    {
        _rayReader.CubeClicked -= Handle;
    }

    private void Handle(Cube cube)
    {
        CubesSpawner cubeSpawner = FindObjectOfType<CubesSpawner>();
        Exploder exploder = FindObjectOfType<Exploder>();

        cubeSpawner.Spawn(cube);
        exploder.Explode(cube.Prefab.transform.position);
    }
}
