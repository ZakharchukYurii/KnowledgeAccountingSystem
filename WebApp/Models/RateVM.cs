﻿namespace WebApp.Models
{
    public class RateVM
    {
        public int Id { get; set; }
        public int Rate { get; set; }

        public int UserId { get; set; }
        public string User { get; set; }

        public int KnowledgeId { get; set; }
        public string Knowledge { get; set; }
    }
}