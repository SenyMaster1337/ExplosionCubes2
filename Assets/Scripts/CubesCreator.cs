using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private RayReader _rayReader;

    private void OnEnable()
    {
        _rayReader.CubeClicked += CubeClickHandler;
    }

    private void OnDisable()
    {
        _rayReader.CubeClicked -= CubeClickHandler;
    }

    private void CubeClickHandler(Cube cube)
    {
        CubeSpawner cubeSpawner = FindObjectOfType<CubeSpawner>();
        Exploder exploder = FindObjectOfType<Exploder>();

        cubeSpawner.Spawn(cube);
        exploder.Explode(cube.Prefab.transform.position);
    }
}
