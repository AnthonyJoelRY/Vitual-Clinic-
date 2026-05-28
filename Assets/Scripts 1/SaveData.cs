using System;
using System.Collections;
using System.Collections.Generic;
using FullSerializer;
using Proyecto26;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static fsSerializer serializer = new fsSerializer();
    private string url_firebase = "https://virtualclinicutpl-default-rtdb.firebaseio.com/";
    

    public void writeNewUser(string name, string email, string username, string date, int? puntaje = null)
    {
        Debug.Log("Ingreso al metodo");
        User user = new User(name, email, username, date);
        
        RestClient.Post(url_firebase + "virtual-clinic-utpl" + "/Usuarios" + "/" + username + "/" + name + "/Registros" + ".json/", user).Then(
            response =>
            {
                Debug.Log("Usuario registrado con éxito");
                // Puedes agregar aquí cualquier lógica adicional después de un registro exitoso

             
            }
        ).Catch(
            error =>
            {
                Debug.LogError($"Error al registrar usuario: {error.Message}");
                // Puedes agregar aquí cualquier lógica adicional en caso de error
            }
        );
        
    }

}



// + "/Registros" + ".json/"

[Serializable]
class User {    
    public string nombre;
    public string email;
    public string username;
    public string date;

    public User(string nombre, string email, string username, string date){
        this.nombre = nombre;
        this.email = email;
        this.username = username;
        this.date = date;
    }
}


