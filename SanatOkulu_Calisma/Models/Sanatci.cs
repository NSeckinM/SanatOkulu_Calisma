using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatOkulu_Calisma
{
    [Table("Sanatcilar")]
    public class Sanatci
    {
        
        //prop Adını Id değilde başka birşey verseydik [key] diyerek primary key yapılabilirdik.
        //identity yapmak için de =  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required, MaxLength(50) ]
        public string Ad { get; set; }


        //bire cok ilişkiyi anlayıp sağlayan navigation prop i collection turunde tuttuğundan anlıyor
        //  1 e çok ilişki bir sanatcının bir çok eseri olabilir.
        // virtual lazy loading için 
        public virtual ICollection<Eser> Eserler { get; set; }




    }
}
