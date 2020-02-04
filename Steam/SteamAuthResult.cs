namespace FightSabers.Misc
{
    using System;
    using System.Runtime.CompilerServices;

    public class SteamAuthResult
    {
        public override string ToString() => 
            (!this.Success ? ("AuthTicket Failure: " + this.Resposne) : ("AuthTicket: " + this.Ticket));

        public bool Success { get; set; }

        public string Ticket { get; set; }

        public string Resposne { get; set; }
    }
}
