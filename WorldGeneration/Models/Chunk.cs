using System;
using WorldGeneration.Models.Interfaces;

namespace WorldGeneration.Models
{
    public class Chunk : IEquatable<Chunk>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ITile[] Map { get; set; }
        public int RowSize { get; set; }
        
        public Chunk()
        {
        }
        
        public Chunk(int x, int y, ITile[] map, int rowSize)
        {
            X = x;
            Y = y;
            Map = map;
            RowSize = rowSize;
        }


        
        //writes out the symbols for the tilemap of the current chunk in the proper shape.
        public void DisplayChunk()
        {
            for (var i = 0; i < Map.Length; i++)
            {
                if (i % RowSize == 0) Console.WriteLine(" ");

                Console.Write(" " + Map[i].Symbol);
            }

            Console.WriteLine("");
        }

        //returns the coordinates relative to the start (left top) of the chunk. 0,0 is the left top. First value is x, second is y.
        public int[] GetTileCoordinatesInChunk(int indexInArray)
        {
            var x = indexInArray % RowSize;
            var y = (int) Math.Floor((double) indexInArray / RowSize);
            return new[] {x, y};
        }

        //returns the coordinates relative to the center of the world. First value is x, second is y.
        public int[] GetTileCoordinatesInWorld(int indexInArray)
        {
            var internalCoordinates = GetTileCoordinatesInChunk(indexInArray);
            return new[] {internalCoordinates[0] + RowSize * X, internalCoordinates[1] + RowSize * Y};
        }

        public int GetPositionInTileArrayByWorldCoordinates(int x, int y)
        {
            return (x % RowSize) + ((RowSize * RowSize - RowSize) - (Y * RowSize - y) * RowSize);
        }

        public bool Equals(Chunk other)
        {
            if (ReferenceEquals(null, other)) 
                return false;
            
            if (ReferenceEquals(this, other)) 
                return true;
            
            return X == other.X && Y == other.Y && RowSize == other.RowSize;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            
            if (ReferenceEquals(this, obj)) 
                return true;
            
            if (obj.GetType() != GetType()) 
                return false;
            
            return Equals((Chunk) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, RowSize);
        }
    }
}