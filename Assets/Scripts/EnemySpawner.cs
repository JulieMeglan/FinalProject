using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array to hold the enemy prefabs
    public float spawnInterval = 2f; // Time interval between spawns

    private Transform playerTransform; // Reference to the player's transform
    private Tilemap floorTilemap; // Reference to the floor Tilemap
    private BoundsInt tileBounds; // Bounds of the Tilemap

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the Player by tag
        floorTilemap = GameObject.Find("Floor").GetComponent<Tilemap>(); // Assuming the floor has a Tilemap component
        tileBounds = floorTilemap.cellBounds; // Get the bounds of the tilemap
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Choose a random enemy prefab from the array
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Vector3Int randomCell;

        // Find a random cell in the Tilemap within the bounds
        do
        {
            int randomX = Random.Range(tileBounds.x, tileBounds.x + tileBounds.size.x);
            int randomY = Random.Range(tileBounds.y, tileBounds.y + tileBounds.size.y);
            randomCell = new Vector3Int(randomX, randomY, 0); // Create a new Vector3Int for the random cell

        } while (floorTilemap.GetTile(randomCell) == null); // Ensure the tile is valid (not null)

        // Convert the cell position to world position
        Vector3 spawnPosition = floorTilemap.GetCellCenterWorld(randomCell);

        // Instantiate the enemy prefab at the calculated position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
