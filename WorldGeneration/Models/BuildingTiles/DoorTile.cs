﻿using System;
using System.Diagnostics.CodeAnalysis;
using WorldGeneration.Models.Interfaces;

namespace WorldGeneration.Models.BuildingTiles
{
    [ExcludeFromCodeCoverage]
    public class DoorTile : IBuildingTile
    {
        public bool IsAccessible { get; set; }
        public string Symbol { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public DoorTile()
        {
            Symbol = TileSymbol.DOOR;
            IsAccessible = true;
        }

        public void DrawBuilding()
        {
            throw new NotImplementedException();
        }
    }
}