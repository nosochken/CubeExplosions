using UnityEngine;
using System;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private GameObject _selectedCube;

    public event Action CubeDestroying;

    void Update()
    {
        _selectedCube = SelectCube();

        if (_selectedCube != null)
            DestroyCube();
    }

    private GameObject SelectCube()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 20;
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.cyan);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) &&
            (Input.GetMouseButtonDown(0)))
        {
            if (hit.collider.GetComponent(typeof(Cube)))
                return hit.transform.gameObject;
        }

        return null;
    }

    private void DestroyCube()
    {
        _selectedCube.AddComponent<DestructibleCube>();

        CubeDestroying?.Invoke();

        Destroy(_selectedCube);
    }
}