﻿using System.Diagnostics.CodeAnalysis;
using WorldGeneration.Models;
using WorldGeneration.Models.HazardousTiles;
using WorldGeneration.Models.Interfaces;
using WorldGeneration.Models.TerrainTiles;

namespace WorldGeneration
{
    public class NoiseMapGenerator : INoiseMapGenerator
    {
        private IFastNoise _noise;
        private readonly int _seed;

        [ExcludeFromCodeCoverage]
        public NoiseMapGenerator(int seed)
        {
            _noise = new FastNoiseLite();
            _noise.SetNoiseType(FastNoiseLite.NoiseType.Cellular);
            _noise.SetFrequency(0.015f);
            _noise.SetCellularReturnType(FastNoiseLite.CellularReturnType.CellValue);
            _noise.SetSeed(seed);
            _seed = seed;
        }

        public Chunk GenerateChunk(int chunkX, int chunkY, int chunkRowSize)
        {
            var map = new ITile[chunkRowSize * chunkRowSize];
            for (var y = 0; y < chunkRowSize; y++)
            {
                for (var x = 0; x < chunkRowSize; x++)
                {
                    map[y * chunkRowSize + x] = CreateTileWithItemFromNoise(_noise.GetNoise(x + chunkX * chunkRowSize, y + chunkY * chunkRowSize)
                        , x + chunkRowSize * chunkX
                        , chunkRowSize * chunkY - chunkRowSize + y);
                }
            }
            return new Chunk(chunkX, chunkY, map, chunkRowSize, _seed);
        }

        private ITile CreateTileWithItemFromNoise(float noise, int x, int y)
        {
            RandomItemGenerator randomItemGenerator = new RandomItemGenerator();
            var tile = GetTileFromNoise(noise, x, y);
            var item = randomItemGenerator.GetRandomItem(noise);
            if (item != null)
            {
                tile.ItemsOnTile.Add(item);
            }
            return tile;
        }

        public ITile GetTileFromNoise(float noise, int x, int y)
        {
            y++;
            return (noise * 10) switch
            {
                (< -8) => new WaterTile(x, y),
                (< -4) => new DirtTile(x, y),
                (< 2) => new GrassTile(x, y),
                (< 3) => new SpikeTile(x, y),
                (< 8) => new StreetTile(x, y),
                _ => new GasTile(x, y)
            };
        }

        public void SetNoise(IFastNoise noise)
        {
            // This function exists for unit testing purposes.
            _noise = noise;
        }
    }
}