﻿namespace MVCBank.Models
{
    public class Transferencia
    {
        public int IdTransfer { get; set; }
        public int IdAccountSender { get; set; }
        public int IdAccountReceiver { get; set; }
        public float Amount { get; set; }
        public DateTime DateIssue { get; set; }
    }
}
