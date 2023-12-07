using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5.0f;
    [SerializeField] private GameObject estrellaPrefab;
    [SerializeField] private Transform referenciaGeneracionEstrella;
    [SerializeField] private Vector3 simplePosition;
    [SerializeField] private Transform reference;
    [SerializeField] private Transform objetoDestino;

    public Vector3 minPosition;
    public Vector3 maxPosition;

    
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        simplePosition = context.ReadValue<Vector2>();
        simplePosition.z = 10;

        Vector3 complexPosition = Camera.main.ScreenToWorldPoint(simplePosition);

        reference.position = complexPosition;
        Debug.Log("posicion del mouse en la pantalla: "+complexPosition);
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        Vector3 posicionGeneracion = referenciaGeneracionEstrella.position;
        GameObject nuevaEstrella = Instantiate(estrellaPrefab, posicionGeneracion, Quaternion.identity);

        Vector3 direccion = (objetoDestino.position - posicionGeneracion).normalized;
        Debug.Log("direccion destino?: " + direccion);

        Transform transformEstrella = nuevaEstrella.transform;
        transformEstrella.position = posicionGeneracion;
        float distanciaTotal = Vector3.Distance(posicionGeneracion, objetoDestino.position);

        StartCoroutine(MoverEstrella(transformEstrella, direccion, distanciaTotal));
    }

    private IEnumerator MoverEstrella(Transform estrella, Vector3 direccion, float distanciaTotal)
    {
        float distanciaRecorrida = 0f;

        while (distanciaRecorrida < distanciaTotal)
        {
            float movimiento = velocidad * Time.deltaTime;
            estrella.Translate(direccion * movimiento);
            distanciaRecorrida += movimiento;
            yield return null;
        }
        Destroy(estrella.gameObject);
    }
}