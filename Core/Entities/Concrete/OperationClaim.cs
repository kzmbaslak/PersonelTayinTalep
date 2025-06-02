using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // OperationClaim, kullanıcıların sahip olduğu yetkileri temsil eder.
        // Örneğin: "Admin", "User", "Editor" gibi roller olabilir.
        // Bu sınıf, kullanıcıların hangi operasyonlara erişebileceğini belirlemek için kullanılır.
    }
}
