using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTo : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float rotationSpeed = 2.0f; // Velocidad de rotación del NPC
    public bool playerNearby = false;

    void Update()
    {
        if (playerNearby)
        {
            LookAtTarget(player.position);
        }
    }

    void LookAtTarget(Vector3 targetPosition)
    {
        // Obtenemos la dirección hacia la que queremos mirar
        Vector3 directionToLook = targetPosition - transform.position;
        directionToLook.y = 0; // Esto evita que el NPC incline su cabeza hacia arriba o abajo, puedes removerlo si prefieres que sí lo haga.

        // Calculamos la rotación necesaria para mirar hacia esa dirección
        Quaternion targetRotation = Quaternion.LookRotation(directionToLook);

        // Suavemente rotamos hacia esa dirección
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerNearby = false;
        }
    }
}
