using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IntersectionManager : MonoBehaviour
{
    public static IntersectionManager instance = null;
    public event Action<List<IntersectionData>> arrivedAtIntersection;
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) StartIntersection(3);
    }
    private void StartIntersection(int amount)
    {
        arrivedAtIntersection?.Invoke(IntersectionAlgo.Yeet(amount));
    }

    private void DoEffect(List<RoomEffectsA> lre)
    {
        for(int i = 0; i < lre.Count; ++i)
        {
            //if(lre[i] is LockedRoom)invento
        }
    }
}
