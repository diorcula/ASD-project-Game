﻿namespace WorldGeneration.Models.BuildingTiles
{
    public class HouseTile : BuildingTile
    {
        public HouseTile()
        {
            Symbol = TileSymbol.House;
            IsAccessible = true;
        }

        public override void DrawBuilding()
        {
            throw new System.NotImplementedException();
        }
    }
}
