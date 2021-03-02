using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame.GameLogic
{
    internal class Battleship
    {
        public Coordinate CoordinateLeftSideOfShip { get; }
        public int ShipSize { get; }
        public bool IsSunken { get; private set; }

        public Battleship(Coordinate coordinateLeftSideOfShip, int shipSize)
        {
            CoordinateLeftSideOfShip = coordinateLeftSideOfShip;
            ShipSize = shipSize;
            IsSunken = false;
        }

        public List<Coordinate> GetOccupiedCoordinates()
            => EstimateOccupiedCoordinates(CoordinateLeftSideOfShip, ShipSize);

        public bool SinkIfHit(Coordinate coordinate)
        {
            var previouslySunken = IsSunken;
            if (GetOccupiedCoordinates().Contains(coordinate)) { IsSunken = true; }
            return !previouslySunken && IsSunken;
        }

        public bool IsAlreadySunken(Coordinate coordinate)
        {
            var x= (IsSunken && GetOccupiedCoordinates().Contains(coordinate));
            return x;
        }

        public void Sink()
        {
            IsSunken = true;
        }

        public static List<Coordinate> EstimateOccupiedCoordinates(Coordinate coordinateLeftSideOfShip, int shipSize) 
            => Enumerable.Range(coordinateLeftSideOfShip.Col, shipSize)
            .Select(col => new Coordinate(coordinateLeftSideOfShip.Row, col))
            .ToList();
    }
}
