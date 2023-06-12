using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fool : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    protected float currentAngle;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GenerateAngle();
    }

    protected void ResetPosition() {
        transform.position = Vector3.zero;
        GenerateAngle();
    }

    protected void GenerateAngle() {
        currentAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(currentAngle * Vector3.up);
    }

    public virtual void OnClicked() {
        Hit();
        ReactToClick();
    }

    private void Hit() {
        var mesh = GetComponentInChildren<MeshRenderer>();
        mesh.material.color = Color.red;
        LeanTween.color(mesh.gameObject, Color.white, .3f);
    }

    protected abstract void ReactToClick();

    protected abstract void Move();

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
