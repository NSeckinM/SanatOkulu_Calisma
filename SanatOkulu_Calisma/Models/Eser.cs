using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatOkulu_Calisma
{

    [Table("Eserler")]
    public class Eser
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Ad { get; set; }
        public int? Yil { get; set; } //nullable olmayan alanlar doğal olarak zorunludur.
        public int SanatciId { get; set; } // asağıda navigation prop yaptıktan sonra entity bu prop u isminden anlayıp Foreing key yapıyor (Sanatcı + Id)class ismi + Id den anlıyor ama navigation prop şart.
        //eger neyin foreing key yapılacağı yukarıdaki giri propla belirtilmezse entity kendisi bir isimle foreing key atar ve biz ona ulaşamayız.

        //prop tanımladık ama adı farklı olursa forein key yapmak için üzerine [ForingnKey("Navigation propun adı")] şeklinde yapılır.

        //navigation prop 1-1 ilişki bir eserin bir sanatcısı olabilir
        public virtual Sanatci Sanatci { get; set; }

    }
}
