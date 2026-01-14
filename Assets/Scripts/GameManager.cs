using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject baseCar;
    public GameObject spawnPoint;
    public GameObject doorHinge1, doorHinge2;

    private GameObject spawnedCar;
    private bool canPass = false;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Spawn();
        }
        if (spawnedCar != null && spawnedCar.transform.position.x < 0) {
            Vector2 carPos = spawnedCar.transform.position;
            carPos += new Vector2 (10*Time.deltaTime, 0);
            spawnedCar.transform.position = carPos;
        }

        if(spawnedCar != null && spawnedCar.transform.position.x >= 0 && canPass == true) {
            Vector2 carPos = spawnedCar.transform.position;
            carPos += new Vector2(10 * Time.deltaTime, 0);
            spawnedCar.transform.position = carPos;
        }

        if(spawnedCar != null && spawnedCar.transform.position.x >= 13) {
            Destroy(spawnedCar);
            spawnedCar = null;
        }

        if (Input.GetKeyDown(KeyCode.N)) {
            doorHinge1.transform.rotation = Quaternion.Euler(0, 0, -90);
            doorHinge2.transform.rotation = Quaternion.Euler(0, 0, -90);
            canPass = true;
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            doorHinge1.transform.rotation = Quaternion.Euler(0, 0, 0);
            doorHinge2.transform.rotation = Quaternion.Euler(0, 0, 180);
            canPass = false;
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
