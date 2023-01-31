using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSymbol : MonoBehaviour
{
    protected SymbolEnum? symbol;

    public SymbolEnum? CurrentSymbol {
        get { return symbol.HasValue ? symbol.Value : null; }
        protected set {
            symbol = value;
            quadRenderer.material = materials[(int) symbol.Value];
        }
    }

    [SerializeField]
    protected MeshRenderer quadRenderer;

    [SerializeField]
    protected List<Material> materials;

    private void Awake() {
        DataHolder.Instance.AddEnemy(this);
    }

    // Start is called before the first frame update
    protected virtual void Start() {
        CurrentSymbol = GenerateRandomSymbol();
            
    }

    protected SymbolEnum GenerateRandomSymbol() {
        SymbolEnum newSymbol;
        do {
            newSymbol = (SymbolEnum) UnityEngine.Random.Range(0, Enum.GetValues(typeof(SymbolEnum)).Length);
        }
        while (newSymbol == CurrentSymbol);
        return newSymbol;
    }
}
