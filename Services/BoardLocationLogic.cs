

namespace ChessGameApp.Services
{
    public class Board
    {
        int Row { get; set; }
        int Cell { get; set; }

        

        public enum BoardLocation
        {
            a1 = 01, a2 = 02, a3 = 03, a4 = 04, a5 = 05, a6 = 06, a7 = 07, a8 = 08,
            b1 = 11, b2 = 12, b3 = 13, b4 = 14, b5 = 15, b6 = 16, b7 = 17, b8 = 18,
            c1 = 21, c2 = 22, c3 = 23, c4 = 24, c5 = 25, c6 = 26, c7 = 27, c8 = 28,
            d1 = 31, d2 = 32, d3 = 33, d4 = 34, d5 = 35, d6 = 36, d7 = 37, d8 = 38,
            e1 = 41, e2 = 42, e3 = 43, e4 = 44, e5 = 45, e6 = 46, e7 = 47, e8 = 48,
            f1 = 51, f2 = 52, f3 = 53, f4 = 54, f5 = 55, f6 = 56, f7 = 57, f8 = 58,
            g1 = 61, g2 = 62, g3 = 63, g4 = 64, g5 = 65, g6 = 66, g7 = 67, g8 = 68,
            h1 = 71, h2 = 72, h3 = 73, h4 = 74, h5 = 75, h6 = 76, h7 = 77, h8 = 78
        }
        public static BoardLocation GetLocation(int row, int cell) => (BoardLocation)((row * 10) + cell + 1); //gauti laukelio pavadinima is row ir cell
        public static (int, int) GetXYFromLocation(BoardLocation location) => ((int)location / 10, ((int)location % 10) - 1); // gauti kordinates is laukelio pavadinimo

        
        private BoardLocation[] GetPawnMoves(Board board)
        {
            var legalMoves = new List<BoardLocation>();
            var locationNumber = (int)board.SelectedPiece.Location;
            var loc = Board.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;
            if (board.SelectedPiece.Piece == PieceWithColor.WhitePawn)
            {
                //logic to promote                
                //one move foward
                if (board.Pieces[x + 1, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(Board.GetLocation(x + 1, y));
                }
                //two moves foward
                if (x == 1 && board.Pieces[x + 1, y] == PieceWithColor.EmptySquare && board.Pieces[x + 2, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(Board.GetLocation(x + 2, y));
                }
                //take
                //enpasant
            }
            else
            {
                //logic to promote                
                //one move foward
                if (board.Pieces[x - 1, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(Board.GetLocation(x - 1, y));
                }
                //two moves foward
                if (x == 6 && board.Pieces[x - 1, y] == PieceWithColor.EmptySquare && board.Pieces[x - 2, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(Board.GetLocation(x - 2, y));
                }
                //take
                //enpasant
            }
            return legalMoves.ToArray();
        }
    }
}
