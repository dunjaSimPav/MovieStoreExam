﻿namespace MovieStore.Services
{
    public interface IEmailService
    {
        void SendEmail(string Address, string Subject, string Content);
    }
}
