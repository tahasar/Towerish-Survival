using System.Collections.Generic;
using UnityEngine;

public class RotatingBladesManager : MonoBehaviour
{
    public GameObject OriginalSurrounderObject;
    public GameObject newSurrounderObject;
    public List<GameObject> surrounderObject = new();
    public float distanceFromCenter;
    public float rotateAroundSpeed;

    //private readonly float AppearWaitDuration = 0.3f;
    private bool inCooldown;
    private RotatingBlade rotatingBlade;

    private void Start()
    {
        //StartCoroutine(SurroundStepAnimated());

        AddSurround();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) AddSurround();

        if (Input.GetKeyDown(KeyCode.G)) SurroundOn();

        if (Input.GetKeyDown(KeyCode.H)) SurroundOff();

        if (Input.GetKeyDown(KeyCode.V)) RemoveSurround();
    }

    private void FixedUpdate()
    {
        if (!inCooldown) inCooldown = true;
    }

    //IEnumerator SurroundStepAnimated()
    //{
    //    yield return new WaitForSeconds(AppearWaitDuration);

    //    float AngleStep = 360.0f / SurrounderObjectCount;

    //    for (int i = 0; i < SurrounderObjectCount; i++)
    //    {
    //        GameObject newSurrounderObject = Instantiate(OriginalSurrounderObject, transform);

    //        newSurrounderObject.transform.RotateAround(transform.position, Vector3.forward,AngleStep * i);
    //        newSurrounderObject.transform.Translate(new Vector2(2, 0));

    //        yield return new WaitForSeconds(AppearWaitDuration);
    //    }
    //}


    private void AddSurround()
    {
        newSurrounderObject = Instantiate(OriginalSurrounderObject, transform);
        newSurrounderObject.SetActive(false);

        surrounderObject.Add(newSurrounderObject);
        SurroundOn();
    }

    private void RemoveSurround()
    {
        Destroy(surrounderObject[^1]);
        surrounderObject.Remove(surrounderObject[^1]);
        SurroundOn();
    }

    private void SurroundOn()
    {
        float AngleStep = 360 / surrounderObject.Count;

        for (var i = 0; i < surrounderObject.Count; i++)
        {
            surrounderObject[i].transform.localPosition = new Vector2(distanceFromCenter, 0);
            surrounderObject[i].transform.RotateAround(transform.position, Vector3.forward, AngleStep * i);
            surrounderObject[i].SetActive(true);

            surrounderObject[i].GetComponent<RotatingBlade>().rotateAroundSpeed = rotateAroundSpeed;
        }
    }

    private void SurroundOff()
    {
        for (var i = 0; i < surrounderObject.Count; i++) surrounderObject[i].SetActive(false);
    }
}