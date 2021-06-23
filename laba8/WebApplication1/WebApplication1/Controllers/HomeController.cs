using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/Lera")]
    [ApiController]
    public class userController : Controller
    {
        private IUserRepository repository;

        public userController(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>User list</returns>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <response code="200">User is found</response>
        /// <response code="404">User is not found</response>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await repository.Get(id);
            if (user == null) return NotFound("User not found");
            return await repository.Get(id);
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">User is added</response>
        /// <response code="400">User is added</response>
        /// <returns>User</returns>
        [HttpPost]
        public async Task<ActionResult<User>> Add(User user)
        {
            try
            {
                var addedUser = repository.Create(user);
                if (addedUser == null)
                {
                    return BadRequest("Add user error");
                }

                await repository.SaveChanges();
                return addedUser;
            }
            catch (Exception e)
            {
                return BadRequest("Add user error");
            }
        }

        /// <summary>
        /// Update User by Id
        /// </summary>
        /// <response code="200">User is updated</response>
        /// <response code="400">User is not updated</response>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            try
            {
                var updateduser = repository.Update(user);
                if (updateduser == null)
                {
                    return BadRequest("Update user error");
                }

                await repository.SaveChanges();
                return updateduser;
            }
            catch (Exception e)
            {
                return BadRequest("Update user error");
            }
        }

        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <response code="200">User is deleted</response>
        /// <response code="404">User is not found</response>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {   
            var deleteduser = repository.Delete(id);
            if (deleteduser == null) return NotFound("User not found");

            await repository.SaveChanges();
            return deleteduser;
        }
    }
}
