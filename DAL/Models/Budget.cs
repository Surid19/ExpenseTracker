using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Budget
    {
        public int Id { get; set; }
        [Required]
        public decimal TotalBudget { get; set; }
        [Required]  
        public decimal SpentAmount { get; set; }

    }

}
