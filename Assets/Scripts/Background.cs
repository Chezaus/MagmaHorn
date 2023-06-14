using System;
using UnityEngine;

namespace _Scripts
{
    public class Background : MonoBehaviour
    {
        private float _startingPos, //This is the starting position of the sprites.
        _lengthOfSprite; //This is the length of the sprites.
        private float yStartingpos, _heightOfSprite;
        public float AmountOfParallax; //This is amount of parallax scroll. 
        public Camera MainCamera; //Reference of the camera.



        private void Start()
        {
            //Getting the starting X position of sprite.
            _startingPos = transform.position.x;
            //Getting the length of the sprites.
            _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;

            yStartingpos = transform.position.y;
            _heightOfSprite = GetComponent<SpriteRenderer>().bounds.size.y;

        }



        private void Update()
        {
            Vector3 Position = MainCamera.transform.position;
            float Temp = Position.x * (1 - AmountOfParallax);
            float _Temp = Position.y * (1 - AmountOfParallax);
            float Distance = Position.x * AmountOfParallax;
            float Height = Position.y * AmountOfParallax;

            Vector3 NewPosition = new Vector3(_startingPos + Distance, yStartingpos + Height, transform.position.z);

            transform.position = NewPosition;

            if (Temp > _startingPos + (_lengthOfSprite / 2))
            {
                _startingPos += _lengthOfSprite;
            }
            else if (Temp < _startingPos - (_lengthOfSprite / 2))
            {
                _startingPos -= _lengthOfSprite;
            }

            if (_Temp > yStartingpos + (_heightOfSprite / 2))
            {
                yStartingpos += _heightOfSprite;
            }
            else if (_Temp < yStartingpos - (_heightOfSprite / 2))
            {
                yStartingpos -= _heightOfSprite;
            }

        }
    }
}