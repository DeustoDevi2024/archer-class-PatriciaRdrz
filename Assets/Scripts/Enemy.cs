using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;
        public Light directionalLight;
        private Animator animator;
        private AudioSource audioSource;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(hitPoints <= 0)
            {
                StartCoroutine(Die());
                
            }
            
        }

        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            audioSource.Play();
            //animator.SetBool("Hit", true);
            animator.SetTrigger("Hit");
            hitPoints--;
        }

        private IEnumerator Die()
        {
            //animator.SetBool("Die", true);
            animator.SetTrigger("Die");
            directionalLight.enabled = true;
            yield return new WaitForSeconds(3f);
            directionalLight.enabled = false;
            Destroy(gameObject);

        }
    }

}