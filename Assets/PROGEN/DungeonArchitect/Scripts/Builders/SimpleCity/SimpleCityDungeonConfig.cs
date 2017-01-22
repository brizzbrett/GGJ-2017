﻿using UnityEngine;
using System.Collections;
using DungeonArchitect;
using DungeonArchitect.Utils;

namespace DungeonArchitect.Builders.SimpleCity
{
    public class SimpleCityDungeonConfig : DungeonConfig
    {
        public Vector2 CellSize = new Vector2(4, 4);

        public int minSize = 15;
        public int maxSize = 20;

        public int minBlockSize = 2;
        public int maxBlockSize = 4;

        public float biggerHouseProbability = 0;

        public int cityWallPadding = 1;
        public int cityDoorSize = 1;
    }
}

