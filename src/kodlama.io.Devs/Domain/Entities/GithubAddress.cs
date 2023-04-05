using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GithubAddress : Entity
    {
        public int UserId { get; set; }
        public string Address { get; set; }

        //todo : AppUser gibi User'dan extend olan bir entity oluşturup, 1:0(bire-çok) ilişkiyi AppUser üzerinden
        //gösterebilirdik. Bu durumda UserRepositorylerindeki tüm entitiyleri AppUser olarak güncellemek gerekiyor.
        //User core'dan geldiği için, içerisine müdahale edemediğimizden ötürü User tarafında 1:0 ilişkisini gösterememekteyiz.
        //ilerleyen zamanda denenebilir.
        public User User { get; set; }

        public GithubAddress()
        {
        }

        public GithubAddress(int id, int userId, string address) : this()
        {
            Id = id;
            UserId = userId;
            Address = address;
        }
    }
}
