using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spawn_Cube : MonoBehaviour
{
    public Transform Cube;
    [SerializeField] public Transform[] Cubes;
    [SerializeField] public InputField S;
    [SerializeField] public InputField D;
    [SerializeField] public InputField T;

    public static long count = 100000; // вместимость массива с клонами
    public double speed;
    public double distance; 
    public double time = 0; // счётчик времени
    public int i = 0; //счётчик количества клонов
    [SerializeField] double standart;

    [SerializeField] public int[] mas_side = new int[count];
    [SerializeField] public double[] mas_dist = new double[count];
    [SerializeField] public double[] mas_comp1 = new double[count];
    [SerializeField] public double[] mas_comp2 = new double[count];


    void Start()
    {
        Cubes = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            mas_dist[i] = 0;
        }
    }

    void Update()
    {
        int time_spawn = System.Convert.ToInt32(T.text);
        distance = System.Convert.ToDouble(D.text);

        speed = System.Convert.ToSingle(S.text);
        standart = System.Math.Sqrt(2 * System.Math.Pow(speed / 60, 2));

        if (time % time_spawn == 0)
        { 
            Cubes[i] = Instantiate<Transform>(Cube, new Vector3(0, 0, 0), Quaternion.identity);
            mas_side[i] = Random.Range(0, 4);

            double koef = Random.Range(1, 10000);
            mas_comp1[i] = (koef / 10000) * standart;
            mas_comp2[i] = System.Math.Sqrt(System.Math.Pow(standart, 2) - System.Math.Pow(mas_comp1[i], 2));

            i++;
        }

        time += 1;

        for (int j = 0; j < i; j++)
        {
            if (Cubes[j] != null)
            {
                change_position(Cubes[j], mas_side[j], mas_comp1[j], mas_comp2[j]);
                mas_dist[j] += speed / 60;
                if (mas_dist[j] >= distance)
                {
                    DES(Cubes[j]);
                }
            }
        }
    }

    void change_position(Transform Cub, int side, double comp1, double comp2)
    {
        float comp11 = System.Convert.ToSingle(comp1);
        float comp22 = System.Convert.ToSingle(comp2);
        if (side == 0) { Cub.transform.position += new Vector3(comp11, 0, comp22); }
        else if (side == 1) { Cub.transform.position += new Vector3(-comp11, 0, comp22); }
        else if (side == 2) { Cub.transform.position += new Vector3(comp11, 0, -comp22); }
        else { Cub.transform.position += new Vector3(-comp11, 0, -comp22); }
    }

    void DES(Transform component)
    {
        Destroy(component.gameObject);
    }
}