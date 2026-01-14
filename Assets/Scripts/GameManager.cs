using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject baseCar;
    public GameObject spawnPoint;

    private GameObject spawnedCar;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Spawn();
        }
        if (spawnedCar != null) {
            Vector2 carPos = spawnedCar.transform.position;
            carPos += new Vector2 (10*Time.deltaTime, 0);
            spawnedCar.transform.position = carPos;
        }

        if(spawnedCar != null && spawnedCar.transform.position.x >= 13) {
            Destroy(spawnedCar);
            spawnedCar = null;
        }
    }

    void Spawn() {
        
        if (spawnedCar == null) {
            spawnedCar = Instantiate(baseCar, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        else {
            Debug.Log("Car is already spawned");
        }
    }
}
