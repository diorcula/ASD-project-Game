﻿using System;
using WorldGeneration.Models;
using WorldGeneration.Models.Interfaces;

namespace WorldGeneration.Helper
{
    public class ChunkHelper
    {
        private readonly Chunk _chunk;
        public ChunkHelper(Chunk chunk)
        {
            _chunk = chunk;
        }
        public int[] GetTileCoordinatesInChunk(int indexInArray)
        {
            var x = indexInArray % _chunk.RowSize;
            var y = (int)Math.Floor((double)indexInArray / _chunk.RowSize);
            return new[] { x, y };
        }

        private int GetPositionInTileArrayByWorldCoordinates(int x, int y)
        {

            var yPos = Math.Abs(y);
            var chunkYPos = Math.Abs(_chunk.Y);
            while (x < 0)
            {
                x = x + _chunk.RowSize;
            }
            var y1 = (_chunk.RowSize * _chunk.RowSize - _chunk.RowSize) - (Math.Abs(chunkYPos * _chunk.RowSize - yPos) * _chunk.RowSize);
            var x1 = x % _chunk.RowSize;

            return x1 + y1;
        }

        public ITile GetTileByWorldCoordinates(int x, int y) => _chunk.Map[GetPositionInTileArrayByWorldCoordinates(x, y)];
    }
}
