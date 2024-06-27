using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SimpleRandomWalkParameters", menuName = "PCG/SimpleRandomWalk_SO", order = 0)]
public class SimpleRandomWalk_SO : ScriptableObject {
    public int interations = 10, walkLength = 10;
    public bool startRandomlyEachInteration = true;
}

