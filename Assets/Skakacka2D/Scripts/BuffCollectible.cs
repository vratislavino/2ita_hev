using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuffCollectible : MonoBehaviour
{
    [SerializeField]
    private BuffType buffType;

    [SerializeField]
    private float duration = 5f;

    private static Dictionary<BuffType, Type> getType = new Dictionary<BuffType, Type>() {
        { BuffType.Speed, typeof(SpeedBuff) },
        /* other buffs later */
    };

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponentInParent<PlayerMovement2D>();
        if (player != null) {

            var buff = (Buff)player.gameObject.GetComponent(getType[buffType]);
            if(buff) {
                buff.Collect();
            } else {
                buff = (Buff) player.gameObject.AddComponent(getType[buffType]);
                buff.Init(duration);
            }
            Destroy(gameObject);
        }
    }
}
public enum BuffType
{
    Speed,
    Jump,
    TimeScale
}