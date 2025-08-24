using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    private int _minPercentageValue = 50;
    private int _maxPercentageValue = 100;

    public void Spawn(Cube cube)
    {
        if (GetBooleanValue(UnityEngine.Random.Range(0, _maxPercentageValue)))
        {
            int number = 2;

            for (int i = 0; i < GetCubesCount(); i++)
            {
                var cloneCube = Instantiate(cube.Prefab, cube.Prefab.transform.position, Quaternion.identity);
                _colorChanger.SetMaterial(cloneCube.GetComponent<Renderer>());
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
