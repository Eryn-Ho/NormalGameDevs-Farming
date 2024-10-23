using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectibleBasic : MonoBehaviour
{
    [SerializeField] private string tagCheck = "Player";
    [SerializeField] private Rigidbody rib;
    [SerializeField] private int collectibleType;
    [SerializeField] private float approachSeconds;
    private bool activated = false;
    public UnityEvent CollectedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagCheck && !activated)
        {
            activated = true;
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

            StartCoroutine(ApproachRib(rb));
        }
    }

    public IEnumerator ApproachRib(Rigidbody rb)
    {
        Vector3 iniPos = rib.position;
        for (float i = 0; i < 500; i++)
        {
            if (Vector3.Distance(rib.position, rb.position) < 1)
            {
                //Destroy(gameObject);
                //CollectedEvent.Invoke();
                //CollectibleHud.instance.CollectibleAdded(1, collectibleType);
                break;
            }
            rib.position = Vector3.Lerp(rib.position, rb.position, i / 500);
            yield return new WaitForSeconds(approachSeconds / 500);
        }

    }
}