using System.Security.Claims;

namespace Backend
{    
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var result = user?.FindFirstValue(ClaimTypes.NameIdentifier);

            return result != null ? Convert.ToInt32(result) : -1;
        }
    }
}
