namespace Memento;

public class Position
{
    private int Cell { get; set; }

    public class Piece
    {
        public Position _position = new Position { Cell = 0 };

        public void Move(int n) => _position.Cell = n;

        public Position GetPosition() => new Position { Cell = _position.Cell };

        public void SetPosition(Position p) => _position.Cell = p.Cell;
    }
}

public class Player
{
    List<Position> positionMemory = new();
    Position.Piece Piece = new();

    public void GetForward()
    {
        var position = Piece.GetPosition();
        positionMemory.Add(position);

        int n = new Random().Next(1, 6);
        Piece.Move(n);
    }

    public void GetBack()
    {
        var position = positionMemory.Last();
        positionMemory.Remove(position);
        Piece.SetPosition(position);
    }
}
