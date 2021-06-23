using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        /// <example>Lestberg</example>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        /// <example>Kirill</example>
        public string FirstName { get; set; }

        /// <summary>
        /// User e-mail
        /// </summary>
        /// <example>gusi@gusi.com</example>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        /// <example>password</example>
        public string Password { get; set; }

        /// <summary>
        /// active/passive
        /// </summary>
        /// <example>Active</example>
        public string Status { get; set; }

        /// <summary>
        /// admin/user
        /// </summary>
        /// <example>customer</example>
        public string Role { get; set; }
    }
}
