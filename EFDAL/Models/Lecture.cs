using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL.Models
{
    public class Lecture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [ForeignKey("Lecturer")]
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public Lecturer Lecturer { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
