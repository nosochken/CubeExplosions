using System.Collections.Generic;
using UnityEngine;

public class DestructibleCube : MonoBehaviour
{
    private CubeDestroyer _cubeDestroyer;
    private Cube _cube;

    private List<GameObject> _newCubes;

    private void Awake()
    {
        _newCubes = new List<GameObject>();
        _cubeDestroyer = FindObjectOfType<CubeDestroyer>();
        _cube = gameObject.GetComponent<Cube>();
    }

    private void Update()
    {
        Collapse();
    }

    private void OnEnable()
    {
        _cubeDestroyer.CubeDestroying += Collapse;
    }

    private void OnDisable()
    {
        _cubeDestroyer.CubeDestroying -= Collapse;
    }

    private void Collapse()
    {
        if (CanDivide())
        {
            Divide();
            Explode();
        }
    }

    private bool CanDivide()
    {
        int minChanceOfDivision = 0;
        int maxChanceOfDivision = 100;

        int result = Random.Range(minChanceOfDivision, maxChanceOfDivision);

        return _cube.ChanceOfDivision > result ? true : false;
    }

    private void Divide()
    {
        int minAmountOfCubes = 2;
        int maxAmountOfCubes = 6;

        float reductionOfNewCube = 2f;
        float reducingChanceOfDivision = 2f;

        int amountOfNewCubes = Random.Range(minAmountOfCubes, maxAmountOfCubes);
        float chanceOfDivisionNewCubes = _cube.ChanceOfDivision / reducingChanceOfDivision;
        Vector3 newCubeScale = transform.localScale / reductionOfNewCube;
        string newCubeName = gameObject.name;

        for (int i = 0; i <= amountOfNewCubes; i++)
        {
            newCubeName += i;
            _newCubes.Add(CreateNewCube(newCubeName, newCubeScale, chanceOfDivisionNewCubes));
        }
    }

    private GameObject CreateNewCube(string name, Vector3 scale, float chanceOfDivision)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = gameObject.transform.position;
        cube.name = name;
        cube.AddComponent<Rigidbody>();
        cube.AddComponent<Cube>().Initialize(scale, chanceOfDivision);
        cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

        return cube;
    }

    private void Explode()
    {
        float force = 1100f;
        float radius = 10f;

        foreach (GameObject cube in _newCubes)
            cube.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
    }
}