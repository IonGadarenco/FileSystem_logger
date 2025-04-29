using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem_logger.Models
{
    enum UserRole
    { 
        Admin,
        RegularWorker
    }
    internal class User : Entity
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }  = UserRole.RegularWorker;
    }
}
