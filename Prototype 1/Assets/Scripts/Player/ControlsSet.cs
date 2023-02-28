using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [Serializable]
    public struct ControlsSet
    {

        public string HorizontalAxis => horizontalAxis;

        public string VerticalAxis => verticalAxis;

        public string ChangeCameraButton => changeCameraButton;

        [SerializeField]
        private string horizontalAxis;

        [SerializeField]
        private string verticalAxis;

        [SerializeField]
        private string changeCameraButton;

    }
}