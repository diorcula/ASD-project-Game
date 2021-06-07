﻿using Items;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WorldGeneration.Models.Interfaces;

namespace WorldGeneration.Models.BuildingTiles
{
    [ExcludeFromCodeCoverage]
    public class WallTile : IBuildingTile
    {
        public bool IsAccessible { get; set; }
        public string Symbol { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int StaminaCost { get; set; }
        public List<Item> ItemsOnTile { get; set; }

        public WallTile()
        {
            Symbol = TileSymbol.WALL;
            IsAccessible = false;
            ItemsOnTile = new List<Item>();
        }

        public void DrawBuilding()
        {
            throw new NotImplementedException();
        }
    }
}