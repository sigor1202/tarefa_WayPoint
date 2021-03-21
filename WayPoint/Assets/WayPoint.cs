using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    //cria uma lista de GameObjects
    public GameObject[] waypoints;
    //variavel que guarda o ponto atual
    int currentWP = 0;
    //velocidade de movimento do player
    float speed = 1f;
    //variavel utilizada pra medir a distancia
    float accuracy = 1f;
    //velocidade de rotação
    float rotSpeed = 0.4f;

    void Start()
    {
        //acha os objetos com a tag WayPoints e a atribui a lista deGameObjects waypoints
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    void LateUpdate()
    {
        //verifica se o tamanho da lista é igual a zero se for não acontecera nada
        if (waypoints.Length == 0)
            return;
        //atribiu a posição do ponto atual ao vector 3 e igonora o eixo y
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z);

        //faz o objeto olhar para o ponto atual
        Vector3 direction = lookAtGoal - this.transform.position;
        //suaviza a rotação
        transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        //verifica se a magnitude é menor que o acurracy
        if (direction.magnitude < accuracy)
        {
            //aumenta o currentWP
            currentWP++;
            //verifica se o valor do currentWP é maoir ou igual que a lista
            if (currentWP >= waypoints.Length)
            {
                //atribui o valor zero a variavel
                currentWP = 0;
            }
        }
        //move o objeto em direção aoponto
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
