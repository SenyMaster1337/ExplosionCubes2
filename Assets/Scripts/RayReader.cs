using System;
using UnityEngine;

public class RayReader : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    private RaycastHit _hit;
    private Ray _ray;

    private int _positionZ = 1;

    public event Action<Cube> CubeClicked;

    private void OnEnable()
    {
        _inputHandler.Clicked += CheckRay;
    }

    private void OnDisable()
    {
        _inputHandler.Clicked -= CheckRay;
    }

    private void CheckRay()
    {
        _ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _positionZ));

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.tag == "Object")
            {
                Cube cube = FindObjectOfType<Cube>();
                cube.Init(_hit.collider.gameObject);
                CubeClicked.Invoke(cube);
                Destroy(_hit.collider.gameObject);
            }
        }
    }
}
