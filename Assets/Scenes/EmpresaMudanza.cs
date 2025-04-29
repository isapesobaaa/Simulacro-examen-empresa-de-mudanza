using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// COSAS A TENER EN CUEENTA PARA EL EJERCICIO
// 1. Pida carga (minimo 100 kg) y distancia (minimo 1 km).
// 2. Segun la carga, seleccione el vehiculo adecuado.
// 3. Segun la distancia, calcule las horas minimas (minimo 2 horas + posible hora extra si excede 50 km).
// 4. Muestre en consola todo: vehiculo, horas, costo por hora y costo total.
// 5. Si hay error en los datos ingresados, tirar un error por consola y terminar.

public class EmpresaMudanza : MonoBehaviour
{
    // Start is called before the first frame update
        // Ingreso de datos simulados (1500 y 60 son ejemplo)
        public int carga = 1500;
        public int distancia = 60;

        // DECLARACION VARIABLES
        public string tipoVehiculo = "";
        public int precioHora = 0;
        public int capacidad = 0;
    void Start() {
       
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (!EsValido())
        {
            return
        }
        // SELECCION DE VEHICULO
        if (carga <= 2000)
        {
            tipoVehiculo = "Utilitario";
            capacidad = 2000;
            precioHora = 3000;
        
        } else if (carga <= 5000) {
            tipoVehiculo = "Pickup";
            capacidad = 5000;
            precioHora = 4500;
        
        } else if (carga <= 10000) {
            tipoVehiculo = "Camion";
            capacidad = 10000;
            precioHora = 7000;
        } else {
            Debug.Log("Error: No hay vehiculos disponibles para esa carga.");
            return;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // CALCULOS HORA
        int horasNecesarias = distancia / 25;
        if (distancia % 25 != 0)
        {
            horasNecesarias += 1;
        }

        if (horasNecesarias < 2) {
            horasNecesarias = 2;
        }

        if (distancia > 50) {
            horasNecesarias += 1; // Hora extra por regreso
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        // CALCULO PRECIO FINAL
        int precioTotal = horasNecesarias * precioHora;

        // VISUALIZAR RESULTADO
        Debug.Log("Vehiculo seleccionado: " + tipoVehiculo);
        Debug.Log("Precio total " + horasNecesarias + " horas a $" + precioHora + " : $" + precioTotal);
    }

    // Update is called once per frame
    bool EsValido()
    {  
        if (carga < 100)
        {
            Debug.Log("Error: La carga debe ser de al menos 100 kg.");
            return false;
        }

        if (distancia < 1)
        {
            Debug.Log("Error: La distancia debe ser de al menos 1 km.");
            return false;
        } 
        return true;
        
    }
}
