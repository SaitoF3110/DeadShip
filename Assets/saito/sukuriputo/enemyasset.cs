using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Enemy")]
public class enemyasset : ScriptableObject
{
    // Start is called before the first frame update
    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject enemy1stanup;
    public GameObject enemy1standown;
    public GameObject enemy1stanleft;
    public GameObject enemy1stanright;
}
