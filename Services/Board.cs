using ChessGameApp.Components;

using Microsoft.AspNetCore.Components;

namespace ChessGameApp.Services
{
    public class Board 
    {
       
       
        public static PieceWithColor GetPiece(string piece)
        {
            switch (piece)
            {
                case "♟":
                    return PieceWithColor.BlackPawn;
                case "♜":
                    return PieceWithColor.BlackRook;
                case "♞":
                    return PieceWithColor.BlackKnight;
                case "♝":
                    return PieceWithColor.BlackBishop;
                case "♚":
                    return PieceWithColor.BlackKing;
                case "♛":
                    return PieceWithColor.BlackQueen;
                case "♙":
                    return PieceWithColor.WhitePawn;
                case "♖":
                    return PieceWithColor.WhiteRook;
                case "♘":
                    return PieceWithColor.WhiteKnight;
                case "♗":
                    return PieceWithColor.WhiteBishop;
                case "♕":
                    return PieceWithColor.WhiteQueen;
                case "♔":
                    return PieceWithColor.WhiteKing;

                default: 
                    return PieceWithColor.EmptySquare;
                    
            }
        }



        public static BoardLocation GetLocation(string location)
        {
            int x;
            int y;

            switch (location[0])
            {
                case 'a':
                    y = 0;
                    break;
                case 'b':  
                    y = 1;
                    break;
                case 'c':
                    y = 2;
                    break;
                case 'd':
                    y = 3;
                    break;
                case 'e':
                    y = 4;
                    break;
                case 'f':
                    y = 5;
                    break;
                case 'g':
                    y = 6;
                    break;
                case 'h':
                    y = 7;
                    break;
                default: 
                    y = -1;
                    break;
            }
            x = int.Parse(location[1].ToString());

            return (BoardLocation)((x*10)-10 + (y+1));

        } 



        


        private static BoardLocation[] GetPawnMoves(BoardChess board)
        {
            var legalMoves = new List<BoardLocation>();
            var loc = BoardChess.GetXYFromLocation(board.SelectedPiece.Location);
            var x = loc.Item1;
            var y = loc.Item2;
            if (board.SelectedPiece.Piece == PieceWithColor.WhitePawn)
            {
                //logic to promote                
                //one move foward
                if (board.Pieces[x+1, y ] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x+1, y ));
                }
                //two moves foward
                if (x == 1 && board.Pieces[x+1, y ] == PieceWithColor.EmptySquare && board.Pieces[x+2, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x+2, y ));
                }
                //take
                //enpasant
            }
            else
            {
                //logic to promote                
                //one move foward
                if (board.Pieces[x-1, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x-1, y));
                }
                //two moves foward
                if (x == 6 && board.Pieces[x-1, y] == PieceWithColor.EmptySquare && board.Pieces[x-2, y] == PieceWithColor.EmptySquare)
                {
                    legalMoves.Add(BoardChess.GetLocation(x-2, y));
                }
                //take
                //enpasant
            }
            return legalMoves.ToArray();
        }

        public static BoardLocation[] GetLegalMoves(BoardChess board)
        {
            if (board.SelectedPiece.Piece == PieceWithColor.BlackPawn
                || board.SelectedPiece.Piece == PieceWithColor.WhitePawn)
            {
                return GetPawnMoves(board);
            }



            return null;
        }
    }
}
