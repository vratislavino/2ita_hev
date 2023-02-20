using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SPGeneration : MonoBehaviour
{
    [SerializeField]
    private SPCollision objPrefab;

    [SerializeField]
    private int count = 20;

    List<SPCollision> objs = new List<SPCollision>();

    [SerializeField]
    TMPro.TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        Generate(count);
    }

    private void Generate(int count) {
        for (int i = 0; i < count; i++) {
            var a = Instantiate(objPrefab, GetRandomPoint(), Quaternion.identity);
            a.genRef = this;
            objs.Add(a);
        }
    }

    private Vector3 GetRandomPoint() {
        return new Vector3(Random.Range(0,100), 10, Random.Range(0,100));
    }

    public void Destroyed(SPCollision col) {
        objs.Remove(col);
        text.text = (count - objs.Count) + "/" + count;
    }
}
