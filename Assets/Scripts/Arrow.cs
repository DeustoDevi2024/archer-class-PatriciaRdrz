using UnityEngine;

namespace Archer
{

    public class Arrow : MonoBehaviour
    {
        //public GameObject arrow;
        private Rigidbody arrowRigidbody;
        private bool hit;
        private AudioSource audioSource;

        private void Awake()
        {
            // Establecer las referencias de Rigidbody (para detener la flecha) y AudioSource (para el sonido de impacto)
            arrowRigidbody = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();

        }

        // El rigidbody de la flecha es tipo Trigger, para que no colisione
        private void OnTriggerEnter(Collider other)
        {

            // La flecha sólo produce daño y ruido en el primer impacto
            if (hit) {
                return;
            }

            // Si impacta con el jugador, lo ignoramos
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                return;
            }

            hit = true;

            // Reproducir el impacto de la flecha


            // Hacemos que la flecha sea hija del objeto contra el que impacta, para que se mueva con el
            transform.SetParent(other.gameObject.transform);
            // Hacemos que la flecha sea kinematica para que no responda a nuevas aceleraciones (se quede clavada)
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            audioSource.Play();

            // Miramos a ver si el objeto contra el que ha impacto la flecha tiene un componente Enemy...
            
            
            // ... Y si lo tiene, le hacemos daño (la siguiente comprohación es equivalente a hacer if (enemy != null) { enemy.Hit(); }
            if (other.gameObject.transform.parent.TryGetComponent(out Enemy enemy))
            {
                if(enemy != null)
                {
                    enemy.Hit();
                }
            }


            //if(other.GetComponentInParent)
            //if(other.transform.parent.gameObject)
        }

    }

}