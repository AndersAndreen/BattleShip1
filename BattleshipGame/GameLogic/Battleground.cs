using BattleshipGame.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.Input;

namespace BattleshipGame.GameLogic
{
    internal class Battleground
    {
        private readonly List<Coordinate> _attackCoordinates = new List<Coordinate>();
        private readonly List<Battleship> _battleships = new List<Battleship>();
        private readonly List<int> _shipSizes = new List<int> { 5, 4, 4, 3 };
        private const int NumRows = 7;
        private const int NumColumns = 11;

        public Battleground()
        {
            PositionShips();
        }

        public void Update(Action<List<Coordinate>, List<Battleship>, Syntax> mapper, Syntax syntax)
        {
            mapper(_attackCoordinates, _battleships, syntax);
        }

        public void Cancel(Action<List<Coordinate>, List<Battleship>, Syntax> mapper, Syntax syntax)
        {
            _battleships.ForEach(ship => ship.Sink());
            mapper(_attackCoordinates, _battleships, syntax);
        }

        private void PositionShipsAtFixedPositions()
        {
            var row = 1;
            _shipSizes.ForEach(size => _battleships.Add(new Battleship(new Coordinate(row++, 1), size)));
        }

        private void PositionShips()
        {
            var rnd = new Random();
            bool colliding;
            _shipSizes.ForEach(size =>
            {
                Coordinate coordinateLeftSide;
                do
                {
                    coordinateLeftSide = new Coordinate(rnd.Next(0, NumRows), rnd.Next(0, NumColumns + 1 - size));
                    var requestedCoordinates = Battleship.EstimateOccupiedCoordinates(coordinateLeftSide, size);
                    colliding = _battleships.Any(ship =>
                        ship.GetOccupiedCoordinates()
                            .Any(coordinate => requestedCoordinates.Contains(coordinate)));
                } while (colliding);

                _battleships.Add(new Battleship(coordinateLeftSide, size));
            });

        }

        public bool GameWon() => _battleships.All(ship => ship.IsSunken);
        
        public AppResult Shoot(string inputParameter)
        {
            var attackCoordinate = Coordinate.Map(inputParameter);
            if (_battleships.Select(ship => ship
                .IsAlreadySunken(attackCoordinate)).Any(isSunken => isSunken))
            {
                return new AppResult(Command.ShipAlreadySunken, Message.None, inputParameter);
            }
            _attackCoordinates.Add(attackCoordinate);
            var hit = _battleships
                .Select(ship => ship.SinkIfHit(attackCoordinate)).Any(isHit => isHit);
            return hit
                ? new AppResult(Command.Hit, Message.None, inputParameter)
                : new AppResult(Command.Miss, Message.None, inputParameter);
        }
    }
}
