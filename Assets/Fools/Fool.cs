using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fool : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    protected float currentAngle;

    private Color originColor;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GenerateAngle();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        originColor = meshRenderer.material.color;
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
        meshRenderer.material.color = Color.red;
        LeanTween.color(meshRenderer.gameObject, originColor, .3f);
    }

    protected abstract void ReactToClick();

    protected abstract void Move();

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
