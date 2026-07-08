using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class ChessGame
    {
        [Key]
        public int Id { get; set; }
        //public ChessPiece[,] Board { get; set; }
        public string ChessPiece { get; set;}

        [Required]
        public int WhiteUserId { get; set; }

        // Navigation property
        [ForeignKey(nameof(WhiteUserId))]
        public User WhiteUser { get; set;}

               [Required]
        public int BlackUserId { get; set; }

        // Navigation property
        [ForeignKey(nameof(BlackUserId))]
        public User BlackUser { get; set;}

        public GameState Outcome { get; set; }

        public bool WhiteTurn { get; set; } 

            }

    public enum ChessPiece
{
    WhitePawn,
    BlackPawn,
    WhiteRook,
    BlackRook,
    WhiteKnight,
    BlackKnight,
    WhiteBishop,
    BlackBishop,
    WhiteQueen,
    BlackQueen,
    WhiteKing,
    BlackKing,
}

public enum GameState {
    InProgress,
    GamerWhiteWon,
    GamerBlackWon,
    GameDrawn,
}

}
