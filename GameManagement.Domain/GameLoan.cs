using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameManagement.Domain
{
    public class GameLoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Game")]
        public long GameId { get; set; }

        public Game Game { get; set; }

        [ForeignKey("Friend")]
        public long FriendId { get; set; }

        public Friend Friend { get; set; }

        public DateTime LoanDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
