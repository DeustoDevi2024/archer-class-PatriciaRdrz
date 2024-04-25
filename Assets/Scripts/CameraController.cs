using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {

        // El objeto al que va a seguir la cámara
        [SerializeField]
        private Transform target;

        // Ángulo de la cámara
        [SerializeField]
        private float angle;

        // Distancia a la que se coloca la cámara con respecto a la arquera
        [SerializeField]
        private float distance;

        // Desplazamiento con respecto al pivote de la arquera 
        // (para que la cámara esté más orienta hacia la cabeza que a los pies)
        [SerializeField]
        private Vector3 offset;
        
        // Velocidad a la que se mueve la cámara con Vector3.MoveTowards()
        //[SerializeField]
        //private float travelSpeed;

        // Tiempo que tarda la cámara en moverse a la nueva ubicación con Vector3.Lerp()
        [SerializeField]
        private float travelTime;

        private void Update()
        { //lerp= movimiento suave de la camara
            Vector3 desiredPosition = target.transform.position + (Quaternion.Euler(0, angle, 0) * offset) - (target.forward * distance); //calcula la posicion en la que queremos poner la camara
            transform.position = Vector3.Lerp(transform.position, desiredPosition, travelTime / Time.deltaTime);
            //transform.position = desiredPosition;
            transform.LookAt(target.position + offset);
            //transform.position - target.position - target.forward * distance + offset;
        }

    }

}
