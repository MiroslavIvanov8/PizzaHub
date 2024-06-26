﻿namespace PizzaHub.Extensions
{
    using System.Security.Claims;
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            return userIdClaim?.Value;
        }
    }
}
