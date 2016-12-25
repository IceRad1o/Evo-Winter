using UnityEngine;
using System;
using System.Collections.Generic; 		//Allows us to use Lists.
using Random = UnityEngine.Random; 		//Tells Random to use the Unity Engine random number generator.

public class BoardManager : MonoBehaviour
    {
        // Using Serializable allows us to embed a class with sub properties in the inspector.
        [Serializable]
        public class Count
        {
            public int minimum; 			
            public int maximum; 			


            //Assignment constructor.
            public Count(int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }


        public Count wallCount = new Count(5, 9);						
        public Count foodCount = new Count(1, 5);						
        public GameObject exit;											
        public GameObject[] floorTiles;									
        public GameObject[] wallTiles;								
        public GameObject[] foodTiles;								
        public GameObject[] enemyTiles;								
        public GameObject[] outerWallTiles;								

        private Transform boardHolder;								
        private List<Vector3> gridPositions = new List<Vector3>();	

        Vector3 RandomPosition()
        {
           
            int randomIndex = Random.Range(0, gridPositions.Count);

           
            Vector3 randomPosition = gridPositions[randomIndex];

         
            gridPositions.RemoveAt(randomIndex);

          
            return randomPosition;
        }


       
        void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
        {
          
            int objectCount = Random.Range(minimum, maximum + 1);

            
            for (int i = 0; i < objectCount; i++)
            {
             
                Vector3 randomPosition = RandomPosition();

                //Choose a random tile from tileArray and assign it to tileChoice
                GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

                //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
                Instantiate(tileChoice, randomPosition, Quaternion.identity);
            }
        }


        //SetupScene initializes our level and calls the previous functions to lay out the game board
        public void SetupScene(int level)
        {
           

            //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
            LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);

            //Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
            LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);

            //Determine number of enemies based on current level number, based on a logarithmic progression
            int enemyCount = (int)Mathf.Log(level, 2f);

            //Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
            LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);

           
        }
    }

