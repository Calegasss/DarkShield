using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSensibilidadeMouse : MonoBehaviour
{
    [SerializeField] private float sensibilidadeMaxima = 10.0f; 
    [SerializeField] private float sensibilidadeMinima = 1.0f;  

    public void AjustarSensibilidade(float value)
    {
        float novaSensibilidade = Mathf.Lerp(sensibilidadeMinima, sensibilidadeMaxima, value);
    }
}
