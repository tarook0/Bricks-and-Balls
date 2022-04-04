using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Brick : MonoBehaviour
{
    public int hit = 2;
    public int points = 100;
    public Vector3 rotator;
    public Material hitMaterial;
    Material _orgMaterial;
    Renderer _renderer;
    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y));
        _renderer = GetComponent<Renderer>();
        _orgMaterial = _renderer.sharedMaterial;
    }
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collsison)
    {
        hit--;
        //Score point
        if (hit <= 0)
        {
            GameManger.Instance.Score+=points;
            Destroy(gameObject);

        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }
    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _orgMaterial;
    }

}