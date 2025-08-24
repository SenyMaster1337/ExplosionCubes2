using UnityEngine;

public class CubesCreator : MonoBehaviour
{
    [SerializeField] private RayReader _rayReader;

    private int _minPercentageValue = 50;
    private int _maxPercentageValue = 100;

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
        Exploder exploder = FindObjectOfType<Exploder>();

        AddCubes(cube);
        exploder.Explode(cube.Prefab.transform.position);
    }

    private void AddCubes(Cube cube)
    {
        if (GetBooleanValue(UnityEngine.Random.Range(0, _maxPercentageValue)))
        {
            int number = 2;

            for (int i = 0; i < GetCubesCount(); i++)
            {
                cube.SpawnCube();
            }

            _minPercentageValue /= number;
            _maxPercentageValue /= number;
        }
    }

    private int GetCubesCount()
    {
        int minCubesCount = 2;
        int maxCubesCount = 6;

        int cubesCount = UnityEngine.Random.Range(minCubesCount, maxCubesCount);

        return cubesCount;
    }

    private bool GetBooleanValue(int percentageValue)
    {
        return percentageValue > _minPercentageValue;
    }
}
