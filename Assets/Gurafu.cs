using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gurafu : MonoBehaviour
{
    public GameObject particle;
    public int min;
    public int max;
    public int mitudo;

    private List<Transform> ParticlePosList;
    private void Start()
    {
        ParticlePosList = new List<Transform>();

    }

    public void GurafuRender()
    {
        var ListLength = ParticlePosList.Count;
        var spotLength = (max - min) * mitudo + 1;

        for (int i = 0; i < spotLength; i++)
        {
            var pos = MakePosition(min + i * (1.0f / mitudo));
            if (i < ListLength)
            {
                var particleTransform = ParticlePosList[i];
                particleTransform.position = pos;
                particleTransform.gameObject.SetActive(true);
            }
            else
            {
                ParticlePosList.Add(Instantiate(particle, pos, new Quaternion()).transform);
            }
        }

        //すでにあるオブシェクトが描画すべきオブシェクトより多い場合
        if (ListLength > spotLength)
        {
            for (int i = 0; i < ListLength - spotLength; i++)
            {
                ParticlePosList[i + spotLength].gameObject.SetActive(false);
            }
        }
    }

    private Vector3 MakePosition(float x)
    {
        return new Vector3(x, f(x), 0);
    }

    private float f(float x)
    {
        return x*x;
    }
}
