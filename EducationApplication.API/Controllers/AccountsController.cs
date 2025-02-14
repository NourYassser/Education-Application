﻿/*using EducationApplication.BLL.Dtos.Accounts;
using EducationApplication.BLL.Manager.AccountManager;
using Microsoft.AspNetCore.Mvc;

namespace EducationApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AccountsController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            //Pass the urlHelper to the Register method
            var response = await _accountManager.Register(registerDto);

            if (response.successed)
            {

                return CreatedAtAction(nameof(Register), response);

            }
            return BadRequest(response.Errors);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var response = await _accountManager.Login(loginDto);

            if (response.successed)
            {
                return Ok(new { message = "Login successful" });
            }

            // Return unauthorized if login failed
            return Unauthorized(response.Errors);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {

            var responce = await _accountManager.ConfirmEmail(userId, token);
            if (responce.successed)

            {
                return Ok(new { message = "Email confirmed successfully" });
            }
            return BadRequest(responce.Errors);
        }

        *//*[HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {


            var UrlHepler = Url;
            var result = await _accountManager.ForgotPassword(forgotPasswordDto, UrlHepler);
            if (result.successed)
            {
                return Ok(new { message = "Password reset email sent successfully. Please check your inbox." });
            }
            return BadRequest(result.Errors);
        }*/

/*[HttpPost("ResetPassword")]
public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
{


    var UrlHepler = Url;
    var result = await _accountManager.ResetPassword(resetPasswordDto);
    if (result.successed)
    {
        return Ok(new { message = "Your password has been reset successfully." });
    }
    return BadRequest(result.Errors);
}*//*

[HttpGet("ShowResetToken")]
public IActionResult ShowResetToken(string token, string email)
{

    return Ok(new
    {

        Token = token,


        Email = email
    });
}

[HttpPost("AddRole")]
public async Task<IActionResult> AddRole(string RoleName)
{
    var result = await _accountManager.AddRole(RoleName);
    if (!result.successed)
    {
        return BadRequest(result.Errors);
    }
    return Ok(result.successed);
}

// Delete an existing role
[HttpDelete("DeleteRole")]
public async Task<IActionResult> DeleteRole(string RoleId)
{
    var result = await _accountManager.DeleteRole(RoleId);
    if (!result.successed)
    {
        return BadRequest(result.Errors);
    }
    return Ok(result.successed);
}

// Restore Role
[HttpPost("RestoreRole")]
public async Task<IActionResult> RestoreRole(string RoleId)
{
    var result = await _accountManager.RestoreRole(RoleId);
    if (!result.successed)
    {
        return BadRequest($"{result.Errors}");
    }
    return Ok(result.successed);
}

// Add a role to a user
[HttpPost("AddRoleToUser")]
public async Task<IActionResult> AddRoleToUser(string UserId, string RoleId)
{
    var result = await _accountManager.AddRoleToUser(UserId, RoleId);
    if (!result.successed)
    {
        return BadRequest(result.Errors);
    }
    return Ok(result.successed);
}

// Remove a role from a user
[HttpDelete("RemoveRoleFromUser")]
public async Task<IActionResult> RemoveRoleFromUser(string UserId, string RoleId)
{
    var result = await _accountManager.RemoveRoleFromUser(UserId, RoleId);
    if (!result.successed)
    {
        return BadRequest(result.Errors);
    }
    return Ok(result.successed);
}

// Get all roles
*//*[HttpGet("GetAllRoles")]
public async Task<IActionResult> GetAllRoles()
{
    var result = await _accountManager.();
    return Ok(result);
}*//*

// Get all rolesIs Deleted
*//*[HttpGet("GetAllRolesIsDeleted")]
public async Task<IActionResult> GetAllRolesIsDeleted()
{
    var result = await _accountManager.GetAllRolesIsDeleted();
    return Ok(result);
}*//*

// Get all users in a specific role
*//*[HttpGet("GetUsersInRole")]
public async Task<IActionResult> GetUsersInRole(string RoleId)
{
    var result = await _accountManager.GetUsersInRole(RoleId);
    if (!result.successed)
    {
        return BadRequest(result.Errors);
    }
    return Ok(result.Data);
}*//*
}
}*/