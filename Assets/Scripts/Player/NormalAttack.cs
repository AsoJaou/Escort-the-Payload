using System.Collections;
using UnityEngine;

public class NormalAttack : MonoBehaviour
{
    //Normal Attack Variables
    private float baseAttackSpeed = 15f;
    private Vector3 currentPos;
    private Vector3 displacement;
    private Vector3 direction;

    void AttackTarget(GameObject target)
    {
        StartCoroutine(MoveToPosition(target.transform));

    }

    IEnumerator MoveToPosition(Transform targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.1f)
        {
            transform.LookAt(new Vector3(targetPosition.position.x, transform.position.y, targetPosition.position.z));
            currentPos = transform.position;
            displacement = targetPosition.position - currentPos;
            direction = displacement.normalized * Time.deltaTime;
            transform.position += direction * baseAttackSpeed;

            yield return null;
        }
        Destroy(gameObject);
    }
}
