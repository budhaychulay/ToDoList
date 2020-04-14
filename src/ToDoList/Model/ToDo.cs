using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Model
{
    public class T
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Description {  get; set; }

        [DataType(DataType.Date)]
        public DateTime DateExpiry { get; set; }

        [StringLength(10)]
        public string PercComplete { get; set; }
    }
}
