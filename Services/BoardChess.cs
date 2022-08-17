namespace ChessGameApp.Services
{
    public class BoardChess
    {

        public PieceWithColor[,] Pieces { get; set; }
        public bool WhitesTurn { get; set; }
        public SelectedPiece SelectedPiece { get; set; }
        public History History { get; set; }




        public BoardChess()
        {
            History = new History();
            WhitesTurn = true;
            Pieces = new PieceWithColor[8, 8]
            {
            {
            PieceWithColor.WhiteRook,
            PieceWithColor.WhiteKnight,
            PieceWithColor.WhiteBishop,
            PieceWithColor.WhiteQueen,
            PieceWithColor.WhiteKing,
            PieceWithColor.WhiteBishop,
            PieceWithColor.WhiteKnight,
            PieceWithColor.WhiteRook
            },
            {
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn,
            PieceWithColor.WhitePawn
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare,
            PieceWithColor.EmptySquare
            },
            {
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn,
            PieceWithColor.BlackPawn
            },
            {
            PieceWithColor.BlackRook,
            PieceWithColor.BlackKnight,
            PieceWithColor.BlackBishop,
            PieceWithColor.BlackQueen,
            PieceWithColor.BlackKing,
            PieceWithColor.BlackBishop,
            PieceWithColor.BlackKnight,
            PieceWithColor.BlackRook
            }
            };
        }
        public static BoardLocation GetLocation(int row, int cell) =>
            (BoardLocation)((row * 10) + cell + 1);

        public static (int, int) GetXYFromLocation(BoardLocation location) =>
            (((int)location / 10), ((int)location % 10)-1);
        //(((int) location / 10)-1, ((int) location % 10));
    }
    public class SelectedPiece
    {
        public PieceWithColor Piece { get; init; }
        public BoardLocation Location { get; init; }

    }
    public enum BoardLocation
    {
        A1 = 01, A2 = 11, A3 = 21, A4 = 31, A5 = 41, A6 = 51, A7 = 61, A8 = 71,
        B1 = 02, B2 = 12, B3 = 22, B4 = 32, B5 = 42, B6 = 52, B7 = 62, B8 = 72,
        C1 = 03, C2 = 13, C3 = 23, C4 = 33, C5 = 43, C6 = 53, C7 = 63, C8 = 73,
        D1 = 04, D2 = 14, D3 = 24, D4 = 34, D5 = 44, D6 = 54, D7 = 64, D8 = 74,
        E1 = 05, E2 = 15, E3 = 25, E4 = 35, E5 = 45, E6 = 55, E7 = 65, E8 = 75,
        F1 = 06, F2 = 16, F3 = 26, F4 = 36, F5 = 46, F6 = 56, F7 = 66, F8 = 76,
        G1 = 07, G2 = 17, G3 = 27, G4 = 37, G5 = 47, G6 = 57, G7 = 67, G8 = 77,
        H1 = 08, H2 = 18, H3 = 28, H4 = 38, H5 = 48, H6 = 58, H7 = 68, H8 = 78
    }
    public enum PieceWithColor
    {
        EmptySquare = 0,
        WhitePawn = 11,
        BlackPawn = 1,
        WhiteBishop = 12,
        BlackBishop = 2,
        WhiteKnight = 13,
        BlackKnight = 3,
        WhiteRook = 14,
        BlackRook = 4,
        WhiteQueen = 15,
        BlackQueen = 5,
        WhiteKing = 16,
        BlackKing = 6
    }



    public class History
    {
        public List<Move> Moves { get; set; }
        public History()
        {
            Moves = new List<Move>();
        }
        public void MakeMove(BoardLocation from, BoardLocation to, bool whitesTurn) =>
            Moves.Add(new Move { From = from, To = to, WhitesTurn = whitesTurn });
    }




    public struct Move
    {
        public bool WhitesTurn { get; set; }
        public BoardLocation From { get; set; }
        public BoardLocation To { get; set; }
    }


    public static class Extention
    {
        public static bool PieceIsWhite(this PieceWithColor piece) => (int)piece > 10;
    }
}

