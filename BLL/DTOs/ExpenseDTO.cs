﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public DateTime Date { get; set; } 
        [Required]
        public string Description { get; set; } 
        public bool IsRecurring { get; set; } 
    }
}
