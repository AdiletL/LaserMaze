using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Portal : MonoBehaviour
    {
        public static event Action OnPortal;

        private IEnumerator FinishedCoroutine(Transform targetTransform)
        {
            yield return new WaitForEndOfFrame();
            while (targetTransform.localScale != Vector3.zero)
            {
                targetTransform.localScale = Vector3.MoveTowards(targetTransform.localScale, Vector3.zero, 2 * Time.deltaTime);
                yield return null;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPortal?.Invoke();
                StartCoroutine(FinishedCoroutine(other.transform));
                StartCoroutine(FinishedCoroutine(transform));
            }
        }
    }
}