using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

using Random = UnityEngine.Random;

public class FoodServingCustomerManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform queueStartPoint;


    [Header(" Settings ")]
    [SerializeField] private Vector3 queueSpacing;
    [SerializeField] private int maxCustomers;


    private Queue<Customer> customers = new Queue<Customer>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartSpawningCustomers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartSpawningCustomers()
    {
        InvokeRepeating("SpawnNewCustomer", 1, 1);
    }


    private void SpawnNewCustomer()
    {
        if (customers.Count >= maxCustomers)
            return;

        Customer newCustomer = CustomerManager.instance.Pop(spawnPoint.position);
        newCustomer.name = " Customer " + Random.Range(0, 1000);

        customers.Enqueue(newCustomer);

        Vector3 targetPosition = GetLastCustomerPosition();

        newCustomer.Initialize(targetPosition);

    }

    private Vector3 GetLastCustomerPosition()
    {
        return queueStartPoint.position + queueSpacing * (customers.Count - 1);
    }

}
