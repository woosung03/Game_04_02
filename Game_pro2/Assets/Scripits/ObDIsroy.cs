using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObDIsroy : MonoBehaviour //time up ball disroy
{
    Transform ObBalls;
  
    public float speed;

    void Start()
    {
        ObBalls = GetComponent<Transform>(); //ObBall position
        float randomTime = Random.Range(10.0f, 20.0f); // ������ �ð� ���� (5�� ~ 10�� ����)
        speed = Random.Range(2.0f, 10.0f); // ������ ��ǻ�ӵ� ���� (0.05f ~ 1.0f)
        StartCoroutine(DestroySelf(randomTime));  //Obstacle ball destroy
    }

    // Update is called once per frame
    void Update()
    {
        ObBalls.Translate(Vector2.right * speed * Time.deltaTime); //ObBall move speed

    }
    IEnumerator DestroySelf(float delay)
    {
        yield return new WaitForSeconds(delay); // ���� �ð� �� �ı�
        Destroy(this.gameObject); //ObBall destroy
    }
}
